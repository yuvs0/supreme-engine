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
        public override List<string> GetValidMoves(Board board, int x, int y) { return null; }
    }
}
