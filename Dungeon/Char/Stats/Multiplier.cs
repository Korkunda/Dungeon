namespace Dungeon.Char;

public class Multiplier
{
    //extract from the StatsModifier class a Multiplier class which has a Value property and a constructor that takes an int value

    public double Value { get; set; }

    public int Stage {  get; set; }

    private Dictionary<int, double> MultiplierDictionary;


    public Multiplier()
    {
        MultiplierDictionary = new Dictionary<int, double>();
        InitialiseDictionary(); 
        Stage = 0;
        Value = MultiplierDictionary[Stage];
    }

    public void InitialiseDictionary()
    {
        MultiplierDictionary.Add(-6, 0.0878);
        MultiplierDictionary.Add(-5, 0.1317);
        MultiplierDictionary.Add(-4, 0.1975);
        MultiplierDictionary.Add(-3, 0.2963);
        MultiplierDictionary.Add(-2, 0.4444);
        MultiplierDictionary.Add(-1, 0.6667);
        MultiplierDictionary.Add(0, 1);
        MultiplierDictionary.Add(1, 1.5);
        MultiplierDictionary.Add(2, 2);
        MultiplierDictionary.Add(3, 2.5);
        MultiplierDictionary.Add(4, 3);
        MultiplierDictionary.Add(5, 3.5);
        MultiplierDictionary.Add(6, 4);
    }


    public void RaiseLowerStage(int stages)
    {
        if (Stage == MultiplierDictionary.Keys.Last() && Stage == MultiplierDictionary.Keys.First())
        {
            Stage = Stage;
        }
        else if (Stage + stages >= MultiplierDictionary.Keys.Last())
        {
            Stage = MultiplierDictionary.Keys.Last();
        }
        else if (Stage + stages <= MultiplierDictionary.Keys.First())
        {
            Stage = MultiplierDictionary.Keys.First();
        }
        else
        {
            Stage += stages;
        }
        Value = MultiplierDictionary[Stage];
    }

    public void ResetMultiplier()
    {
        Stage = 0;
        Value = MultiplierDictionary[Stage];
    }

}
