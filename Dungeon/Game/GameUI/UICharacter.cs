using Dungeon.Char;

namespace Dungeon.UserInterface
{
    public class UICharacter
    {
        public UIMoveset Moveset { get; set; }
        public UICharacter()
        {
            Moveset = new UIMoveset();
        }

        public void DisplayBaseStats(Character character)
        {
            string stats = $"---Stats---\nHealth: {character.Stats.Health.BaseStat.Value}\nAttack: {character.Stats.Attack.BaseStat.Value}" +
            $"\nDefense: {character.Stats.Defense.BaseStat.Value}\nSpeed: {character.Stats.Speed.BaseStat.Value}";
            DisplayName(character);
            Console.WriteLine(stats);
        }

        public void DisplayStats(Character character)
        {
            string stats = ($"---Stats---\nHealth: {character.Stats.Health.Stat.Value}\nAttack: {character.Stats.Attack.Stat.Value}" +
            $"\nDefense: {character.Stats.Defense.Stat.Value}\nSpeed: {character.Stats.Speed.Stat.Value}");
            DisplayName(character);
            Console.WriteLine(stats);
            DisplayStatStages(character);
            Console.WriteLine("\n");
        }

        public void DisplayStatStages(Character character)
        {
            if (character.Stats.Attack.Stat.Multiplier.Stage != 0)
            {
                Console.WriteLine($"Attack Stage: {character.Stats.Attack.Stat.Multiplier.Stage}");
            }
            if (character.Stats.Defense.Stat.Multiplier.Stage != 0)
            {
                Console.WriteLine($"Defense Stage: {character.Stats.Defense.Stat.Multiplier.Stage}");
            }
            if (character.Stats.Speed.Stat.Multiplier.Stage != 0)
            {
                Console.WriteLine($"Speed Stage: {character.Stats.Speed.Stat.Multiplier.Stage}");
            }
        }

        public void DisplayInventory(Character character)
        {
            string inv = $"---Inventory---\nItem: {character.Inventory.Item.Name}";
            DisplayName(character);
            Console.WriteLine(inv);
        }

        public void DisplayName(Character character)
        {
            Console.WriteLine(character.Name);
        }

    }
}
