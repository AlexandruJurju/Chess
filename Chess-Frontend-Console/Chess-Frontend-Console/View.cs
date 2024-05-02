using ChessLogic;
using ChessLogic.Pieces;

namespace Chess_Frontend_Console;

public class View
{
    private String[,] GetBoardAsString(Board board)
    {
        string[,] notations = new string[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Piece piece = board[i, j];
                if (piece != null)
                {
                    notations[i, j] = piece.ToString();
                }
                else
                {
                    notations[i, j] = "X";
                }
            }
        }

        return notations;
    }


    public void PrintBoardWithNotation(Game game)
    {
        string[,] notation = GetBoardAsString(game.Board);

        for (int i = 0; i < 8; i++)
        {
            // Print row label
            int rowLabel = 8 - i;
            Console.Write(rowLabel + " ");

            for (int j = 0; j < 8; j++)
            {
                Console.Write(notation[i, j] + " ");
            }

            Console.WriteLine();
        }

        // Print column labels
        Console.Write("  ");
        for (int j = 0; j < 8; j++)
        {
            char columnLabel = (char)('a' + j);
            Console.Write(columnLabel + " ");
        }

        Console.WriteLine();
    }

    public void PrintCurrentPlayer(Game game)
    {
        Console.WriteLine($"Current Player: {game.CurrentPlayer}");
    }

    public void PrintBoardWithIndexes(Game game)
    {
        string[,] notation = GetBoardAsString(game.Board);

        for (int i = 0; i < 8; i++)
        {
            // Print row label
            Console.Write(i + " ");

            for (int j = 0; j < 8; j++)
            {
                Console.Write($"{notation[i, j]} ");
            }

            Console.WriteLine();
        }

        // Print column labels
        Console.Write("  ");
        for (int j = 0; j < 8; j++)
        {
            Console.Write(j + " ");
        }

        Console.WriteLine();
    }

    private Position ReadPosition(string prompt)
    {
        Console.Write(prompt);
        string? input = null;

        while (input == null)
        {
            input = Console.ReadLine();
        }

        var positionParts = input.Split(',');
        return new Position(int.Parse(positionParts[0]), int.Parse(positionParts[1]));
    }

    public Position ReadStartPosition()
    {
        return ReadPosition("Enter Run Position (row, column): ");
    }

    public Position ReadEndPosition()
    {
        return ReadPosition("Enter End Position (row, column): ");
    }

    public Move AskForMove(Game game)
    {
        Console.WriteLine($"Current Player: {game.CurrentPlayer}");

        var startPosition = ReadPosition("Enter the start position (row,column): ");
        var endPosition = ReadPosition("Enter the end position (row,column): ");
        Console.WriteLine();

        return new Move(startPosition, endPosition);
    }

    public void PrintBoardWithPossibleMoves(Game game, List<Move> possibleMoves)
    {
        string[,] notation = GetBoardAsString(game.Board);
        var possibleEndPositions = new HashSet<Position>(possibleMoves.Select(move => move.EndPosition));

        for (int i = 0; i < 8; i++)
        {
            Console.Write(i + " ");

            for (int j = 0; j < 8; j++)
            {
                Position currentPosition = new Position(i, j);

                if (possibleEndPositions.Contains(currentPosition) && (!game.Board.IsEmpty(currentPosition) && game.Board[currentPosition].Color != game.CurrentPlayer))
                {
                    // If the position contains an enemy piece, print it in red
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{notation[i, j]} ");
                }
                else if (possibleEndPositions.Contains(currentPosition))
                {
                    // If the position is a possible end position, print an "O" in green
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("O ");
                }
                else
                {
                    Console.Write($"{notation[i, j]} ");
                }

                // Reset the color back to the default
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        Console.Write("  ");
        for (int j = 0; j < 8; j++)
        {
            Console.Write(j + " ");
        }

        Console.WriteLine();
    }


    public void PrintPossibleEndPositions(List<Move> moves)
    {
        Console.WriteLine("Possible moves:");
        foreach (var move in moves)
        {
            Console.WriteLine($"End: ({move.EndPosition.Row},{move.EndPosition.Column})");
        }

        Console.WriteLine();
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}