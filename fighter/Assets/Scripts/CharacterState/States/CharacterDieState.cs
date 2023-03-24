using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDieState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isDead", true);
        if (character._isPlayer)
        {
            character._attackButton.interactable = false;
        }
    }

    public override void UpdateState(CharacterStateManager character)
    {
        
    }

    public override void ExitState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isDead", false);
    }
}
