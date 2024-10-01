using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_V2.Classes
{
    public enum PieceColour
    {
        White,
        Black
    }
    public abstract class Piece
    {
        public PieceColour Colour { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int ID { get; set; }

        public Piece(int x, int y, PieceColour colour, int iD)
        {
            X = x;
            Y = y;
            Colour = colour;
            ID = iD;
        }
        public abstract List<string> GetValidMoves(Board board, int x, int y);
    }
}
