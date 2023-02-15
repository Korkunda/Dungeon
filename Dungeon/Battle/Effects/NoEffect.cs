using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class NoEffect : IEffect
{
    public bool AffectsSelf {get;set;}
    public bool AffectsOpponent { get; set; }

    public void UseEndOfTurnEffect(Character character, UIBattle uiBattle, string moveType)
    {
    }

    public bool UseImmediateEffect(Character character, UIBattle uiBattle, string moveType)
    {
        return true;
    }
}
