using ChessLogic;

namespace Chess_Frontend_Test;

class Program
{
    static void Main(string[] args)
    {
        Board board = new Board();
        board = board.Initialize();
    }
}