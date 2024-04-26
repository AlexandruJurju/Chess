using ChessLogic;

namespace Chess_Frontend_Test;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game(new Board().Initialize(), Player.White);
        PrintBoard(game);

        game.MakeMove(new Move(new Position(0, 0), new Position(2, 0)));
        PrintBoard(game);

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