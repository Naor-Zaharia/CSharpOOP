using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using B20_Ex05.GameObjects;

namespace B20_Ex05.UserInterface
{
    public partial class FormMemoryGameSettings : Form
    {
        private const byte k_MinBoardWidth = 4;
        private const byte k_MinBoardHeight = 4;
        private const byte k_MaxBoardWidth=6;
        private const byte k_MaxBoardHeight=6;
        private readonly List<Tuple> r_BoardSizeList;
        private bool m_IsSecondPlayerComputer;

        private int m_IndexBoardSize;

        public FormMemoryGameSettings()
        {
            InitializeComponent();
            m_IsSecondPlayerComputer = false;
            m_IndexBoardSize = 0;
            r_BoardSizeList = createBoardSizeList();
            this.buttonBoardSize.Text = getTextForBoardSizeButton();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Tuple boardSizeTuple = this.r_BoardSizeList[this.m_IndexBoardSize-1];
            string firstPlayerName = textBoxFirstPlayerName.Text;
            string secondPlayerName = textBoxSecondPlayerName.Text;
            FormMemoryGame formMemoryGame = new FormMemoryGame(firstPlayerName,secondPlayerName,boardSizeTuple, m_IsSecondPlayerComputer);
            formMemoryGame.ShowDialog();
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            this.buttonBoardSize.Text = getTextForBoardSizeButton();
        }

        private List<Tuple> createBoardSizeList()
        {
            List<Tuple> boardSizeList=new List<Tuple>();
            for (byte currentBoardWidth = k_MinBoardWidth; currentBoardWidth <= k_MaxBoardWidth; currentBoardWidth++)
            {
                for(byte currentBoardHeight = k_MinBoardHeight; currentBoardHeight <= k_MaxBoardHeight; currentBoardHeight++)
                {
                    if((currentBoardWidth * currentBoardHeight) % 2 == 0)
                    {
                        boardSizeList.Add(new Tuple(currentBoardWidth, currentBoardHeight));
                    }
                }
            }

            return boardSizeList;
        }

        private string getTextForBoardSizeButton()
        {
            Tuple currentSizeTuple = this.r_BoardSizeList[this.m_IndexBoardSize];
            string currentBoardSizeButtonText = string.Format(
                "{0}x{1}",
                currentSizeTuple.FirstValueOfTuple,
                currentSizeTuple.SecondValueOfTuple);
            this.m_IndexBoardSize = (this.m_IndexBoardSize+1) % this.r_BoardSizeList.Count;
            return currentBoardSizeButtonText;
        }

        private void buttonAgainstSecondPlayer_Click(object sender, EventArgs e)
        {
            this.textBoxSecondPlayerName.Enabled = this.m_IsSecondPlayerComputer;
            this.m_IsSecondPlayerComputer = !this.m_IsSecondPlayerComputer;
            if (m_IsSecondPlayerComputer)
            {
                this.buttonAgainstSecondPlayer.Text = "Against a Friend";
                this.textBoxSecondPlayerName.Text = "-Computer-";
            }
            else
            {
                this.buttonAgainstSecondPlayer.Text = "Against Computer";
                this.textBoxSecondPlayerName.Text = "";
            }
        }
    }
}
