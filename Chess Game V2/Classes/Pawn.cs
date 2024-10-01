using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_V2.Classes
{
    public class Pawn:Piece
    {
        public Pawn(int x, int y, PieceColour colour) : base(x, y, colour, 1) { }
        public override List<string> GetValidMoves(Board board, int x, int y)
        {
            var validMoves = new List<string>();
            int direction = (this.Colour == PieceColour.White) ? 1 : -1;
            int forwardPosition = y + direction;
            int[,] diagonalMoves;

            if((this.Colour == PieceColour.White && y == 6) || (this.Colour == PieceColour.Black && y == 1))
            {
                int doubleForwardPosition = forwardPosition*2;
            }
            
            if ((this.Colour == PieceColour.White && board.IsPositionEmpty(board, x+1, y+1) == true) || (this.Colour == PieceColour.White && board.IsPositionEmpty(board, x-1, y+1) == true) || (this.Colour == PieceColour.Black && board.IsPositionEmpty(board, x+1, y-1)) || (this.Colour == PieceColour.Black && board.IsPositionEmpty(board, x-1, y-1)))
            {
                if(this.Colour == PieceColour.White)
                {
                    diagonalMoves = new int[2, 2] { { 1, -1 }, { 1, 1 } };
                }
                else
                {
                    diagonalMoves = new int[2, 2] { { -1, 1 }, { -1,-1 } };
                }
            }
            return null;
        }
    }
}
