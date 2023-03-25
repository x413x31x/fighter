using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStateManager : MonoBehaviour
{
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
    [SerializeField] public Transform _attackPoint;
    [SerializeField] public float _attackRange = 0.6f;
    public float _baseAttackTime = 0.5f;

    public string _nickname = "Character";
    private int _chance = 25;
    public int _speed = 5;
    private int _damage = 20;
    public float _maxHealth = 1000;

    public float _currentHealth;
    public float _stunDuration = 2f;

    public bool _isPlayer = true;


    private void Start()
    {
        Init();
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

        _currentHealth = _maxHealth;
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
        if(randomMiss <= _chance)
        {
            Instantiate(_wordOnMiss, transform.position, Quaternion.identity);
            return;
        }

        int randomBash = Random.Range(0, 100);
        if(randomBash <= _chance)
        {
            Instantiate(_wordOnBash, transform.position, Quaternion.identity);
            SwitchState(_stunState);
        }

        int randomCrit = Random.Range(0, 100);
        if(randomCrit <= _chance)
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
