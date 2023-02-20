using Dungeon.Char;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Battling
{
    public class BattleChar
    {
        public Character Character { get; set; }

        public double HealthMult { get; set; }
        public double AttackMult { get; set; }
        public double DefenseMult { get; set; }
        public double SpeedMult { get; set; }
        public int Health { get { return Convert.ToInt32(Character.Stats.Health.Stat.Value * HealthMult); } }
        public int Attack { get { return Convert.ToInt32(Character.Stats.Attack.Stat.Value * AttackMult); } }
        public int Defense { get { return Convert.ToInt32(Character.Stats.Defense.Stat.Value * DefenseMult); } }
        public int Speed { get { return Convert.ToInt32(Character.Stats.Speed.Stat.Value * SpeedMult); } }

        public BattleChar(Character character)
        {
            Character = character;
            HealthMult = 1;
            AttackMult = 1;
            DefenseMult = 1;
            SpeedMult = 1;
        }

        public void ResetMults()
        {
            HealthMult = 1;
            AttackMult = 1;
            DefenseMult = 1;
            SpeedMult = 1;
        }

    }
}
