using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character.CurrentAnimation();
        character._attackButton.interactable = true;
    }

    public override void UpdateState(CharacterStateManager character)
    {
        if (character._isPlayer)
        {
            character._moveDerection = new Vector2(character._joystick.Horizontal, character.transform.position.y);
            if (character._moveDerection.x != 0)
            {
                character.SwitchState(character._walkingState);
            }
        }
    }

    public override void OnCollisionEnter(CharacterStateManager character)
    {

    }

}
