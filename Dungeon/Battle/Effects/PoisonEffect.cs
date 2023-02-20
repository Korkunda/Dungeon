using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class PoisonEffect : IStatusEffect, IEndOfTurnEffect, IImmediateEffect
{
    public bool AffectsSelf { get; set; }
    public bool AffectsOpponent { get; set; }
    public int TurnsLeftOfEffect { get; set; }

    public PoisonEffect(bool affectsSelf, bool affectsOpponent)
    {
        TurnsLeftOfEffect = -1;
        AffectsSelf = affectsSelf;
        AffectsOpponent = affectsOpponent;
    }

    public bool UseImmediateEffect(BattleChar character, UIBattle uiBattle, string moveType)
    {
        bool alreadyStatused = character.Character.BattleState!.Effects.EffectList.Any(e => e is IStatusEffect);

        if (!alreadyStatused)
        {
            bool effectWorked = character.Character.BattleState!.Effects.AddEffects(this);

            if (effectWorked)
            {
                uiBattle.Messages.EffectMsg(character.Character.Name, "was poisoned!");
            }
            else if (!effectWorked && moveType != Enum.GetName((Categories)0))
            {
                uiBattle.Messages.EffectMsg(character.Character.Name, "is already poisoned!");
            }

            return effectWorked;
        }

        return false;
    }

    public void UseEndOfTurnEffect(BattleChar character, UIBattle uiBattle, string moveType)
    {
        int dmg = Convert.ToInt32(character.Character.Stats.Health.BaseStat.Value * 0.08);
        character.Character.Stats.TakeDamage(dmg);
        uiBattle.Messages.EffectMsg(character.Character.Name, "is hurt by poison.");
    }

    public int UseDamagePhaseEffect(BattleChar character, UIBattle uiBattle, Move moveUsed)
    {
        throw new NotImplementedException();
    }

    public void DecrementTurnsLeft()
    {
        throw new NotImplementedException();
    }
}

