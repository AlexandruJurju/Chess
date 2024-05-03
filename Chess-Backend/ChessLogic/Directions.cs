namespace ChessLogic;

public static class Directions
{
    public static readonly Direction North = new(-1, 0);
    public static readonly Direction South = new(1, 0);
    public static readonly Direction East = new(0, 1);
    public static readonly Direction West = new(0, -1);

    public static readonly Direction NorthEast = North + East;
    public static readonly Direction NorthWest = North + West;
    public static readonly Direction SouthEast = South + East;
    public static readonly Direction SouthWest = South + West;
}