import {Component} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {NgForOf, NgIf} from "@angular/common";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgForOf, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  chessBoard: string[][] = [
    ['r', 'n', 'b', 'q', 'k', 'b', 'n', 'r'],
    ['p', 'p', 'p', 'p', 'p', 'p', 'p', 'p'],
    ['', '', '', '', '', '', '', ''],
    ['', '', '', '', '', '', '', ''],
    ['', '', '', '', '', '', '', ''],
    ['', '', '', '', '', '', '', ''],
    ['P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'],
    ['R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R']
  ];

  pieceImages: { [id: string]: string } = {
    'P': '../assets/pieces/white-pawn.png',
    'R': '../assets/pieces/white-rook.png',
    'N': '../assets/pieces/white-knight.png',
    'B': '../assets/pieces/white-bishop.png',
    'Q': '../assets/pieces/white-queen.png',
    'K': '../assets/pieces/white-king.png',
    'p': '../assets/pieces/black-pawn.png',
    'r': '../assets/pieces/black-rook.png',
    'n': '../assets/pieces/black-knight.png',
    'b': '../assets/pieces/black-bishop.png',
    'q': '../assets/pieces/black-queen.png',
    'k': '../assets/pieces/black-king.png'
  };

}
