using UnityEngine;
using UnityEngine.UI;

public class CharacterStateManager : MonoBehaviour
{
    [SerializeField] private CharacterObject _character;
    [SerializeField] private UpgradedStatsObject _upgradedStats;
    [HideInInspector] public float _maxHealth;
    [HideInInspector] public float _currentHealth;
    [HideInInspector] public int _damage;
    [HideInInspector] public int _speed;
    [HideInInspector] public float _baseAttackTime;
    [HideInInspector] public int _critChance;
    [HideInInspector] public int _missChance;
    [HideInInspector] public int _bashChance;
    [HideInInspector] public float _attackRange;
    public Transform _attackPoint;

    [SerializeField] private GameObject _effectOnHit;
    [SerializeField] private GameObject _effectOnCrit;
    [SerializeField] private GameObject _wordOnCrit;
    [SerializeField] private GameObject _wordOnMiss;
    [SerializeField] private GameObject _wordOnBash;

    private CharacterBaseState _currentState;

    public CharacterIdleState _idleState = new CharacterIdleState();
    public CharacterWalkingState _walkingState = new CharacterWalkingState();
    public CharacterAttackState _attackState = new CharacterAttackState();
    public CharacterDieState _dieState = new CharacterDieState();
    public CharacterStunState _stunState = new CharacterStunState();

    [HideInInspector] public Animator _animatorController;
    [HideInInspector] public Rigidbody2D _rigidBody;

    [HideInInspector] public Joystick _joystick;
    [HideInInspector] public Button _attackButton;

    [HideInInspector] public DirectionState _directionState = DirectionState.Right;
    [HideInInspector] public Vector2 _moveDerection;
    [HideInInspector] public Vector2 _moveVelocity;
    [HideInInspector] public Transform _playerPosition;

    [HideInInspector] public float _attackCooldown = 0f;
    private LayerMask _enemyLayer;
    private LayerMask _playerLayer;

    [HideInInspector] public string _nickname = "Character";

    [HideInInspector] public float _stunDuration = 2f;

    public bool _isPlayer = true;
    [HideInInspector] public bool _isDead = false;


    private void Start()
    {
        Init();
        SetStats();
        _currentState = _idleState;
        _currentState.EnterState(this);
    }

    private void Init()
    {
        _animatorController = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _joystick = GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<Joystick>();
        _attackButton = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Button>();
        _attackPoint = transform.Find("AttackPoint");
        _enemyLayer = LayerMask.GetMask("Enemy");
        _playerLayer = LayerMask.GetMask("Player");
    }

    private void SetStats()
    {
        if (_isPlayer)
        {
            _maxHealth = _character._health + _upgradedStats.GetHealth();
            _damage = _character._damage + _upgradedStats.GetDamage();
            _speed = _character._speed + _upgradedStats.GetSpeed();
            _baseAttackTime = _character._attackTime;
            _attackRange = _character._attackRange;
            _critChance = _character._critChance + _upgradedStats.GetCritChance();
            _missChance = _character._missChance + _upgradedStats.GetMissChance();
            _bashChance = _character._bashChance + _upgradedStats.GetBashChance();
            _currentHealth = _maxHealth;
        }
        else
        {
            _maxHealth = _character._health + GetExtraStats("Health");
            _damage = _character._damage + GetExtraStats("Damage");
            _speed = _character._speed + Random.Range(0, 3);
            _baseAttackTime = _character._attackTime;
            _attackRange = _character._attackRange;
            _critChance = _character._critChance;
            _missChance = _character._missChance;
            _bashChance = _character._bashChance;
            _currentHealth = _maxHealth;
        }
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(CharacterBaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        state.EnterState(this);
    }

    public void Attack()
    {
        if (_isPlayer)
        {
            _currentState = _attackState;
            _currentState.EnterState(this);
        }
    }

    private void OnAttack()
    {
        if (_isPlayer)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<CharacterStateManager>().TakenDamage(_damage);
            }
        }
        else
        {
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _playerLayer);
            foreach (Collider2D player in hitPlayers)
            {
                player.GetComponent<CharacterStateManager>().TakenDamage(_damage);
            }
        }
    }

    public void TakenDamage(int damage)
    {
        int randomMiss = Random.Range(0, 100);
        if(randomMiss <= _missChance)
        {
            Instantiate(_wordOnMiss, transform.position, Quaternion.identity);
            return;
        }

        int randomBash = Random.Range(0, 100);
        if(randomBash <= _bashChance)
        {
            Instantiate(_wordOnBash, transform.position, Quaternion.identity);
            SwitchState(_stunState);
        }

        int randomCrit = Random.Range(0, 100);
        if(randomCrit <= _critChance)
        {
            Instantiate(_wordOnCrit, transform.position, Quaternion.identity);
            Instantiate(_effectOnCrit, transform.position, Quaternion.identity);
            _currentHealth -= damage * 2;
        }
        else
        {
            Instantiate(_effectOnHit, transform.position, Quaternion.identity);
            _currentHealth -= damage;
        }

        if(_currentHealth <= 0)
        {
            SwitchState(_dieState);
        }
    }

    private int GetExtraStats(string statName)
    {
        int random = Random.Range(1, 4);
        if(random == 1)
        {
            if(statName == "Health") return 0;
            else return 0;
        }
        else if(random == 2)
        {
            if (statName == "Health") return 200;
            else return 5;
        }
        else if (random == 3)
        {
            if (statName == "Health") return 400;
            else return 10;
        }
        else
        {
            if (statName == "Health") return 600;
            else return 15;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }    

    public void FlipCharacter()
    {
        if (_directionState == DirectionState.Right)
        {
            _directionState = DirectionState.Left;
        }
        else
        {
            _directionState = DirectionState.Right;
        }
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public enum DirectionState
    {
        Right,
        Left,
    }
}
