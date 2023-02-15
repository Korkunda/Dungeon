using Dungeon.Char;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.UserInterface
{
    public class UIMoveset
    {
        public UIMoveset() { }
        public string ReturnMovesetList(Moveset moveset)
        {
            string movesetList = "";

            for (int i = 0; i < moveset.Moves.Count; i++)
            {
                movesetList += $"{i + 1} - {moveset.Moves[i].Name}\n";
            }
            return movesetList;
        }

        public void DisplayMovesetList(Moveset moveset) {
            Console.WriteLine(ReturnMovesetList(moveset));
        }
    }


}
