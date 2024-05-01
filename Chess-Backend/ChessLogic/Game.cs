﻿using ChessLogic.Pieces;

namespace ChessLogic;

public class Game
{
    public Board Board { get; }
    public Player CurrentPlayer { get; private set; }

    public bool IsGameOver
    {
        get => false;
    }

    public Game(Board board, Player currentPlayer)
    {
        Board = board;
        CurrentPlayer = currentPlayer;
    }

    public List<Move> FindLegalMovesForPiece(Position position)
    {
        if (Board.IsEmpty(position) || Board[position].Color != CurrentPlayer)
        {
            return new List<Move>();
        }

        Piece piece = Board[position];
        List<Move> possibleMovies = piece.GetMoves(position, Board);
        return possibleMovies.Where(move => move.IsLegal(Board)).ToList();
    }

    public bool IsPlayerInCheck(Player player)
    {
        return Board.IsInCheck(player);
    }

    private List<Move> FindAllLegalMovesFor(Player player)
    {
        List<Move> possibleMoves = Board.GetPositionsWithPiecesOf(player).SelectMany(position =>
        {
            Piece piece = Board[position];
            return piece.GetMoves(position, Board);
        }).ToList();

        return possibleMoves.Where(move => move.IsLegal(Board)).ToList();
    }

    public void MakeMove(Move move)
    {
        move.Execute(Board);
        CurrentPlayer = CurrentPlayer == Player.White ? Player.Black : Player.White;
    }
}