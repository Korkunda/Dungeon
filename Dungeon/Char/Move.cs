using Dungeon.Battling;

namespace Dungeon.Char;

public class Move
{

    public string Name { get; private set; }
    public int Damage { get; set; }
    public string Type { get; set; }
    public int Category { get; set; }
    public List<IEffect> Effects { get; set; }


    public Move(string name, int dmg, string type, int category, List<IEffect> effects)
    {
        Name = name;
        Damage = dmg;
        Type = type;
        Category = category;
        Effects = effects;
    }
}