/**
 * Movie-Net-Backend
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { PieceType } from './pieceType';
import { Player } from './player';
import { Position } from './position';

export interface PieceDto { 
    color?: Player;
    type?: PieceType;
    position?: Position;
}