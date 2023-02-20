using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class NoEffect : IEffect
{
    public bool AffectsSelf {get;set;}
    public bool AffectsOpponent { get; set; }
    public int TurnsLeftOfEffect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void DecrementTurnsLeft()
    {}
}
