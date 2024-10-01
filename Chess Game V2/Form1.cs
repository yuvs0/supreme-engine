using Chess_Game_V2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_V2
{
    public partial class Form1 : Form
    {
        private Board board;
        private Piece selectedPiece;
        private int selectedPieceInt;
        PictureBox[,] boxes = new PictureBox[8, 8];
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadChessBoard();
            
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
                        Name = $"pictureBox{row}{column}",
                        Location = new Point(row * 60, column * 60)
                    };
                    boxes[row,column] = pictureBox;
                    chessBoardPanel.Controls.Add(pictureBox);
                    pictureBox.MouseClick += PictureBox_MouseClick; ;
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
            Bitmap sizedImageToDisplay = new Bitmap(imageToDisplay, new Size(55, 55));
            return sizedImageToDisplay;
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
                } 
            }
            this.Refresh();
        }
        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Piece holdPiece = selectedPiece;
            PictureBox clickedBox = sender as PictureBox;
            if (clickedBox != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (boxes[i, j] == clickedBox)
                        {
                            if (selectedPiece == board.GetPiece(i, j))
                            {
                                selectedPiece = null;
                            }
                            else
                            {
                                selectedPiece = board.GetPiece(i, j);
                            }
                        }
                    }
                }
            }
            if (holdPiece != selectedPiece)
            {
                PieceToMove(holdPiece, selectedPiece);
            }
        }
        private void PieceToMove(Piece pieceToUse, Piece pieceToMove)
        {
            int[] positionToUse = board.GetPiece(pieceToUse);
            int[] positionToMove = board.GetPiece(pieceToMove);
            board.MovePiece(positionToUse[0], positionToUse[1], positionToMove[0], positionToMove[1]);
            UpdatePieces();
        }
    }
}
