import {Component, OnInit} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {NgClass, NgForOf, NgIf} from "@angular/common";
import {ApiModule, BoardDto, ChessService, Move, PieceDto, Player, Position} from "../services/openapi";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ApiModule, NgForOf, NgIf, NgClass],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  boardDto: BoardDto = {} as BoardDto;
  validMoves: Move[] = [];
  selectedPiece: PieceDto | null = null;

  constructor(private chessService: ChessService) {
  }

  ngOnInit() {
    this.chessService.getBoard().subscribe(board => {
      this.boardDto = board;
      console.log(this.boardDto)
    });
  }

  getPieceImage(piece: PieceDto): string {
    return `../assets/pieces/${piece.color}-${piece.type}.png`;
  }

  getCurrentPlayer(): string {
    return this.boardDto.player!;
  }

  selectPiece(piece: PieceDto) {
    if (this.selectedPiece === piece) {
      this.selectedPiece = null; // Deselect the piece if it's clicked again
      this.validMoves = []; // Clear the valid moves
    } else {
      this.selectedPiece = piece; // Select the piece
      this.getValidMoves(piece.position!); // Get the valid moves for the selected piece
    }
  }


  movePiece(position: Position) {
    if (this.selectedPiece && this.isMoveValid(position)) {
      console.log(`Moving piece from ${this.selectedPiece.position} to ${position}`);
    }
  }

  getValidMoves(position: Position) {
    this.chessService.getValidMoves(position).subscribe(moves => {
      this.validMoves = moves;
      console.log(moves);
    });
  }

  isMoveValid(position: Position): boolean {
    // @ts-ignore
    return this.validMoves.some(move => move.endPosition.row === position.row && move.endPosition.column === position.column);
  }
}
