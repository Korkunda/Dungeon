using Dungeon.Char;

namespace Dungeon.UserInterface;

public class GenericInput
{
    public GenericInput()
    {

    }
    
    public int OptionsInput(string msg, int min, int max)
    {
        Console.WriteLine(msg);
        string input;

        while (true)
        {
            input = Console.ReadLine()!;
            try
            {
                if (input.Trim() != "" && (Convert.ToInt32(input) >= min && Convert.ToInt32(input) <= max))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }catch(FormatException) 
            {
                Console.WriteLine("Invalid input");
            }

            
        }

        return (Convert.ToInt32(input));
    }
}
