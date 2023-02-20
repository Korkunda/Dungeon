using Dungeon.Char;
using Dungeon.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Battling
{
    public interface IImmediateEffect : IEffect
    {
        bool UseImmediateEffect(BattleChar character, UIBattle uiBattle, string moveType);
    }
}
