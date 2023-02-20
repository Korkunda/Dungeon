using Dungeon.Char;

namespace Dungeon.UserInterface
{
    public class UIMessages
    {
        public UIMessages() { }

        public void CharFainted(Character character)
        {
            Console.WriteLine($"{character.Name} fainted!");
        }

        public void UsedMove(Character character, Move move)
        {
            Console.WriteLine($"{character.Name} used {move.Name}");
        }
        public void UsedButItMissed(Character character, Move move)
        {
            UsedMove(character, move);
            Console.WriteLine("But it missed!");
        }

        public void ButItFailed()
        {
            Console.WriteLine("But it failed!");
        }

        public void DmgDealt(int dmg)
        {
            Console.WriteLine($"It did {dmg} damage!");
        }

        public void AmountHealed(int heal)
        {
            Console.WriteLine($"It healed {heal} pts!");
        }

        public void BattleStartMsg(Character character)
        {
            Console.WriteLine($"Battle begins. A wild {character.Name} appears.");
        }

        public void EffectMsg(string name, string msg)
        {
            Console.WriteLine($"{name} {msg}");
        }

        public void StatCannotGoHigher(string charName, string statName)
        {
            Console.WriteLine($"{charName}'s {statName} cannot go any higher!");
        }
        public void StatCannotGoLower(string charName, string statName)
        {
            Console.WriteLine($"{charName}'s {statName} cannot go any lower!");
        }

        public void EffectEnded(string charName, string effectName)
        {
            Console.WriteLine($"{charName}'s {effectName} ended.");
        }

    }
}
