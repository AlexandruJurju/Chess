﻿using ChessLogic;

namespace Chess_Api.Dto;

public class GameDto
{
    public BoardDto BoardDto { get; set; }
    public Player Player { get; set; }
    public bool IsInCheck { get; set; }
    public bool IsCheckMate { get; set; }
}