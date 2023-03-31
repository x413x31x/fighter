
public class CharacterDieState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isDead", true);
        if (character._isPlayer)
        {
            character._attackButton.interactable = false;
        }
        character._isDead = true;
    }

    public override void UpdateState(CharacterStateManager character)
    {
        
    }

    public override void ExitState(CharacterStateManager character)
    {
        character._animatorController.SetBool("isDead", false);
    }
}
