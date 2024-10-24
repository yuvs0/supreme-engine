using Chess_Game_V2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_V2
{
    public partial class Form1 : Form
    {
        private Board board;
        int pieceSelectedX;
        int pieceSelectedY;
        PictureBox[,] boxes = new PictureBox[8, 8];
        public enum Turn
        {
            White,
            Black
        }
        Turn turn = Turn.White;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadChessBoard();
            
        }
        private void newGame_Click(object sender, EventArgs e)
        {

        }
        private void loadChessBoard()
        {
            board = new Board();
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Width = 60,
                        Height = 60,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = (row + column) % 2 == 0 ? Color.White : Color.Gray,
                        Name = $"{row}{column}",
                        Location = new Point((row) * 60, (7-column) * 60)
                    };
                    boxes[row,column] = pictureBox;
                    chessBoardPanel.Controls.Add(pictureBox);
                    pictureBox.MouseClick += PictureBox_MouseClick;
                }
            }
            UpdatePieces();
        }
        private Image GetPieceToDisplay(Piece currentPiece)
        {
            Image imageToDisplay = null;
            if (currentPiece != null)
            {
                if (currentPiece.Colour == PieceColour.White)
                {
                    switch (currentPiece.ID)
                    {
                        case 1:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.white_pawn;
                            break;
                        case 2:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.white_bishop;
                            break;
                        case 3:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.white_knight;
                            break;
                        case 4:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.white_rook;
                            break;
                        case 5:
                            imageToDisplay   = Chess_Game_V2.Properties.Resources.white_queen;
                            break;
                        case 6:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.white_king;
                            break;
                        default:
                            imageToDisplay = null;
                            break;
                    }
                }
                else
                {
                    switch (currentPiece.ID)
                    {
                        case 1:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.black_pawn;
                            break;
                        case 2:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.black_bishop;
                            break;
                        case 3:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.black_knight;
                            break;
                        case 4:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.black_rook;
                            break;
                        case 5:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.black_queen;
                            break;
                        case 6:
                            imageToDisplay = Chess_Game_V2.Properties.Resources.black_king;
                            break;
                        default: 
                            imageToDisplay = null;
                            break;
                    }
                }
            }
            return imageToDisplay;
        }
        private void UpdatePieces()
        {
            for (int row = 0;  row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = board.GetPiece(row, col);
                    if (piece != null)
                    {
                        boxes[row, col].Image = GetPieceToDisplay(piece);
                    }
                    else
                    {
                        boxes[row, col].Image = null;
                    }
                    boxes[row,col].BackColor = (row + col) % 2 == 0 ? Color.White : Color.Gray;
                } 
            }
            CheckForCheck();
            this.Refresh();
        }
        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                string pictureBoxName = ((PictureBox)sender).Name;
                Color pictureBoxColour = ((PictureBox)sender).BackColor;
                int x = int.Parse(Convert.ToString(pictureBoxName[0]));
                int y = int.Parse(Convert.ToString(pictureBoxName[1]));
                Piece piece = board.GetPiece(x, y);
                if (piece != null)
                {
                    if ((Convert.ToString(turn) != Convert.ToString(piece.Colour)) && (pictureBoxColour == Color.Yellow))
                    {
                        PieceToMove(x, y);
                    }
                    else if (Convert.ToString(turn) == Convert.ToString(piece.Colour))
                    {
                        HighlightValidMoves(piece, x, y);
                        if (piece == null && pictureBoxColour == Color.Yellow)
                        {
                            PieceToMove(x, y);
                        }
                    }
                }
                else
                {
                    if (piece == null && pictureBoxColour == Color.Yellow)
                    {
                        PieceToMove(x, y);
                    }
                }
            }
        }
        public Board GetBoard()
        {
            return board;
        }
        private void PieceToMove(int x, int y)
        {
            board.MovePiece(pieceSelectedX, pieceSelectedY, x, y);
            turn = turn == Turn.White ? Turn.Black : Turn.White;
            currentTurn.Text = turn == Turn.White ? "Current Turn: White" : "Current Turn: Black";
            UpdatePieces();
        }
        private void CheckForCheck()
        {
            bool isCheck = board.IsCheck(turn == Turn.White ? PieceColour.Black : PieceColour.White);
            if (isCheck)
            {
                int[] kingPosition = board.GetKingPosition(turn == Turn.White ? PieceColour.White : PieceColour.Black);
                boxes[kingPosition[0], kingPosition[1]].BackColor = Color.Red;
                this.Refresh();
            }
        }
        private bool CheckForCheck(int i)
        {
            bool isCheck = board.IsCheck(turn == Turn.White ? PieceColour.Black : PieceColour.White);
            return isCheck;
        }
        private void HighlightValidMoves(Piece piece, int x, int y) // make a undo move method so you can handle checks, and moves after check
        {
            UpdatePieces();
            if (piece != null)
            {
                pieceSelectedX = x;
                pieceSelectedY = y;
                List<int[]> validMoves = piece.GetValidMoves(board, x, y);
                for (int i = 0; i < validMoves.Count; i++)
                {
                    int[] validPosition = validMoves[i];
                    boxes[validPosition[0], validPosition[1]].BackColor = Color.Yellow;
                }
            }
        }
    }
}
