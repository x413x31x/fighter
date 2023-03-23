using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] protected Transform _attackPoint;
    [SerializeField] protected LayerMask _enemyLayer;
    [SerializeField] protected float _attackRange;

    [SerializeField] private float _attackRate = 4f;
    private float _nextAttackTime = 0f;

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

    public override void Attack()
    {
        if(Time.time >= _nextAttackTime)
        {
            _animatorController.SetTrigger("isAttack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Character>().TakenDamage(25);
            }
            _nextAttackTime = Time.time + 1f / _attackRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange); 
    }
}
