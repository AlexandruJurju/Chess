using ChessLogic;

namespace Chess_Frontend_Test;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game(new Board().Initialize(), Player.White);
        PrintBoard(game);

        List<Move> moves = game.FindMovesForPiece(new Position(6, 0));
        foreach (var move in moves)
        {
            Console.WriteLine(move.StartPosition + " " + move.EndPosition);
        }
    }

    private static void PrintBoard(Game game)
    {
        string[,] notation = game.Board.GetChessNotations();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(notation[i, j] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}