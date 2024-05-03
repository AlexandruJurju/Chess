namespace ChessLogic;

public class Direction
{
    public int RowChange { get; }
    public int ColumnChange { get; }

    public Direction(int rowChange, int columnChange)
    {
        RowChange = rowChange;
        ColumnChange = columnChange;
    }

    public static Direction operator +(Direction direction1, Direction direction2)
    {
        return new Direction(
            direction1.RowChange + direction2.RowChange,
            direction1.ColumnChange + direction2.ColumnChange);
    }

    public static Direction operator -(Direction direction1, Direction direction2)
    {
        return new Direction(
            direction1.RowChange - direction2.RowChange,
            direction1.ColumnChange - direction2.ColumnChange);
    }
}