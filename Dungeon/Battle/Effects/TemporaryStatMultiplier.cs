using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class TemporaryStatMultiplier : IEffect, IEndOfTurnEffect, IImmediateEffect
{
    public string StatName { get; set; }
    public double Multiplier { get; set; }
    public bool AffectsSelf { get; set; }
    public bool AffectsOpponent { get; set; }
    public int TurnsLeftOfEffect { get; set; }

    public TemporaryStatMultiplier(bool affectsSelf, bool affectsOpponent, string stat, int turns, double multiplier)
    {
        TurnsLeftOfEffect = turns;
        AffectsSelf = affectsSelf;
        AffectsOpponent = affectsOpponent;
        StatName = stat;
        Multiplier = multiplier;
    }

    public void UseEndOfTurnEffect(BattleChar user, UIBattle uiBattle, string moveType)
    {
        DecrementTurnsLeft();
        if(TurnsLeftOfEffect == 0)
        {
            switch (StatName.ToLower())
            {
                case "attack":
                    user.AttackMult -= Multiplier;
                    break;
                case "defense":
                    user.DefenseMult -= Multiplier;
                    break;
                case "speed":
                    user.SpeedMult -= Multiplier;
                    break;
            }
        }
    }

    public bool UseImmediateEffect(BattleChar character, UIBattle uiBattle, string moveType)
    {
        bool alreadyEffected = character.Character.BattleState!.Effects.EffectList.Any(e => e is TemporaryStatMultiplier);

        if (!alreadyEffected)
        {

            bool effectWorked = character.Character.BattleState!.Effects.AddEffects(this);


            switch (StatName.ToLower())
            {
                case "attack":
                    character.AttackMult += Multiplier;
                    break;
                case "defense":
                    character.DefenseMult += Multiplier;
                    break;
                case "speed":
                    character.SpeedMult += Multiplier;
                    break;
            }

            return effectWorked;
        }
        return false;     
    }


    public void DecrementTurnsLeft()
    {
        TurnsLeftOfEffect--;
    }
}
