
using System.Data;

namespace Dungeon.UserInterface
{
    public class UI
    {
        public UIBattle Battle { get; set; }
        public UICharacter Character { get; set; }

        public UIMessages Messages { get; set; }
        public GenericInput Input { get; set; }

        public UI()
        {
            Input = new GenericInput();
            Character = new UICharacter();
            Messages = new UIMessages();
            Battle = new UIBattle(Input,Character,Messages);
        }

        public static void ClearScr()
        {
            Console.Clear();
        }

        public static void WaitAndClearScr()
        {
            var tmr = new System.Timers.Timer();
            tmr.Interval = 1000;
            tmr.Elapsed += TimeElapsedEvent;
            tmr.AutoReset = false;
            tmr.Enabled = true;
        }

        public static void TimeElapsedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            ClearScr();
        }
    }
}
