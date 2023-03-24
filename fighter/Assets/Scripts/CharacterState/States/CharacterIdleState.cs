using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        
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

    }

    private void Player(CharacterStateManager character)
    {
        character._moveDerection = new Vector2(character._joystick.Horizontal, character.transform.position.y);
        if (character._moveDerection.x != 0)
        {
            character.SwitchState(character._walkingState);
        }
    }

    private void Enemy(CharacterStateManager character)
    {
        character.SwitchState(character._walkingState);
    }
}
