using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStunState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isStun", true);
        if (character._isPlayer)
        {
            character._attackButton.interactable = false;
        }
    }

    public override void UpdateState(CharacterStateManager character)
    {
        if (character._stunDuration <= 0)
        {
            character._stunDuration = 2f;
            character.SwitchState(character._idleState);
        }
        else
        {
            character._stunDuration -= Time.deltaTime;
        }
    }

    public override void ExitState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isStun", false);
        if (character._isPlayer)
        {
            character._attackButton.interactable = true;
        }
    }
}
