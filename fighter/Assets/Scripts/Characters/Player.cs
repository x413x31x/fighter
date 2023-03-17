using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected override void MoveController()
    {
        _moveDerection = new Vector2(_joystick.Horizontal, transform.position.y);
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

    protected override void AttackController()
    {
        _animatorController.SetTrigger("isAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakenDamage(damage);
        }
    }
}
