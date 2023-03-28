using UnityEngine;
using UnityEngine.UI;

public class CharacterStateManager : MonoBehaviour
{
    [SerializeField] private CharacterObject _character;
    [SerializeField] private UpgradedStatsObject _upgradedStats;
    public float _maxHealth;
    public float _currentHealth;
    public int _damage;
    public int _speed;
    public float _baseAttackTime;
    public int _critChance;
    public int _missChance;
    public int _bashChance;
    public float _attackRange = 0.6f;
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

    public Animator _animatorController;
    public Rigidbody2D _rigidBody;

    public Joystick _joystick;
    public Button _attackButton;

    public DirectionState _directionState = DirectionState.Right;
    public Vector2 _moveDerection;
    public Vector2 _moveVelocity;
    public Transform _playerPosition;

    public float _attackCooldown = 0f;
    private LayerMask _enemyLayer;
    private LayerMask _playerLayer;
    
    public string _nickname = "Character";

    public float _stunDuration = 2f;

    public bool _isPlayer = true;
    public bool _isDead = false;


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
            _critChance = _character._critChance + _upgradedStats.GetCritChance();
            _missChance = _character._missChance + _upgradedStats.GetMissChance();
            _bashChance = _character._bashChance + _upgradedStats.GetBashChance();
            _currentHealth = _maxHealth;
        }
        else
        {
            int randomHealth = Random.Range(1, 6);
            if(randomHealth == 2) _maxHealth += 200;
            else if(randomHealth == 3) _maxHealth += 400;
            else if (randomHealth == 4) _maxHealth += 600;
            else if (randomHealth == 5) _maxHealth += 800;
            else if (randomHealth == 6) _maxHealth += 1000;

            int randomDamage = Random.Range(1, 6);
            if (randomDamage == 2) _maxHealth += 5;
            else if (randomDamage == 3) _damage += 10;
            else if (randomDamage == 4) _damage += 15;
            else if (randomDamage == 5) _damage += 20;
            else if (randomDamage == 6) _damage += 25;

            _speed += Random.Range(0, 5);
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
