using Dungeon.Battling;

namespace Dungeon.Char;

public static class MoveFactory
{

    public static Move CreateMove(int id)
    {
        switch (id)
        {
            default:
                return GenerateMove("Struggle", 10, "Normal",0, new List<IEffect>() { new NoEffect() });
            case 0:
                return GenerateMove("Bite", 60, "Normal",0, new List<IEffect>() { new NoEffect() });
            case 1:
                return GenerateMove("Tackle", 60, "Normal",0, new List<IEffect>() { new NoEffect() });
            case 2:
                return GenerateMove("Headbutt", 60, "Normal",0, new List<IEffect>() { new NoEffect() });
            case 3:
                return GenerateMove("Slash", 70, "Normal",0, new List<IEffect>() { new NoEffect() });
            case 4:
                return GenerateMove("Punch", 60, "Normal",0, new List<IEffect>() { new NoEffect() });
            case 5:
                return GenerateMove("Kick", 70, "Normal",0, new List<IEffect>() { new NoEffect() });
            case 6:
                return GenerateMove("Venom Fang", 65, "Poison",0, new List<IEffect>() { new NoEffect() });
            case 7:
                return GenerateMove("Water Splash", 60, "Water",0, new List<IEffect>() { new NoEffect() });
            case 8:
                return GenerateMove("Water Bullet", 80, "Water",0, new List<IEffect>() { new NoEffect() });
            case 9:
                return GenerateMove("Recover", 50, "Normal", 1, new List<IEffect>() { new NoEffect() });
            case 10:
                return GenerateMove("Sharpen", 0, "Metal", 2, new List<IEffect>() { new RaiseStats(true, false, "attack", 2) });
            case 11:
                return GenerateMove("Acid Rain", 0, "Poison", 2, new List<IEffect>() { new NoEffect()});
            case 12:
                return GenerateMove("Flamethrower", 80, "Fire ", 0, new List<IEffect>() { new BurnEffect(false, true) });
            case 13:
                return GenerateMove("Will-O-Wisp", 0, "Fire ", 2, new List<IEffect>() { new BurnEffect(false, true) });
            case 14:
                return GenerateMove("Swords Dance", 0, "Metal", 2, new List<IEffect>() { new RaiseStats(true, false, "attack", 2) });
            case 15:
                return GenerateMove("Curl", 0, "Normal", 2, new List<IEffect>() { new RaiseStats(true, false, "defense", 1) });
            case 16:
                return GenerateMove("Warm Up", 0, "Normal", 2, new List<IEffect>() { new RaiseStats(true, false, "defense", 1), 
                new RaiseStats(true, false, "attack", 1), new RaiseStats(true, false, "speed", 1) });
            case 17:
                return GenerateMove("Wind Wall", 0, "Air", 2, new List<IEffect>() { new TemporaryStatMultiplier(true, false, "defense", 3, 0.5) });
            case 18:
                return GenerateMove("Autophagy", 100, "Normal", 1, new List<IEffect>() { new RaiseStats(true, false, "defense", -1) });
            case 19:
                return GenerateMove("Ignore", 0, "Normal", 0, new List<IEffect>() { new NoEffect() });
        }
    }
    private static Move GenerateMove(string name, int damage, string type, int category, List<IEffect> effects)
    {
        return new Move(name, damage, type, category, effects);
    }
}

