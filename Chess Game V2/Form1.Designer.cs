namespace Chess_Game_V2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.undoMove = new System.Windows.Forms.Button();
            this.newGame = new System.Windows.Forms.Button();
            this.pgnGameNotation = new System.Windows.Forms.TextBox();
            this.saveGame = new System.Windows.Forms.Button();
            this.chessBoardPanel = new System.Windows.Forms.Panel();
            this.currentTurn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // undoMove
            // 
            this.undoMove.Location = new System.Drawing.Point(641, 100);
            this.undoMove.Name = "undoMove";
            this.undoMove.Size = new System.Drawing.Size(75, 23);
            this.undoMove.TabIndex = 1;
            this.undoMove.Text = "Undo Move";
            this.undoMove.UseVisualStyleBackColor = true;
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(722, 100);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(75, 23);
            this.newGame.TabIndex = 2;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // pgnGameNotation
            // 
            this.pgnGameNotation.Location = new System.Drawing.Point(641, 160);
            this.pgnGameNotation.Name = "pgnGameNotation";
            this.pgnGameNotation.Size = new System.Drawing.Size(156, 20);
            this.pgnGameNotation.TabIndex = 3;
            // 
            // saveGame
            // 
            this.saveGame.Location = new System.Drawing.Point(722, 557);
            this.saveGame.Name = "saveGame";
            this.saveGame.Size = new System.Drawing.Size(75, 23);
            this.saveGame.TabIndex = 4;
            this.saveGame.Text = "Save Game";
            this.saveGame.UseVisualStyleBackColor = true;
            // 
            // chessBoardPanel
            // 
            this.chessBoardPanel.Location = new System.Drawing.Point(100, 100);
            this.chessBoardPanel.Name = "chessBoardPanel";
            this.chessBoardPanel.Size = new System.Drawing.Size(480, 480);
            this.chessBoardPanel.TabIndex = 5;
            // 
            // currentTurn
            // 
            this.currentTurn.AutoSize = true;
            this.currentTurn.Location = new System.Drawing.Point(586, 567);
            this.currentTurn.Name = "currentTurn";
            this.currentTurn.Size = new System.Drawing.Size(100, 13);
            this.currentTurn.TabIndex = 6;
            this.currentTurn.Text = "Current Turn: White";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 667);
            this.Controls.Add(this.currentTurn);
            this.Controls.Add(this.chessBoardPanel);
            this.Controls.Add(this.saveGame);
            this.Controls.Add(this.pgnGameNotation);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.undoMove);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button undoMove;
        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.TextBox pgnGameNotation;
        private System.Windows.Forms.Button saveGame;
        private System.Windows.Forms.Panel chessBoardPanel;
        private System.Windows.Forms.Label currentTurn;
    }
}

