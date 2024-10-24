using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_V2.Classes
{
    public class Knight : Piece
    {
        public Knight(int x, int y, PieceColour colour) : base(x, y, colour, 3) { }
        public override List<int[]> GetValidMoves(Board board, int x, int y) 
        {
            var validMoves = new List<int[]>();
            int[,] possibleMove = new int[8,2] { { -2, 1 }, { -1, 2 }, { -2, -1 }, { -1, -2 }, { 2, 1 }, { 1, 2 }, { 2, -1 }, { 1, -2 } };
            for (int i = 0; i < 8; i ++)
            {//if statement to add boundaries
                if (x + possibleMove[i, 0] >= 0 == true && y + possibleMove[i, 1] >= 0 == true && x + possibleMove[i,0] < 8 == true && y + possibleMove[i,1] < 8 == true)
                {
                    if (board.IsPositionEmpty(board, x + possibleMove[i, 0], y + possibleMove[i, 1]) || board.IsOpponentPiece(board, x + possibleMove[i,0], y + possibleMove[i, 1], Colour))
                    {
                        int[] validMove = { x + possibleMove[i, 0], y + possibleMove[i, 1] };
                        validMoves.Add(validMove);
                    }
                }
            }
            return validMoves; 
        }
    }
}
