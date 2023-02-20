namespace Dungeon.Char;

public class Moveset
{
    public List<Move> Moves { get; set; }

    int upperLimit;
    int lowerLimit;
    public Moveset(List<int> moveIds)
    {
        upperLimit = 4;
        lowerLimit = 0;

        List<Move> generatedMoves = GenerateMoveset(moveIds);
        if(generatedMoves.Count > upperLimit && generatedMoves.Count <= lowerLimit)
        {
            Moves = new List<Move>() { MoveFactory.CreateMove(0) };
        }
        else
        {
            Moves = generatedMoves;
        }
    }
          
    public List<Move> GenerateMoveset(List<int> moves)
    {
        List<Move> Moveset = new List<Move>();

        foreach(int move in moves)
        {
            Move m = MoveFactory.CreateMove(move);
            Moveset.Add(m);
        }

        return Moveset;
    }

    public Move GetMoveByIndex(int index)
    {
        Move m = Moves[index];
        Move moveToReturn = new Move(m.Name, m.Damage, m.Type, m.Category, m.Effects);
        return moveToReturn;
    }

    public int GetMovesetSize()
    {
        return Moves.Count;
    }
}