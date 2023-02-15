namespace Dungeon.Char;

public class Health : CharStat
{
    public Health(IStat baseStat, MultiplierStat stat, string name) : base(baseStat, stat, name)
    {
        BaseStat = baseStat;
        Stat = stat;
        Name = name;
    }

}
