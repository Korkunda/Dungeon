namespace Dungeon.Char;

public class Defense : CharStat
{
    public Defense(IStat baseStat, MultiplierStat stat, string name) : base(baseStat, stat, name)
    {
        BaseStat = baseStat;
        Stat = stat;
        Name = name;
    }

}
