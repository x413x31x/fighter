using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkingState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isWalking", true);
        character._attackButton.interactable = false;

        Debug.LogWarning("Hello from WalkingState!");
    }

    public override void UpdateState(CharacterStateManager character)
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

    public override void OnCollisionEnter(CharacterStateManager character)
    {

    }

}
