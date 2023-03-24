using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStunState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character.CurrentAnimation("isStun");
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

    public override void OnCollisionEnter(CharacterStateManager character)
    {
    }
}
