namespace ChessLogic;

public class Position
{
    public int Row { get; }
    public int Column { get; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public Player GetSquareColor()
    {
        if ((Row + Column) % 2 == 0)
        {
            return Player.White;
        }

        return Player.Black;
    }

    protected bool Equals(Position other)
    {
        return Row == other.Row && Column == other.Column;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Position)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    public static bool operator ==(Position position1, Position position2)
    {
        return EqualityComparer<Position>.Default.Equals(position1, position2);
    }

    public static bool operator !=(Position position1, Position position2)
    {
        return !(position1 == position2);
    }

    public static Position operator +(Position position, Direction direction)
    {
        return new Position(
            position.Row + direction.RowChange,
            position.Column + direction.ColumnChange);
    }

    public override string ToString()
    {
        char column = (char)('a' + Column);
        int row = 8 - Row;
        return $"{column}{row}";
    }
}