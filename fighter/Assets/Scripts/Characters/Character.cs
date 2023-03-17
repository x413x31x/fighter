using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Joystick _joystick;
    protected Animator _animatorController;
    protected Rigidbody2D _rigidBody;

    protected DirectionState _directionState = DirectionState.Right;
    protected Vector2 _moveDerection;
    protected Vector2 _moveVelocity;

    [SerializeField] protected Transform _attackPoint;
    [SerializeField] protected float _attackRange = 0.5f;
    [SerializeField] protected LayerMask _enemyLayers;

    protected int _speed = 5;
    private int _maxHealth = 100;
    private int _currentHealth;
    protected int damage = 21;

    private void Start()
    {
        InitFields();
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        MoveController();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackController();
        }
    }

    private void InitFields()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
        _joystick = GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<Joystick>();
    }

    protected abstract void MoveController();

    protected abstract void AttackController();

    public void TakenDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.LogWarning("Y kill me! Kheeeee");
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

    protected void FlipCharacter()
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

    protected enum DirectionState
    {
        Right,
        Left,
    }
}
