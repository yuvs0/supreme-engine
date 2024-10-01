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
        public override List<string> GetValidMoves(Board board, int x, int y) { return null; }
    }
}
