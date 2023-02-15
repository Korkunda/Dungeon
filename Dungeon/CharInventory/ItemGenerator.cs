namespace Dungeon.CharInventory
{
    public static class ItemGenerator
    {
        public static Item CreateItem(int id)
        {
            string name;
            switch (id)
            {
                default:
                    name = "dust";
                    break;
                case 0:
                    name = "apple";
                    break;
                case 1:
                    name = "carrot";
                    break;
                case 2:
                    name = "coke";
                    break;
            }
            return new Item(name);
        }

        public static Item CreateRandomItem()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 2);
            return CreateItem(randomNumber);
        }
    }
}
