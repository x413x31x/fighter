using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character.CurrentAnimation("isAttack");
        character._attackButton.interactable = false;
        character._attackCooldown = character._baseAttackTime;
    }

    public override void UpdateState(CharacterStateManager character)
    {
        if(character._attackCooldown <= 0)
        {
            character.SwitchState(character._idleState);
        }
        else
        {
            character._attackCooldown -= Time.deltaTime;
        }
    }

    public override void OnCollisionEnter(CharacterStateManager character)
    {
    }
}