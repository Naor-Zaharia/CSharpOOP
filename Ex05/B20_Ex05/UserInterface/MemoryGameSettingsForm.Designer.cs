namespace B20_Ex05.UserInterface
{
    partial class FormMemoryGameSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayerName = new System.Windows.Forms.TextBox();
            this.buttonAgainstSecondPlayer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Second Player Name:";
            // 
            // textBoxFirstPlayerName
            // 
            this.textBoxFirstPlayerName.Location = new System.Drawing.Point(152, 12);
            this.textBoxFirstPlayerName.Name = "textBoxFirstPlayerName";
            this.textBoxFirstPlayerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFirstPlayerName.TabIndex = 0;
            // 
            // textBoxSecondPlayerName
            // 
            this.textBoxSecondPlayerName.Location = new System.Drawing.Point(152, 49);
            this.textBoxSecondPlayerName.Name = "textBoxSecondPlayerName";
            this.textBoxSecondPlayerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSecondPlayerName.TabIndex = 1;
            // 
            // buttonAgainstSecondPlayer
            // 
            this.buttonAgainstSecondPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgainstSecondPlayer.Location = new System.Drawing.Point(275, 45);
            this.buttonAgainstSecondPlayer.Name = "buttonAgainstSecondPlayer";
            this.buttonAgainstSecondPlayer.Size = new System.Drawing.Size(116, 30);
            this.buttonAgainstSecondPlayer.TabIndex = 2;
            this.buttonAgainstSecondPlayer.Text = "Against Computer";
            this.buttonAgainstSecondPlayer.UseVisualStyleBackColor = true;
            this.buttonAgainstSecondPlayer.Click += new System.EventHandler(this.buttonAgainstSecondPlayer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Board Size:";
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonBoardSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBoardSize.Location = new System.Drawing.Point(33, 125);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(98, 82);
            this.buttonBoardSize.TabIndex = 3;
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.SpringGreen;
            this.buttonStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.buttonStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartGame.Location = new System.Drawing.Point(296, 183);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(116, 22);
            this.buttonStartGame.TabIndex = 4;
            this.buttonStartGame.Text = "Start!";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // FormMemoryGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 221);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.buttonAgainstSecondPlayer);
            this.Controls.Add(this.textBoxSecondPlayerName);
            this.Controls.Add(this.textBoxFirstPlayerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMemoryGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirstPlayerName;
        private System.Windows.Forms.TextBox textBoxSecondPlayerName;
        private System.Windows.Forms.Button buttonAgainstSecondPlayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonStartGame;
    }
}