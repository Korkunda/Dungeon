using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class StatusClear : IEffect, IImmediateEffect
{
    public bool AffectsSelf {get;set;}  
    public bool AffectsOpponent {get;set;}
    public int TurnsLeftOfEffect { get; set; }

    public StatusClear(bool affectsSelf, bool affectsOpponent) {
        AffectsSelf = affectsSelf;
        AffectsOpponent = affectsOpponent;
        TurnsLeftOfEffect = -1;
    }

    public void DecrementTurnsLeft()
    {}
    public bool UseImmediateEffect(BattleChar character, UIBattle uiBattle, string moveType)
    {

        character.Character.BattleState!.Effects.EffectList.Clear();
        uiBattle.Messages.EffectMsg(character.Character.Name, "was cured of all status effects!");

        return true;
    }

}
