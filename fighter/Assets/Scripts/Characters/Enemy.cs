using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private GameObject _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Attack()
    {
        
    }

    protected override void MoveController()
    {
        _moveDerection = new Vector2(_target.transform.position.x, transform.position.y);
        _moveVelocity = _moveDerection * _speed;

        if (_moveDerection.x == 0)
        {
            _animatorController.SetBool("isWalking", false);
        }
        else
        {
            _animatorController.SetBool("isWalking", true);
        }

        if (_directionState == DirectionState.Left && _moveDerection.x > 0)
        {
            FlipCharacter();
        }
        else if (_directionState == DirectionState.Right && _moveDerection.x < 0)
        {
            FlipCharacter();
        }
        _rigidBody.MovePosition(_rigidBody.position + _moveVelocity * Time.deltaTime);
    }
}
