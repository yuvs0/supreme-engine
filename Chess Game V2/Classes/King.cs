using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_V2.Classes
{
    public class King : Piece
    {
        public King(int x, int y, PieceColour colour) : base(x, y, colour, 6) { }
        public override List<int[]> GetValidMoves(Board board, int x, int y)
        {
            var validMoves = new List<int[]>();
            int[,] straightMove = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            int[,] diagonalMove = { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
            for (int i = 0; i < 4; i++)//i is for all the directions
            {//if statement for boundaries
                if (x + straightMove[i, 0] >= 0 == true && y + straightMove[i, 1] >= 0 == true && x + straightMove[i, 0] < 8 == true && y + straightMove[i, 1] < 8 == true)
                {
                    if (board.IsPositionEmpty(board, x + straightMove[i, 0], y + straightMove[i, 1]))
                    {
                        int[] validMove = { x + straightMove[i, 0], y + straightMove[i, 1] };
                        validMoves.Add(validMove);
                    }
                    else if (board.IsOpponentPiece(board, x + straightMove[i, 0], y + straightMove[i, 1], Colour))
                    {
                        int[] validMove = { x + straightMove[i, 0], y + straightMove[i, 1] };
                        validMoves.Add(validMove);
                    }
                }
            }
            for (int i = 0; i < 4; i++)//i is for all the directions
            {//if statement for boundaries
                if (x + diagonalMove[i, 0] >= 0 == true && y + diagonalMove[i, 1] >= 0 == true && x + diagonalMove[i, 0] < 8 == true && y + diagonalMove[i, 1] < 8 == true)
                {
                    if (board.IsPositionEmpty(board, x + diagonalMove[i, 0], y + diagonalMove[i, 1]))
                    {
                        int[] validMove = { x + diagonalMove[i, 0], y + diagonalMove[i, 1] };
                        validMoves.Add(validMove);
                    }
                    else if (board.IsOpponentPiece(board, x + diagonalMove[i, 0], y + diagonalMove[i, 1], Colour))
                    {
                        int[] validMove = { x + diagonalMove[i, 0], y + diagonalMove[i, 1] };
                        validMoves.Add(validMove);
                    }
                }
            }
            return validMoves;
        }
    }
}
