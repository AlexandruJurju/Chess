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
  // @ts-ignore
  boardDto: BoardDto;
  validMoves: Move[] = [];

  constructor(private chessService: ChessService) {
  }

  ngOnInit() {
    this.chessService.getBoard().subscribe(board => {
      this.boardDto = board;
      console.log(this.boardDto)
    });
  }

  getPieceImage(piece: PieceDto): string {
    // @ts-ignore
    return `../assets/pieces/${piece.color}-${piece.type}.png`;
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
