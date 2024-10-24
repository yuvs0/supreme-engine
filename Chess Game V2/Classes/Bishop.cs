using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_V2.Classes
{
    public class Bishop : Piece
    {
        public Bishop(int x, int y, PieceColour colour) : base(x, y, colour, 2) { }
        public override List<int[]> GetValidMoves(Board board, int x, int y) 
        { 
            var validMoves = new List<int[]>();
            int[,] diagonalMove = { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
            for (int i = 0; i < 4; i++)//i is for all the directions
            {
                for (int j = 1; j < 8; j++)//j is for the range that the bishop can travel in
                {
                    if ((x + (j * diagonalMove[i, 0]) >= 0) == true && (y + (j * diagonalMove[i, 1]) >= 0) == true && (x + (j * diagonalMove[i, 0]) < 8) == true && (y + (j * diagonalMove[i, 1]) < 8) == true)
                    {
                        if (board.IsPositionEmpty(board, x + (j * diagonalMove[i, 0]), y + (j * diagonalMove[i, 1])))
                        {
                            int[] validMove = { x + (j * diagonalMove[i, 0]), y + (j * diagonalMove[i, 1]) };
                            validMoves.Add(validMove);
                        }
                        else if (board.IsOpponentPiece(board, x + (j * diagonalMove[i, 0]), y + (j * diagonalMove[i, 1]), Colour))
                        {
                            int[] validMove = { x + (j * diagonalMove[i, 0]), y + (j * diagonalMove[i, 1]) };
                            validMoves.Add(validMove);
                            j = 8; // acts as a break statement
                        }
                        else
                        {
                            j = 8; //acts as a break statement
                        }
                    }
                }
            }
            return validMoves;
        }
    }
}
