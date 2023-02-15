namespace Dungeon.Char;

public class CharStat
{
    public IStat BaseStat { get; set; }
    public MultiplierStat Stat { get; set; }

    public string Name { get; set; }

    public CharStat(IStat baseStat, MultiplierStat stat, string name)
    {
        BaseStat = baseStat;
        Stat = stat;
        Name = name;
    }
    public void RaiseLowerBaseStat(int amount)
    {
        if(BaseStat.Value + amount <= 0)
        {
            Console.WriteLine("Stat cannot go any lower!");
        }
        else
        {
            BaseStat.Value += amount;
        }

    }

    public void ResetStat()
    {
        Stat.Value = BaseStat.Value;
    }

}
