using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_V2.Classes
{
    public class Queen : Piece
    {
        public Queen(int x, int y, PieceColour colour) : base(x, y, colour, 5) { }
        public override List<int[]> GetValidMoves(Board board, int x, int y)
        {
            var validMoves = new List<int[]>();
            int[,] diagonalMove = { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
            int[,] straightMove = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            for (int i = 0; i < 4; i++)//i is for all the diagonal directions
            {
                for (int j = 1; j < 8; j++)//j is for the range that the queen can travel in
                {//if statement to see if it exceeds boundaries
                    if (x + (j * diagonalMove[i, 0]) >= 0 == true && y + (j * diagonalMove[i, 1]) >= 0 == true && x + (j * diagonalMove[i, 0]) < 8 == true && y + (j * diagonalMove[i, 1]) < 8 == true)
                    {
                        if (board.IsPositionEmpty(board, x + (j * diagonalMove[i, 0]), y + (j * diagonalMove[i, 1])) == true)
                        {
                            int[] validMove = { x + (j * diagonalMove[i, 0]), y + (j * diagonalMove[i, 1]) };
                            validMoves.Add(validMove);
                        }
                        else if (board.IsOpponentPiece(board, x + (j * diagonalMove[i, 0]), y + (j * diagonalMove[i, 1]), Colour) == true)
                        {
                            int[] validMove = { x + (j * diagonalMove[i, 0]), y + (j * diagonalMove[i, 1]) };
                            validMoves.Add(validMove);
                            j = 8; //acts as a break statement
                        }
                        else
                        {
                            j = 8; // acts as a break statement
                        }
                    }
                    
                }
            }
            for (int i = 0; i < 4; i++)//i is for all the straight directions
            {
                for (int j = 1; j < 8; j++)//j is for the range that the queen can travel in
                {//if statement to see if it exceeds boundaries
                    if (x + (j * straightMove[i, 0]) >= 0 == true && y + (j * straightMove[i, 1]) >= 0 == true && x + (j * straightMove[i, 0]) < 8 == true && y + (j * straightMove[i, 1]) < 8 == true)
                    {
                        if (board.IsPositionEmpty(board, x + (j * straightMove[i, 0]), y + (j * straightMove[i, 1])) == true)
                        {
                            int[] validMove = { x + (j * straightMove[i, 0]), y + (j * straightMove[i, 1]) };
                            validMoves.Add(validMove);
                        }
                        else if (board.IsOpponentPiece(board, x + (j * straightMove[i, 0]), y + (j * straightMove[i, 1]), Colour) == true)
                        {
                            int[] validMove = { x + (j * straightMove[i, 0]), y + (j * straightMove[i, 1]) };
                            validMoves.Add(validMove);
                            j = 8; //acts as a break statement
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
