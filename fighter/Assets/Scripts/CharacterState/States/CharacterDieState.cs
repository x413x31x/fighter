using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDieState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character.CurrentAnimation("isDead");
    }

    public override void UpdateState(CharacterStateManager character)
    {
        
    }

    public override void OnCollisionEnter(CharacterStateManager character)
    {
        
    }
}
