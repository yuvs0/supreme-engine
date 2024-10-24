using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_V2.Classes
{
    public class Board
    {
        Piece[,] Pieces;

        public Board()
        {
            Pieces = new Piece[8, 8];
            InitialiseBoard();
        }


        private void InitialiseBoard()
        {
            for (int row = 0; row < 8; row++)//places the pawns
            {
                Pieces[row, 6] = new Pawn(row, 6, PieceColour.Black); // Black pawns
                Pieces[row, 1] = new Pawn(row, 1, PieceColour.White); // White pawns
            }
            //Rooks
            Pieces[0, 0] = new Rook(0, 0, PieceColour.White); // White rooks
            Pieces[7, 0] = new Rook(7, 0, PieceColour.White);
            Pieces[0, 7] = new Rook(0, 7, PieceColour.Black); // Black rooks
            Pieces[7, 7] = new Rook(7, 7, PieceColour.Black);
            //Knights
            Pieces[1, 0] = new Knight(1, 0, PieceColour.White); // White knights
            Pieces[6, 0] = new Knight(6, 0, PieceColour.White);
            Pieces[1, 7] = new Knight(1, 7, PieceColour.Black); // Black knights
            Pieces[6, 7] = new Knight(7, 7, PieceColour.Black);
            //Bishops
            Pieces[2, 0] = new Bishop(2, 0, PieceColour.White); // White bishops
            Pieces[5, 0] = new Bishop(5, 0, PieceColour.White);
            Pieces[2, 7] = new Bishop(2, 7, PieceColour.Black); // Black bishops
            Pieces[5, 7] = new Bishop(5, 7, PieceColour.Black);
            //Queens
            Pieces[3, 0] = new Queen(3, 0, PieceColour.White); // White queen
            Pieces[3, 7] = new Queen(3, 7, PieceColour.Black); // Black queen
            //Kings
            Pieces[4, 0] = new King(4, 0, PieceColour.White); // White king
            Pieces[4, 7] = new King(4, 7, PieceColour.Black); // Black king
        }

        public bool IsPositionEmpty(Board board, int x, int y)
        {
            if (board.Pieces[x,y] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsOpponentPiece(Board board, int x, int y, PieceColour colour)
        {
            if (board.Pieces[x,y] != null)
            {
                if (board.Pieces[x,y].Colour != colour)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public Piece GetPiece(int x, int y)
        {
            return Pieces[x,y];
        }
        public void MovePiece(int fromX, int fromY, int toX, int toY)
        {
            Pieces[toX, toY] = GetPiece(fromX, fromY);
            Pieces[fromX, fromY] = null;
        }
        public List<int[]> GetAllValidMoves(PieceColour colour) //add parameters for colour
        {
            List<int[]> allValidMoves = new List<int[]>();
            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    if (Pieces[i,j] != null)
                    {
                        for (int l = 0; l < Pieces[i, j].GetValidMoves(this, i, j).Count; l++)
                        {
                            if (Pieces[i,j].Colour == colour)
                            {
                                allValidMoves.Add(Pieces[i, j].GetValidMoves(this, i, j)[l]);
                            }
                        }
                    }
                }
            }
            return allValidMoves;
        }
        public int[] GetKingPosition(PieceColour colour) // add parameters for colour
        {
            int[] kingPosition = new int[2];
            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    if (Pieces[i, j] != null)
                    {
                        if (Pieces[i, j].ID == 6 && Pieces[i,j].Colour == colour)
                        {
                            kingPosition.SetValue(i, 0);
                            kingPosition.SetValue(j, 1);
                        }
                    }
                }
            }
            return kingPosition;
        }
        public bool IsCheck(PieceColour colour)
        {
            bool check = false;
            List<int[]> allValidMoves = GetAllValidMoves(colour);
            int[] kingPosition = GetKingPosition(colour == PieceColour.White ? PieceColour.Black : PieceColour.White);
            for (int i = 0; i < allValidMoves.Count; i++)
            {
                int[] validPosition = allValidMoves[i];
                if (validPosition[0] == kingPosition[0] && validPosition[1] == kingPosition[1])
                {
                    check = true;
                }
            }
            return check;
        }
    }
}
