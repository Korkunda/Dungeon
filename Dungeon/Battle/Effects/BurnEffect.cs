using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class BurnEffect : EndOfTurnEffect, IStatusEffect
{
    public BurnEffect(bool affectsSelf, bool affectsOpponent)
    {
        TurnsLeftOfEffect = -1;
        AffectsSelf = affectsSelf;
        AffectsOpponent = affectsOpponent;
    }

    public override bool UseImmediateEffect(Character character, UIBattle uiBattle, string moveType)
    {
        bool effectWorked = character.BattleState!.Effects.AddEffects(this);

        if (effectWorked)
        {
            uiBattle.Messages.EffectMsg(character.Name, "was burned!");
        }
        else if(!effectWorked && moveType != Enum.GetName((Categories)0))
        {
            uiBattle.Messages.EffectMsg(character.Name, "is already burnt!");
        }
        bool alreadyStatused = character.BattleState.Effects.EffectList.Any(e => e is IStatusEffect);

        return effectWorked;
    }

    public override void UseEndOfTurnEffect(Character character, UIBattle uiBattle, string moveType)
    {
        int dmg = Convert.ToInt32(character.Stats.Health.BaseStat.Value * 0.08);
        character.Stats.TakeDamage(dmg);
        uiBattle.Messages.EffectMsg(character.Name, "is hurt by its burn.");
    }
}

