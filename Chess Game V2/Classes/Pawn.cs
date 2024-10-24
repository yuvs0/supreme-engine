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
        public override List<int[]> GetValidMoves(Board board, int x, int y)
        {
            var validMoves = new List<int[]>();
            int direction = (this.Colour == PieceColour.White) ? 1 : -1;
            int[] forwardPosition = { x, y + direction };
            int[] diagonalMoves;

            if (board.IsPositionEmpty(board, x, y + direction) == true)
            {
                validMoves.Add(forwardPosition);
            }
            if ((this.Colour == PieceColour.White && y == 1) || (this.Colour == PieceColour.Black && y == 6))
            {
                if ((board.IsPositionEmpty(board, x, y + direction) == true) && (board.IsPositionEmpty(board, x, y + (2 * direction)) == true))
                {
                    int[] doubleForwardPosition = { x, y + (2 * direction) };
                    validMoves.Add(doubleForwardPosition);
                }
            }
            if (x-1 >= 0 && x+1 < 8)
            {
                if (((Colour == PieceColour.White) && board.IsPositionEmpty(board, x + 1, y + 1) == false) || (Colour == PieceColour.White && board.IsPositionEmpty(board, x - 1, y + 1) == false) || ((Colour == PieceColour.Black && board.IsPositionEmpty(board, x + 1, y - 1)) == false) || ((Colour == PieceColour.Black && board.IsPositionEmpty(board, x - 1, y - 1)) == false))
                {
                    if (Colour == PieceColour.White)
                    {
                        if (board.IsOpponentPiece(board, x + 1, y + 1, Colour) == true)
                        {
                            diagonalMoves = new int[2] { x + 1, y + 1 };
                            validMoves.Add(diagonalMoves);
                        }
                        if (board.IsOpponentPiece(board, x - 1, y + 1, Colour) == true)
                        {
                            diagonalMoves = new int[2] { x - 1, y + 1 };
                            validMoves.Add(diagonalMoves);
                        }
                    }
                    else
                    {
                        if (board.IsOpponentPiece(board, x + 1, y - 1, Colour) == true)
                        {
                            diagonalMoves = new int[2] { x + 1, y - 1 };
                            validMoves.Add(diagonalMoves);
                        }
                        if (board.IsOpponentPiece(board, x - 1, y - 1, Colour) == true)
                        {
                            diagonalMoves = new int[2] { x - 1, y - 1 };
                            validMoves.Add(diagonalMoves);
                        }
                    }
                }
            }      
            return validMoves;
        }
    }
}
