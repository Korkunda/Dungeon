namespace Dungeon.Char;

public class Attack : CharStat
{
    public Attack(IStat baseStat, MultiplierStat stat, string name) : base(baseStat, stat, name)
    {
        BaseStat = baseStat;
        Stat = stat;
        Name = name;
    }

}
