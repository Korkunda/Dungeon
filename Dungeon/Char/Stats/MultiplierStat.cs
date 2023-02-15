namespace Dungeon.Char;

public class MultiplierStat : IStat
{
    public Multiplier Multiplier { get; set; }
    public int Value { get; set; }

    public MultiplierStat(int value)
    {
        Value = value;
        Multiplier = new Multiplier();
    }





}
