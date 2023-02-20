using Dungeon.Char;
using Dungeon.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Battling
{
    public interface IEndOfTurnEffect : IEffect
    {
        void UseEndOfTurnEffect(BattleChar character, UIBattle uIBattle, string moveType);
    }
}
