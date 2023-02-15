using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public abstract class EndOfTurnEffect : IEffect
{
    public abstract void UseEndOfTurnEffect(Character character, UIBattle uiBattle, string moveType);

    public int TurnsLeftOfEffect { get; set; }
    public bool AffectsSelf { get; set; }
    public bool AffectsOpponent { get; set; }   

    public void DecrementTurnsLeft()
    {
        TurnsLeftOfEffect --;
    }

    public abstract bool UseImmediateEffect(Character character, UIBattle uiBattle, string moveType);
}
