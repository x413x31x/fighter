using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStateManager : MonoBehaviour
{
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

    public int _speed = 5;

    public float _baseAttackTime = 0.5f;
    public float _attackCooldown = 0f;
    private Transform _attackPoint;
    private LayerMask _enemyLayer;
    private float _attackRange = 0.6f;


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
        _joystick = GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<Joystick>();
        _attackButton = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Button>();
        _attackPoint = transform.Find("AttackPoint");
        _enemyLayer = LayerMask.NameToLayer("Water"); //magic layers))
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(CharacterBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }

    public void Attack()
    {
        _currentState = _attackState;
        _currentState.EnterState(this);
    }

    private void OnAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakenDamage(25);
        }
    }

    public void TakenDamage(int damage)
    {
        //SOON
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
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
