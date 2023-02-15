namespace Dungeon.Char;

public class Speed : CharStat
{
    public Speed(IStat baseStat, MultiplierStat stat, string name) : base(baseStat, stat, name)
    {
        BaseStat = baseStat;
        Stat = stat;
        Name = name;
    }

}
