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
                Pieces[row, 6] = new Pawn(row, 6, PieceColour.White); // White pawns
                Pieces[row, 1] = new Pawn(row, 1, PieceColour.Black); // Black pawns
            }
            //Rooks
            Pieces[0, 0] = new Rook(0, 0, PieceColour.Black); // Black rooks
            Pieces[7, 0] = new Rook(7, 0, PieceColour.Black);
            Pieces[0, 7] = new Rook(0, 7, PieceColour.White); // White rooks
            Pieces[7, 7] = new Rook(7, 7, PieceColour.White);
            //Knights
            Pieces[1, 0] = new Knight(1, 0, PieceColour.Black); // Black knights
            Pieces[6, 0] = new Knight(6, 0, PieceColour.Black);
            Pieces[1, 7] = new Knight(1, 7, PieceColour.White); // White knights
            Pieces[6, 7] = new Knight(7, 7, PieceColour.White);
            //Bishops
            Pieces[2, 0] = new Bishop(2, 0, PieceColour.Black); // Black bishops
            Pieces[5, 0] = new Bishop(5, 0, PieceColour.Black);
            Pieces[2, 7] = new Bishop(2, 7, PieceColour.White); // White bishops
            Pieces[5, 7] = new Bishop(5, 7, PieceColour.White);
            //Queens
            Pieces[3, 0] = new Queen(3, 0, PieceColour.Black); // Black queen
            Pieces[3, 7] = new Queen(3, 7, PieceColour.White); // White queen
            //Kings
            Pieces[4, 0] = new King(4, 0, PieceColour.Black); // Black king
            Pieces[4, 7] = new King(4, 7, PieceColour.White); // White king
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
        public Piece GetPiece(int x, int y)
        {
            return Pieces[x,y];
        }
        public int[] GetPiece(Piece pieceToGet)
        {
            int[] pieceGotten = new int[2];
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (Pieces[row, col] == pieceToGet)
                    {
                        pieceGotten[0] = row;
                        pieceGotten[1] = col;
                    }
                }
            }
            return pieceGotten;
        }
        public void MovePiece(int fromX, int fromY, int toX, int toY)
        {
            Piece pieceToMove = GetPiece(fromX, fromY);
            Pieces[toX, toY] = pieceToMove;
            Pieces[fromX, fromY] = null;
        }
    }
}
