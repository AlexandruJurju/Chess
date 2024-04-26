﻿using ChessLogic.Pieces;

namespace ChessLogic;

public class Board
{
    private readonly IPiece[,] _pieces = new IPiece[8, 8];

    // setup indexer to access board like a 2d matrix
    public IPiece this[int row, int col]
    {
        get => _pieces[row, col];
        set => _pieces[row, col] = value;
    }

    // indexer to use position object as an index to the matrix
    public IPiece this[Position position]
    {
        get => this[position.Row, position.Column];
        set => _pieces[position.Row, position.Column] = value;
    }

    public Board Initialize()
    {
        Board board = new Board();
        board.PlaceStartingPieces();
        return board;
    }

    private void PlaceStartingPieces()
    {
        this[0, 0] = new Rook(Player.Black);
        this[0, 1] = new Knight(Player.Black);
        this[0, 2] = new Bishop(Player.Black);
        this[0, 3] = new Queen(Player.Black);
        this[0, 4] = new King(Player.Black);
        this[0, 5] = new Bishop(Player.Black);
        this[0, 6] = new Knight(Player.Black);
        this[0, 7] = new Rook(Player.Black);

        for (int i = 0; i < 8; i++)
        {
            this[1, i] = new Pawn(Player.Black);
        }

        this[7, 0] = new Rook(Player.White);
        this[7, 1] = new Knight(Player.White);
        this[7, 2] = new Bishop(Player.White);
        this[7, 3] = new Queen(Player.White);
        this[7, 4] = new King(Player.White);
        this[7, 5] = new Bishop(Player.White);
        this[7, 6] = new Knight(Player.White);
        this[7, 7] = new Rook(Player.White);

        for (int i = 0; i < 8; i++)
        {
            this[6, i] = new Pawn(Player.White);
        }
    }

    public bool IsPositionInside(Position position)
    {
        return position.Row >= 0 && position.Row < 8 && position.Column >= 0 && position.Column < 8;
    }

    public bool IsPositionEmpty(Position position)
    {
        return this[position] == null;
    }
}