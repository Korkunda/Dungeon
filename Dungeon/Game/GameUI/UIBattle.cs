using Dungeon.Char;

namespace Dungeon.UserInterface
{
    public class UIBattle
    {
        GenericInput Input { get; set; }
        public UICharacter Character { get; set; }
        public UIMessages Messages { get; set; }   
        public UIBattle(GenericInput input, UICharacter character, UIMessages messages)
        {
            Input = input;
            Character = character;
            Messages = messages;
        }

        //MOVES
        public int ReturnRandomMove(Moveset moveset)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, moveset.GetMovesetSize());
            int moveIndex = number - 1;
            return moveIndex;
        }
        public int InputMove(Moveset moveset)
        {
            string movesetList = Character.Moveset.ReturnMovesetList(moveset);
         
            int move = Input.OptionsInput($"Select your move: \n{movesetList}", 1, moveset.GetMovesetSize());

            int moveIndex = move - 1;
            return moveIndex;

        }

        //EVENTS
        public void DisplayTurn(int turn)
        {
            Console.WriteLine($"Turn {turn}");
        }

        public void DisplayCharHealth(Character character)
        {
            Console.WriteLine($"{character.Name} health: {character.Stats.Health.Stat.Value}");
        }


    }
}
