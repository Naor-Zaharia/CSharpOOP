using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using B20_Ex05.GameObjects;
using FormBorderStyle = System.Windows.Forms.FormBorderStyle;
using FormStartPosition = System.Windows.Forms.FormStartPosition;

namespace B20_Ex05.UserInterface
{
    internal class FormMemoryGame : Form
    {
        private const char k_FirstAvailableCardSymbol = 'A';
        private const int k_SpaceBetweenCard = 10;
        private const int k_SpaceOfLabelAndTop = 20;
        private readonly ButtonInMemoryGame[,] r_MemoryGameUIButtonMatrix;
        private readonly Label currentPlayerLabel = new Label();
        private readonly Label firstPlayerLabel = new Label();
        private readonly Label secondPlayerLabel = new Label();
        private readonly Color r_FirstPlayerColor = Color.LightGreen;
        private readonly Color r_SecondPlayerColor = Color.MediumSlateBlue;
        private readonly MemoryGame r_MemoryGame;
        private List<Image> m_ImageList;
        private List<string> m_RequestedUrisPicks;

        public FormMemoryGame(string i_FirstPlayerName, string i_SecondPlayerName, Tuple i_BoardSizeTuple, bool i_IsSecondPlayerComputer)
        {
            byte boardWidth = i_BoardSizeTuple.FirstValueOfTuple;
            byte boardHeight = i_BoardSizeTuple.SecondValueOfTuple;
            this.m_RequestedUrisPicks = new List<string>();
            this.m_ImageList = createImageList(boardHeight * boardWidth);
            Player firstPlayer = new Player(i_FirstPlayerName, false);
            Player secondPlayer = new Player(i_SecondPlayerName, i_IsSecondPlayerComputer);
            this.r_MemoryGameUIButtonMatrix = new ButtonInMemoryGame[boardWidth, boardHeight];
            this.MaximizeBox = false;
            this.AutoSize = true;
            this.Text = UIStrings.k_MemoryGame;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.r_MemoryGame = new MemoryGame(new Board(boardWidth, boardHeight), firstPlayer, secondPlayer);
            r_MemoryGame.MemoryCardSelected += r_MemoryGame_MemoryCardSelected;
            r_MemoryGame.MatchPairSelected += r_MemoryGame_MatchPairSelected;
            r_MemoryGame.UnMatchPairSelected += r_MemoryGame_UnMatchPairSelected;
            r_MemoryGame.SwitchTurn += r_MemoryGame_SwitchTurn;
            r_MemoryGame.GameEnded += r_MemoryGame_GameEnded;
            initializeComponent();
        }

        private void r_MemoryGame_GameEnded()
        {
            if (this.r_MemoryGame.AmountOfDiscoveredPairs == (this.r_MemoryGame.GameBoard.BoardHeight * this.r_MemoryGame.GameBoard.BoardWidth) / 2)
            {
                DialogResult dialogResult = MessageBox.Show(createFinishResultString(), UIStrings.k_EndGame, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    initializeGame();
                }
            }
        }

        private void r_MemoryGame_SwitchTurn()
        {
            currentPlayerLabel.Text = string.Format("{0} {1}", UIStrings.k_CurrentPlayer, r_MemoryGame.GetCurrentPlayerTurn().PlayerName);
            currentPlayerLabel.BackColor = getColorOfCurrentPlayer();
            currentPlayerLabel.Update();
        }

        private void r_MemoryGame_UnMatchPairSelected()
        {
            System.Threading.Thread.Sleep(2000);
            ButtonInMemoryGame firstCardForClean = getButtonInMemoryGame(r_MemoryGame.CurrentTurnFirstCard);
            ButtonInMemoryGame secondCardForClean = getButtonInMemoryGame(r_MemoryGame.CurrentTurnSecondCard);
            cleanButton(firstCardForClean);
            cleanButton(secondCardForClean);
        }

        private void r_MemoryGame_MatchPairSelected(CardInMemoryGame i_FirstCardInCurrentTurn, CardInMemoryGame i_SecondCardOnCurrentTurn)
        {
            getButtonInMemoryGame(i_FirstCardInCurrentTurn).Click -= buttonInMemoryGame_Click;
            getButtonInMemoryGame(i_SecondCardOnCurrentTurn).Click -= buttonInMemoryGame_Click;
            fillPointsLabelsWithData();
        }

        private void r_MemoryGame_MemoryCardSelected(CardInMemoryGame i_CardInMemoryGame)
        {
            if (r_MemoryGame.GetCurrentPlayerTurn().IsComputer)
            {
                System.Threading.Thread.Sleep(1000);
            }

            if (r_MemoryGame.AmountOfFlipCardOnCurrentTurn == 1)
            {
                flipUICards(i_CardInMemoryGame);
            }

            if (r_MemoryGame.AmountOfFlipCardOnCurrentTurn == 2)
            {
                stopListenOnAllValidMemoryGameButton_Click();
                flipUICards(i_CardInMemoryGame);

                // Execute the click event before we start listen
                System.Threading.Thread.Sleep(700);
                Application.DoEvents();
                listenOnAllValidMemoryGameButton_Click();
            }
        }

        private void initializeComponent()
        {
            createMemoryGameUIBoard();
            createCurrentPlayerLabel();
            createResultsLabel();
            r_MemoryGame_SwitchTurn();
            fillPointsLabelsWithData();
            this.Padding = new Padding(k_SpaceOfLabelAndTop);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void createMemoryGameUIBoard()
        {
            ButtonInMemoryGame currentButtonInMemoryGame = null;
            int topPosition = this.Top + k_SpaceOfLabelAndTop;

            int boardWidth = r_MemoryGame.GameBoard.BoardWidth;
            int boardHeight = r_MemoryGame.GameBoard.BoardHeight;
            Board memoryGameBoard = this.r_MemoryGame.GameBoard;

            for (int currentRow = 1; currentRow <= boardHeight; currentRow++)
            {
                int leftPosition = this.Left + k_SpaceBetweenCard;
                for (int currentColumn = 1; currentColumn <= boardWidth; currentColumn++)
                {
                    currentButtonInMemoryGame = new ButtonInMemoryGame(memoryGameBoard.GetItemOnIndex(currentRow - 1, currentColumn - 1));
                    currentButtonInMemoryGame.FlatStyle = FlatStyle.Flat;
                    currentButtonInMemoryGame.Size = new Size(92, 92);
                    currentButtonInMemoryGame.Left = leftPosition + k_SpaceBetweenCard;
                    currentButtonInMemoryGame.Top = topPosition;
                    currentButtonInMemoryGame.TabStop = false;
                    leftPosition = currentButtonInMemoryGame.Right;
                    this.r_MemoryGameUIButtonMatrix[currentColumn - 1, currentRow - 1] = currentButtonInMemoryGame;
                    currentButtonInMemoryGame.Click += buttonInMemoryGame_Click;
                    this.Controls.Add(currentButtonInMemoryGame);
                }

                topPosition = currentButtonInMemoryGame.Bottom + k_SpaceBetweenCard;
            }
        }

        private void buttonInMemoryGame_Click(object sender, EventArgs e)
        {
            // Remove focus from button click
            currentPlayerLabel.Focus();
            ButtonInMemoryGame currentButtonInMemoryGame = sender as ButtonInMemoryGame;
            r_MemoryGame.DoWhenSelectCard(currentButtonInMemoryGame.CardInMemoryGame);
        }

        private void stopListenOnAllValidMemoryGameButton_Click()
        {
            foreach (ButtonInMemoryGame currentButtonInMemoryGame in r_MemoryGameUIButtonMatrix)
            {
                currentButtonInMemoryGame.Click -= buttonInMemoryGame_Click;
            }
        }

        private void listenOnAllValidMemoryGameButton_Click()
        {
            foreach (ButtonInMemoryGame currentButtonInMemoryGame in r_MemoryGameUIButtonMatrix)
            {
                if (!currentButtonInMemoryGame.CardInMemoryGame.IsPairDiscovered)
                {
                    currentButtonInMemoryGame.Click += buttonInMemoryGame_Click;
                }
            }
        }

        private void createCurrentPlayerLabel()
        {
            currentPlayerLabel.AutoSize = true;
            currentPlayerLabel.Visible = true;
            currentPlayerLabel.Left = this.Left + k_SpaceOfLabelAndTop;
            currentPlayerLabel.Top = this.Bottom;
            this.Controls.Add(currentPlayerLabel);
        }

        private void createResultsLabel()
        {
            firstPlayerLabel.AutoSize = true;
            firstPlayerLabel.Left = this.Left + k_SpaceOfLabelAndTop;
            firstPlayerLabel.Top = currentPlayerLabel.Bottom + k_SpaceOfLabelAndTop;
            firstPlayerLabel.BackColor = this.r_FirstPlayerColor;
            this.Controls.Add(firstPlayerLabel);

            secondPlayerLabel.AutoSize = true;
            secondPlayerLabel.Left = this.Left + k_SpaceOfLabelAndTop;
            secondPlayerLabel.Top = firstPlayerLabel.Bottom + k_SpaceOfLabelAndTop;
            secondPlayerLabel.BackColor = this.r_SecondPlayerColor;
            this.Controls.Add(secondPlayerLabel);
        }

        private void fillPointsLabelsWithData()
        {
            firstPlayerLabel.Text = string.Format(
                "{0}: {1} {2}",
                r_MemoryGame.FirstPlayer.PlayerName,
                r_MemoryGame.FirstPlayer.PlayerPoints,
                getPairString(r_MemoryGame.FirstPlayer));
            firstPlayerLabel.Update();
            secondPlayerLabel.Text = string.Format(
                "{0}: {1} {2}",
                r_MemoryGame.SecondPlayer.PlayerName,
                r_MemoryGame.SecondPlayer.PlayerPoints,
                getPairString(r_MemoryGame.SecondPlayer));
            secondPlayerLabel.Update();
        }

        private List<Image> createImageList(int i_ListLength)
        {
            List<Image> availableValuesList = new List<Image>();

            for (int currentIndex = 0; currentIndex < i_ListLength / 2; currentIndex++)
            {
                Image currentImage = importImageFromUrl(UIStrings.k_ImportImagesUrl);
                availableValuesList.Add(currentImage);
            }

            return availableValuesList;
        }

        private Image importImageFromUrl(string i_Url)
        {
            bool newImagePicked = false;
            WebResponse urlResponse = null;
            WebRequest urlRequest;

            while (!newImagePicked)
            {
                urlRequest = WebRequest.Create(i_Url);
                urlResponse = urlRequest.GetResponse();
                if (!m_RequestedUrisPicks.Contains(urlResponse.ResponseUri.AbsoluteUri))
                {
                    m_RequestedUrisPicks.Add(urlResponse.ResponseUri.AbsoluteUri);
                    newImagePicked = true;
                }
            }

            Stream urlResponseStream = urlResponse.GetResponseStream();
            Image randomImage = Image.FromStream(urlResponseStream);
            urlResponseStream.Dispose();
            return randomImage;
        }

        private void memoryGameButton_Click(object i_Sender, EventArgs i_Event)
        {
            ButtonInMemoryGame clickedButton = i_Sender as ButtonInMemoryGame;
            r_MemoryGame.DoWhenSelectCard(clickedButton.CardInMemoryGame);
        }

        private void flipUICards(CardInMemoryGame i_CardInMemoryGame)
        {
            ButtonInMemoryGame currentButtonInMemoryGame = getButtonInMemoryGame(i_CardInMemoryGame);
            currentButtonInMemoryGame.Click -= buttonInMemoryGame_Click;
            int pictureIndex = getImageIndexFromChar(i_CardInMemoryGame.CardValue);
            currentButtonInMemoryGame.Image = m_ImageList[pictureIndex];
            currentButtonInMemoryGame.ImageAlign = ContentAlignment.MiddleCenter;
            currentButtonInMemoryGame.BackColor = getColorOfCurrentPlayer();
            currentButtonInMemoryGame.Update();
        }

        private ButtonInMemoryGame getButtonInMemoryGame(CardInMemoryGame i_CardInMemoryGame)
        {
            return r_MemoryGameUIButtonMatrix[i_CardInMemoryGame.WidthIndexOnBoard, i_CardInMemoryGame.HeightIndexOnBoard];
        }

        private void initializeGame()
        {
            this.Hide();
            this.m_RequestedUrisPicks = new List<string>();
            try
            {
                this.m_ImageList = createImageList(
                    this.r_MemoryGame.GameBoard.BoardHeight * this.r_MemoryGame.GameBoard.BoardWidth);
            }
            catch (WebException)
            {
                FormMemoryGameSettings.CreateMessageBoxInternetConnectionError();
                this.Close();
            }

            Board newGameBoard = new Board(r_MemoryGame.GameBoard.BoardWidth, r_MemoryGame.GameBoard.BoardHeight);
            cleanAllBoardButtons(newGameBoard);
            r_MemoryGame.InitMemoryGame(newGameBoard);
            r_MemoryGame_SwitchTurn();
            fillPointsLabelsWithData();
            this.Show();
        }

        private void cleanAllBoardButtons(Board o_Board)
        {
            int boardWidth = r_MemoryGame.GameBoard.BoardWidth;
            int boardHeight = r_MemoryGame.GameBoard.BoardHeight;
            for (int currentRow = 1; currentRow <= boardHeight; currentRow++)
            {
                for (int currentColumn = 1; currentColumn <= boardWidth; currentColumn++)
                {
                    r_MemoryGameUIButtonMatrix[currentColumn - 1, currentRow - 1].CardInMemoryGame =
                        o_Board.GetItemOnIndex(currentRow - 1, currentColumn - 1);
                    cleanButton(r_MemoryGameUIButtonMatrix[currentColumn - 1, currentRow - 1]);
                    r_MemoryGameUIButtonMatrix[currentColumn - 1, currentRow - 1].Click += buttonInMemoryGame_Click;
                }
            }
        }

        private string createFinishResultString()
        {
            string msgBoxString;
            msgBoxString = string.Format(
                @"{0}
{1}
{2}
{3}",
                this.firstPlayerLabel.Text,
                this.secondPlayerLabel.Text,
                getSummaryResultString(),
                UIStrings.k_EndGameRematch);
            return msgBoxString;
        }

        private string getSummaryResultString()
        {
            string summaryLineString;
            if (this.r_MemoryGame.GetLeadingPlayerName() == UIStrings.k_Tie)
            {
                summaryLineString = UIStrings.k_EndGameTie;
            }
            else
            {
                summaryLineString = string.Format(
                    "{0} {1}",
                    UIStrings.k_EndGameWin,
                    this.r_MemoryGame.GetLeadingPlayerName());
            }

            return summaryLineString;
        }

        private void cleanButton(ButtonInMemoryGame i_ButtonInMemoryGame)
        {
            i_ButtonInMemoryGame.Image = null;
            i_ButtonInMemoryGame.BackColor = default(Color);
            i_ButtonInMemoryGame.Update();
        }

        private string getPairString(Player i_Player)
        {
            string pairString;
            if (i_Player.PlayerPoints != 1)
            {
                pairString = string.Format("{0}s", UIStrings.k_PairString);
            }
            else
            {
                pairString = UIStrings.k_PairString;
            }

            return pairString;
        }

        private int getImageIndexFromChar(char i_CharValue)
        {
            return i_CharValue - k_FirstAvailableCardSymbol;
        }

        private Color getColorOfCurrentPlayer()
        {
            Color playerColor;
            if (r_MemoryGame.FirstPlayer == r_MemoryGame.GetCurrentPlayerTurn())
            {
                playerColor = this.r_FirstPlayerColor;
            }
            else
            {
                playerColor = this.r_SecondPlayerColor;
            }

            return playerColor;
        }
    }
}