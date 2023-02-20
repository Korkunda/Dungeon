namespace Dungeon.Char;

public class Stats
{
    public Health Health;
    public Attack Attack;
    public Defense Defense;
    public Speed Speed; 



    public Stats(int hp, int atk, int def, int spd)
    {
        Health = new Health(new NonMultiplierStat(hp), new MultiplierStat(hp), "Health");
        Attack = new Attack(new NonMultiplierStat(atk), new MultiplierStat(atk), "Attack");
        Defense = new Defense(new NonMultiplierStat(def), new MultiplierStat(def), "Defense");
        Speed = new Speed(new NonMultiplierStat(spd), new MultiplierStat(spd), "Speed");
    }


    public void TakeDamage(int dmg)
    {
        if (Health.Stat.Value - dmg <= 0)
        {
            Health.Stat.Value = 0;
        } else 
        {
            Health.Stat.Value -= dmg;
        }
    }

    public int Heal(int val)
    {
        int amountHealed;

        //calc amount healed
        if(Health.Stat.Value + val >= Health.BaseStat.Value)
        {
            amountHealed = Health.BaseStat.Value - Health.Stat.Value;
        }
        else
        {
            amountHealed = val;
        }

        // do healing
        if (Health.Stat.Value + val >= Health.BaseStat.Value)
        {
            Health.Stat.Value = Health.BaseStat.Value;
        }
        else
        {
            Health.Stat.Value += val;
        }


        return amountHealed;
    }

    public void ClearStats()
    {
        Attack.Stat.Value = Attack.BaseStat.Value;
        Defense.Stat.Value = Defense.BaseStat.Value;
        Speed.Stat.Value = Speed.BaseStat.Value;
        Attack.Stat.Multiplier.ResetMultiplier();
        Defense.Stat.Multiplier.ResetMultiplier();
        Speed.Stat.Multiplier.ResetMultiplier();
    }

    public void ResetStats()
    {
        Health.Stat.Value = Health.BaseStat.Value;
        ClearStats(); 
    }

    public void RaiseLowerStats(CharStat charStat, int stages)
    {
        charStat.Stat.Multiplier.RaiseLowerStage(stages);
        double result = charStat.BaseStat.Value * charStat.Stat.Multiplier.Value;
        charStat.Stat.Value = Convert.ToInt32(Math.Round(result));
    }

    public bool isAlive()
    {
        if(Health.Stat.Value == 0)
        {
            return false;
        }
        return true;
    }
}

