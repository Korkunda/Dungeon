using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class RaiseStats : IEffect, IImmediateEffect
{
    public bool AffectsSelf { get; set; }
    public bool AffectsOpponent { get; set; }
    public string StatName { get; set; }
    public int Stage { get; set; }
    public int TurnsLeftOfEffect { get; set; }

    public RaiseStats(bool affectsSelf, bool affectsOpponent, string stat, int stage)
    {
        AffectsSelf = affectsSelf;
        AffectsOpponent = affectsOpponent;
        StatName = stat;
        Stage = stage;
    }

    public bool UseImmediateEffect(BattleChar character, UIBattle uiBattle, string moveType)
    {
        switch (StatName.ToLower())
        {
            case "attack":
                validateStat(character.Character, character.Character.Stats.Attack, uiBattle);
                break;
            case "defense":
                validateStat(character.Character, character.Character.Stats.Defense, uiBattle);
                break;
            case "speed":
                validateStat(character.Character, character.Character.Stats.Speed, uiBattle);
                break;
        }

        return true;
    }

    private void validateStat(Character character, CharStat stat, UIBattle uiBattle)
    {
        if(stat.Stat.Multiplier.Stage == 6)
        {
            uiBattle.Messages.StatCannotGoHigher(character.Name, stat.Name);
        }
        else if (stat.Stat.Multiplier.Stage == -6)
        {
            uiBattle.Messages.StatCannotGoLower(character.Name, stat.Name);
        }
        else
        {
        }

        character.Stats.RaiseLowerStats(stat, Stage);
    }

    public void DecrementTurnsLeft()
    {
        throw new NotImplementedException();
    }
} 