using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class StatusClear : IEffect
{
    public bool AffectsSelf {get;set;}  
    public bool AffectsOpponent {get;set;}

    public void UseEndOfTurnEffect(Character character, UIBattle uiBattle, string moveType)
    {}

    public bool UseImmediateEffect(Character character, UIBattle uiBattle, string moveType)
    {

        character.BattleState!.Effects.EffectList.Clear();
        uiBattle.Messages.EffectMsg(character.Name, "was cured of all status effects!");

        return true;
    }
}
