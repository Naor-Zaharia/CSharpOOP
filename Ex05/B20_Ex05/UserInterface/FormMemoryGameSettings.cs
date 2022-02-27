using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using B20_Ex05.GameObjects;

namespace B20_Ex05.UserInterface
{
   internal class FormMemoryGameSettings : Form
    {
        private const byte k_MinBoardWidth = 4;
        private const byte k_MinBoardHeight = 4;
        private const byte k_MaxBoardWidth = 6;
        private const byte k_MaxBoardHeight = 6;
        private readonly List<Tuple> r_BoardSizeList;
        private bool m_IsSecondPlayerComputer;
        private int m_IndexBoardSize;
        private Label labelFirstPlayerName;
        private Label labelSecondPlayerName;
        private Label labelBoardSize;
        private TextBox textBoxFirstPlayerName;
        private TextBox textBoxSecondPlayerName;
        private Button buttonAgainstSecondPlayer;
        private Button buttonBoardSize;
        private Button buttonStartGame;

        public FormMemoryGameSettings()
        {
            initializeComponent();
            m_IsSecondPlayerComputer = false;
            m_IndexBoardSize = -1;
            r_BoardSizeList = createBoardSizeList();
            this.buttonBoardSize.Text = getTextForBoardSizeButton();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                Tuple boardSizeTuple = this.r_BoardSizeList[this.m_IndexBoardSize];
                string firstPlayerName = textBoxFirstPlayerName.Text;
                string secondPlayerName = textBoxSecondPlayerName.Text;
                FormMemoryGame formMemoryGame = new FormMemoryGame(
                    firstPlayerName,
                    secondPlayerName,
                    boardSizeTuple,
                    m_IsSecondPlayerComputer);
                this.FormClosing -= this.buttonStartGame_Click;
                formMemoryGame.ShowDialog();
            }
            catch (WebException)
            {
                CreateMessageBoxInternetConnectionError();
                this.Close();
            }
        }

        internal static void CreateMessageBoxInternetConnectionError()
        {
            MessageBox.Show(UIStrings.k_ConnectionErrorMsg, UIStrings.k_ConnectionError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            this.buttonBoardSize.Text = getTextForBoardSizeButton();
        }

        private List<Tuple> createBoardSizeList()
        {
            List<Tuple> boardSizeList = new List<Tuple>();
            for (byte currentBoardWidth = k_MinBoardWidth; currentBoardWidth <= k_MaxBoardWidth; currentBoardWidth++)
            {
                for (byte currentBoardHeight = k_MinBoardHeight; currentBoardHeight <= k_MaxBoardHeight; currentBoardHeight++)
                {
                    if ((currentBoardWidth * currentBoardHeight) % 2 == 0)
                    {
                        boardSizeList.Add(new Tuple(currentBoardWidth, currentBoardHeight));
                    }
                }
            }

            return boardSizeList;
        }

        private string getTextForBoardSizeButton()
        {
            this.m_IndexBoardSize = (this.m_IndexBoardSize + 1) % this.r_BoardSizeList.Count;
            Tuple currentSizeTuple = this.r_BoardSizeList[this.m_IndexBoardSize];
            string currentBoardSizeButtonText = string.Format(
                "{0}x{1}",
                currentSizeTuple.FirstValueOfTuple,
                currentSizeTuple.SecondValueOfTuple);
            return currentBoardSizeButtonText;
        }

        private void buttonAgainstSecondPlayer_Click(object sender, EventArgs e)
        {
            this.textBoxSecondPlayerName.Enabled = this.m_IsSecondPlayerComputer;
            this.m_IsSecondPlayerComputer = !this.m_IsSecondPlayerComputer;
            if (m_IsSecondPlayerComputer)
            {
                this.buttonAgainstSecondPlayer.Text = UIStrings.k_AgainstFriend;
                this.textBoxSecondPlayerName.Text = UIStrings.k_Computer;
            }
            else
            {
                this.buttonAgainstSecondPlayer.Text = UIStrings.k_AgainstComputer;
                this.textBoxSecondPlayerName.Text = string.Empty;
            }
        }

        private void initializeComponent()
        {
            this.labelFirstPlayerName = new Label();
            this.labelSecondPlayerName = new Label();
            this.textBoxFirstPlayerName = new TextBox();
            this.textBoxSecondPlayerName = new TextBox();
            this.buttonAgainstSecondPlayer = new Button();
            this.labelBoardSize = new Label();
            this.buttonBoardSize = new Button();
            this.buttonStartGame = new Button();
            this.SuspendLayout();
            
            // labelFirstPlayerName
            this.labelFirstPlayerName.AutoSize = true;
            this.labelFirstPlayerName.Location = new System.Drawing.Point(30, 19);
            this.labelFirstPlayerName.Name = "m_LabelFirstPlayerName";
            this.labelFirstPlayerName.Size = new System.Drawing.Size(92, 13);
            this.labelFirstPlayerName.TabIndex = 2;
            this.labelFirstPlayerName.Text = UIStrings.k_LabelFPName;
            
            // labelSecondPlayerName
            this.labelSecondPlayerName.AutoSize = true;
            this.labelSecondPlayerName.Location = new System.Drawing.Point(30, 56);
            this.labelSecondPlayerName.Name = "m_LabelSecondPlayerName";
            this.labelSecondPlayerName.Size = new System.Drawing.Size(110, 13);
            this.labelSecondPlayerName.TabIndex = 1;
            this.labelSecondPlayerName.Text = UIStrings.k_LabelSPName;
            
            // textBoxFirstPlayerName
            this.textBoxFirstPlayerName.Location = new System.Drawing.Point(152, 12);
            this.textBoxFirstPlayerName.Name = "m_TextBoxFirstPlayerName";
            this.textBoxFirstPlayerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFirstPlayerName.TabIndex = 0;
             
            // textBoxSecondPlayerName
            this.textBoxSecondPlayerName.Location = new System.Drawing.Point(152, 49);
            this.textBoxSecondPlayerName.Name = "m_TextBoxSecondPlayerName";
            this.textBoxSecondPlayerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSecondPlayerName.TabIndex = 1;
             
            // buttonAgainstSecondPlayer
            this.buttonAgainstSecondPlayer.FlatStyle = FlatStyle.Flat;
            this.buttonAgainstSecondPlayer.Location = new System.Drawing.Point(275, 45);
            this.buttonAgainstSecondPlayer.Name = "m_ButtonAgainstSecondPlayer";
            this.buttonAgainstSecondPlayer.Size = new System.Drawing.Size(116, 30);
            this.buttonAgainstSecondPlayer.TabIndex = 2;
            this.buttonAgainstSecondPlayer.Text = UIStrings.k_AgainstComputer;
            this.buttonAgainstSecondPlayer.UseVisualStyleBackColor = true;
            this.buttonAgainstSecondPlayer.Click += new EventHandler(this.buttonAgainstSecondPlayer_Click);
             
            // labelBoardSize
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(30, 107);
            this.labelBoardSize.Name = "m_LabelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(61, 13);
            this.labelBoardSize.TabIndex = 6;
            this.labelBoardSize.Text = UIStrings.k_ButtonBoardSize;
            
            // buttonBoardSize
            this.buttonBoardSize.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonBoardSize.FlatStyle = FlatStyle.Flat;
            this.buttonBoardSize.Location = new System.Drawing.Point(33, 125);
            this.buttonBoardSize.Name = "m_ButtonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(98, 82);
            this.buttonBoardSize.TabIndex = 3;
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new EventHandler(this.buttonBoardSize_Click);
            
            // buttonStartGame
            this.buttonStartGame.BackColor = System.Drawing.Color.SpringGreen;
            this.buttonStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.buttonStartGame.FlatStyle = FlatStyle.Flat;
            this.buttonStartGame.Location = new System.Drawing.Point(296, 183);
            this.buttonStartGame.Name = "m_ButtonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(116, 22);
            this.buttonStartGame.TabIndex = 4;
            this.buttonStartGame.Text = UIStrings.k_ButtonStartGame;
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new EventHandler(this.buttonStartGame_Click);
             
            // FormMemoryGameSettings
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 221);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.buttonAgainstSecondPlayer);
            this.Controls.Add(this.textBoxSecondPlayerName);
            this.Controls.Add(this.textBoxFirstPlayerName);
            this.Controls.Add(this.labelSecondPlayerName);
            this.Controls.Add(this.labelFirstPlayerName);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMemoryGameSettings";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = UIStrings.k_MemoryGameSettings;
            this.ResumeLayout(false);
            this.PerformLayout();

            // Exit button listen to buttonStartGame_Click
            this.FormClosing += new FormClosingEventHandler(this.buttonStartGame_Click);
        }
    }
}
