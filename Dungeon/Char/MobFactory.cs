using Dungeon.CharInventory;

namespace Dungeon.Char
{
    public static class MobFactory
    {

        public static Mob CreateMob(int id)
        {
            switch(id)
            {
                default:
                    return GenerateMobObj("xqc", 100, 20, 40, 50, 1000000, 2, new List<int>() { 1, 2, 3, 4 });
                case 0:
                    return GenerateMobObj("Cow", 200, 30, 60, 10, 0, 1, new List<int>() { 1, 2 });
                case 1:
                    return GenerateMobObj("Dog", 60, 70, 40, 110, 0, 0, new List<int>() { 0 });
                case 2:
                    return GenerateMobObj("Spiky", 50, 40, 200, 5, 0, 2, new List<int>() { 1 });
                case 3:
                    return GenerateMobObj("Blue-Eyed Lizard", 90, 75, 40, 95, 0, 0, new List<int>() { 1, 2, 7, 8 });
                case 4:
                    return GenerateMobObj("Skeleton", 100, 50, 50, 50, 0, 0, new List<int>() { 3, 4, 10, 5 });
                case 5:
                    return GenerateMobObj("Punching Bag", 500, 0, 50, 0, 0, 0, new List<int>() { 19 });
            }
        }
        public static Mob CreateRandomMob()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 5);
            return CreateMob(randomNumber);
        }

        private static Mob GenerateMobObj(string name, int health, int attack, int defense, int speed, int gold, int itemID, List<int> moveIds)
        {
            return new Mob(name, new Stats(health,attack,defense,speed), InventoryGenerator.CreateInventory(gold, itemID),new Moveset(moveIds));
        }
    }
}
