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
        public override List<string> GetValidMoves(Board board, int x, int y) { return null; }
    }
}
