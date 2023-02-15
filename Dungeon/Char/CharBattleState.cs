using Dungeon.Battling;
using Dungeon.Char;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Char;

public class CharBattleState
{

    //add a property to hold the effects

    public Effects Effects { get; set; }
    


    public CharBattleState()
    {
        //initialise Effects to empty list

        Effects = new Effects();
        
    }

}
