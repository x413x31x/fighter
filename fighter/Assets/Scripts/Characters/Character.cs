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

    protected int _speed = 5;


    private void Awake()
    {
        InitFields();
    }

    private void Update()
    {
       // MoveController();
    }

    private void InitFields()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
        _joystick = GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<Joystick>();
    }

    protected abstract void MoveController();

    public abstract void Attack();

    public void TakenDamage(int damage)
    {
        Debug.LogWarning("you attacked - ");
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
