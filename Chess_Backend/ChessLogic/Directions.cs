namespace ChessLogic;

public class Directions
{
    public static Direction North = new Direction(0, -1);
    public static Direction South = new Direction(0, 1);
    public static Direction East = new Direction(1, 0);
    public static Direction West = new Direction(-1, 0);

    public static Direction NE = North + East;
    public static Direction NW = North + West;
    public static Direction SE = South + East;
    public static Direction SW = South + West;
}