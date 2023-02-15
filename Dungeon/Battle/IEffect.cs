using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public interface IEffect
{
    bool AffectsSelf { get; set; }
    bool AffectsOpponent { get; set; }

    bool UseImmediateEffect(Character character, UIBattle uiBattle,string moveType);

    void UseEndOfTurnEffect(Character character, UIBattle uIBattle,string moveType);
}
