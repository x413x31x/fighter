using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkingState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isWalking", true);
        if (character._isPlayer)
        {
            character._attackButton.interactable = false;
        }
    }

    public override void UpdateState(CharacterStateManager character)
    {
        if (character._isPlayer)
        {
            Player(character);
        }
        else
        {
            Enemy(character);
        }
    }

    public override void ExitState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isWalking", false);
        if (character._isPlayer)
        {
            character._attackButton.interactable = true;
        }
    }

    private void Player(CharacterStateManager character)
    {
        character._moveDerection = new Vector2(character._joystick.Horizontal, character.transform.position.y);
        character._moveVelocity = character._moveDerection * character._speed;
        if (character._moveDerection.x == 0)
        {
            character.SwitchState(character._idleState);
        }

        if (character._directionState == CharacterStateManager.DirectionState.Left && character._moveDerection.x > 0)
        {
            character.FlipCharacter();
        }
        else if (character._directionState == CharacterStateManager.DirectionState.Right && character._moveDerection.x < 0)
        {
            character.FlipCharacter();
        }
        character._rigidBody.MovePosition(character._rigidBody.position + character._moveVelocity * Time.deltaTime);
    }

    private void Enemy(CharacterStateManager character)
    {
        Vector2 targetPosition = new Vector2(character._target.position.x, character._rigidBody.position.y);
        Vector2 newPosition = Vector2.MoveTowards(character._rigidBody.position, targetPosition, character._speed * Time.deltaTime);
        character._rigidBody.MovePosition(newPosition);
        if(Vector2.Distance(character._target.position, character._attackPoint.position) <= 1)
        {
            character.SwitchState(character._attackState);
        }
    }
}
