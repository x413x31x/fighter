using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isWalking", false);
        character._animatorController.SetBool("isAttack", false);

        character._attackButton.interactable = true;

        Debug.LogWarning("Hello from IdleState!");
    }

    public override void UpdateState(CharacterStateManager character)
    {
        character._moveDerection = new Vector2(character._joystick.Horizontal, character.transform.position.y);
        if (character._moveDerection.x != 0)
        {
            character.SwitchState(character._walkingState);
        }
    }

    public override void OnCollisionEnter(CharacterStateManager character)
    {

    }

}
