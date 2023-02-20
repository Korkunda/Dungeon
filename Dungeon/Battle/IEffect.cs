using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public interface IEffect
{
    bool AffectsSelf { get; set; }
    bool AffectsOpponent { get; set; }

    public int TurnsLeftOfEffect { get; set; }

    void DecrementTurnsLeft();

}
