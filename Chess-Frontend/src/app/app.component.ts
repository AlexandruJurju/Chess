import {Component, OnInit} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {NgClass, NgForOf, NgIf} from "@angular/common";
import {ApiModule, ChessService, GameDto, Move, PieceDto, Position} from "../services/openapi";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ApiModule, NgForOf, NgIf, NgClass],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  gameDto: GameDto = {} as GameDto;
  validMoves: Move[] = [];
  selectedPiece: PieceDto | null = null;

  constructor(private chessService: ChessService) {
  }

// On initialization, update the board
  ngOnInit() {
    this.updateBoard();
  }

  // Function to get the current board state from the ChessService
  updateBoard() {
    this.chessService.getBoard().subscribe(game => {
      this.gameDto = game;
      console.log(this.gameDto)
    });
  }

  // Function to get the image of a piece
  getPieceImage(piece: PieceDto): string {
    return `../assets/pieces/${piece.color}-${piece.type}.png`;
  }

  // Function to get the current player
  getCurrentPlayer(): string {
    return this.gameDto.player!;
  }

  // Function to select a piece and get its valid moves
  selectPiece(piece: PieceDto) {
    // if the same piece is clicked again
    if (this.selectedPiece === piece) {
      this.selectedPiece = null; // Deselect the piece if it's clicked again
      this.validMoves = []; // Clear the valid moves
      // if user click on an enemy piece and the move is valid
    } else if (this.selectedPiece?.color != piece.color && this.isMoveValid(piece.position!)) {
      this.movePiece(piece.position!);
    } else {
      this.selectedPiece = piece; // Select the piece
      this.getValidMoves(piece.position!); // Get the valid moves for the selected piece
    }
  }

  // Function to move a piece if the move is valid
  movePiece(position: Position) {
    if (this.selectedPiece && this.isMoveValid(position)) {
      console.log(`Moving piece from ${this.selectedPiece.position} to ${position}`);
      const move: Move = {
        startPosition: this.selectedPiece.position,
        endPosition: position
      };
      this.chessService.makeMove(move).subscribe(game => {
        this.gameDto = game; // Update the game
        this.validMoves = []; // Clear the valid moves
        this.selectedPiece = null; // Deselect the piece
      });
    }
  }

  // Function to get the valid moves for a piece
  getValidMoves(position: Position) {
    this.chessService.getValidMoves(position).subscribe(moves => {
      this.validMoves = moves;
      console.log(moves);
    });
  }

  // Function to check if a move is valid
  isMoveValid(position: Position): boolean {
    // @ts-ignore
    return this.validMoves.some(move => move.endPosition.row === position.row && move.endPosition.column === position.column);
  }

  checkForCheck():boolean {
    return this.gameDto.isInCheck!;
  }

  checkForCheckMate():boolean{
    return this.gameDto.isCheckMate!;
  }
}
