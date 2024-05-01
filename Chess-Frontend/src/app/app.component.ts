import {Component, OnInit} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {NgForOf, NgIf} from "@angular/common";
import {ApiModule, BoardDto, ChessService, PieceDto, Player} from "../services/openapi";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ApiModule, NgForOf, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  // @ts-ignore
  boardDto: BoardDto;

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
}
