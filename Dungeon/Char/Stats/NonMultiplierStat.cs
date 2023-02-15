namespace Dungeon.Char;

public class NonMultiplierStat : IStat
{
    public int Value {get; set;}

    public NonMultiplierStat(int value)
    {
        Value = value;
    }
}
