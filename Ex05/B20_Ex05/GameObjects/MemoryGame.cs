using System;
using System.Collections.Generic;

namespace B20_Ex05.GameObjects
{
    internal class MemoryGame
    {
        public event MemoryCardSelected.MemoryCardSelectedEventHandler MemoryCardSelected = null;

        public event UnMatchPairSelected.UnMatchPairSelectedEventHandler UnMatchPairSelected = null;

        public event MatchPairSelected.MatchPairSelectedEventHandler MatchPairSelected = null;

        public event SwitchTurn.SwitchTurnEventHandler SwitchTurn = null;

        public event GameEnd.GameEndEventHandler GameEnded = null;

        private const string k_LeaderStringTie = "Tie";
        private const string k_OddMatrixExceptionMsg = "Exception - The board size should be even!";
        private static readonly Random sr_Random = new Random();
        private List<CardInMemoryGame> m_AvailableCardForComputerChoose;
        private List<CardInMemoryGame> m_AvailablePairsForComputerAIList;
        private Board m_GameBoard;
        private CardInMemoryGame[] m_RevealedCardArray;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private CardInMemoryGame m_CurrentTurnFirstCard;
        private CardInMemoryGame m_CurrentTurnSecondCard;
        private int m_CurrentIndexPlayerTurn;
        private int m_AmountOfDiscoveredPairs;
        private byte m_AmountOfFlipCardOnCurrentTurn;
        private bool m_IsFirstCard;

        // The Constructor - create new memory game
        // Parameters: Board - the board of current game
        //             int - the board measurements
        //             Player - the players on the current game
        // Return: Constructor
        internal MemoryGame(Board i_MatrixMemoryGameBoard, Player i_FirstPlayer, Player i_SecondPlayer)
        {
            this.m_FirstPlayer = i_FirstPlayer;
            this.m_SecondPlayer = i_SecondPlayer;
            InitMemoryGame(i_MatrixMemoryGameBoard);
        }

        public void InitMemoryGame(Board i_MatrixMemoryGameBoard)
        {
            if ((i_MatrixMemoryGameBoard.BoardHeight * i_MatrixMemoryGameBoard.BoardWidth) % 2 == 0)
            {
                initGameData();
                initCurrentFlipCards();
                this.m_GameBoard = i_MatrixMemoryGameBoard;
                this.m_AvailableCardForComputerChoose = getAvailableCardsForComputerList();
                this.m_RevealedCardArray = new CardInMemoryGame[((i_MatrixMemoryGameBoard.BoardWidth * i_MatrixMemoryGameBoard.BoardHeight) / 2)];
                this.m_AvailablePairsForComputerAIList = new List<CardInMemoryGame>();
            }
            else
            {
                throw new ArgumentException(k_OddMatrixExceptionMsg);
            }
        }

        private void initGameData()
        {
            this.m_IsFirstCard = true;
            this.m_AmountOfFlipCardOnCurrentTurn = 0;
            this.FirstPlayer.PlayerPoints = 0;
            this.SecondPlayer.PlayerPoints = 0;
            this.m_CurrentIndexPlayerTurn = 0;
            this.m_AmountOfDiscoveredPairs = 0;
        }

        private void initCurrentFlipCards()
        {
            this.m_CurrentTurnFirstCard = null;
            this.m_CurrentTurnSecondCard = null;
        }

        protected virtual void OnMatchPairSelected()
        {
            if (MatchPairSelected != null)
            {
                MatchPairSelected.Invoke(m_CurrentTurnFirstCard, m_CurrentTurnSecondCard);
            }
        }

        protected virtual void OnGameEnd()
        {
            if (GameEnded != null)
            {
                GameEnded.Invoke();
            }
        }

        protected virtual void OnSelectCard(CardInMemoryGame i_SelectedMemoryCard)
        {
            if (MemoryCardSelected != null)
            {
                MemoryCardSelected.Invoke(i_SelectedMemoryCard);
            }
        }

        protected virtual void OnSwitchTurn()
        {
            if (SwitchTurn != null)
            {
                SwitchTurn.Invoke();
            }
        }

        protected virtual void OnUnMatchPairSelected()
        {
            if (UnMatchPairSelected != null)
            {
                UnMatchPairSelected.Invoke();
            }
        }

        public void DoWhenSelectCard(CardInMemoryGame i_SelectedMemoryCard)
        {
            m_AmountOfFlipCardOnCurrentTurn++;
            OnSelectCard(i_SelectedMemoryCard);
            if (m_IsFirstCard == true)
            {
                m_CurrentTurnFirstCard = i_SelectedMemoryCard;
                m_IsFirstCard = false;
            }
            else
            {
                m_CurrentTurnSecondCard = i_SelectedMemoryCard;
                PlayTurn();
            }
        }

        public void PlayTurn()
        {
            bool isMatchTurn = Turn.PlayTurn(GetCurrentPlayerTurn(), this, m_CurrentTurnFirstCard, m_CurrentTurnSecondCard);
            if (isMatchTurn)
            {
                OnMatchPairSelected();
                if (isGameEnd())
                {
                    OnGameEnd();
                    return;
                }
            }
            else
            {
                // On Wrong match
                OnUnMatchPairSelected();
                switchTurn();
            }

            m_AmountOfFlipCardOnCurrentTurn = 0;
            m_IsFirstCard = true;
        }

        private void switchTurn()
        {
            m_AmountOfFlipCardOnCurrentTurn = 0;
            m_IsFirstCard = true;
            this.m_CurrentIndexPlayerTurn = (this.m_CurrentIndexPlayerTurn + 1) % 2;
            OnSwitchTurn();
            playComputerTurn();
        }

        private void playComputerTurn()
        {
            bool matchPairFound = true;
            while (GetCurrentPlayerTurn().IsComputer && matchPairFound && !isGameEnd())
            {
                List<CardInMemoryGame> cardsForComputer = GetCardsForComputerTurn();
                m_CurrentTurnFirstCard = cardsForComputer[0];
                m_CurrentTurnSecondCard = cardsForComputer[1];
                DoWhenSelectCard(m_CurrentTurnFirstCard);
                DoWhenSelectCard(m_CurrentTurnSecondCard);

                if (m_CurrentTurnFirstCard == null || !m_CurrentTurnFirstCard.IsPairDiscovered)
                {
                    matchPairFound = false;
                }
            }
        }

        // The method return the available cards for computer chose on his turn
        // Parameters: none
        // Return: List<CardInMemoryGame> - the available cards for computer
        private List<CardInMemoryGame> getAvailableCardsForComputerList()
        {
            List<CardInMemoryGame> availableCardForComputerChoose = new List<CardInMemoryGame>();
            foreach (CardInMemoryGame currentCard in this.m_GameBoard.MatrixGameBoard)
            {
                availableCardForComputerChoose.Add(currentCard);
            }

            return availableCardForComputerChoose;
        }

        public Player GetCurrentPlayerTurn()
        {
            Player currentPlayerTurn = null;
            if (this.m_CurrentIndexPlayerTurn == 0)
            {
                currentPlayerTurn = this.FirstPlayer;
            }
            else
            {
                currentPlayerTurn = this.SecondPlayer;
            }

            return currentPlayerTurn;
        }

        internal List<CardInMemoryGame> GetCardsForComputerTurn()
        {
            // Flip coin to choose if computer guess or choose from AI list, to change AI level expend the random range
            int coinResult = sr_Random.Next(0, 3);
            List<CardInMemoryGame> chosenCardForComputerTurnList = new List<CardInMemoryGame>();

            if (coinResult == 1)
            {
                chosenCardForComputerTurnList = Turn.GetCardsForComputerTurnAI(this);
            }
            else
            {
                chosenCardForComputerTurnList = Turn.GetCardsForComputerTurnRandom(this);
            }

            return chosenCardForComputerTurnList;
        }

        public string GetLeadingPlayerName()
        {
            string leadingPlayerName;
            if (this.FirstPlayer.PlayerPoints > this.SecondPlayer.PlayerPoints)
            {
                leadingPlayerName = this.FirstPlayer.PlayerName;
            }
            else
            {
                if (this.FirstPlayer.PlayerPoints < this.SecondPlayer.PlayerPoints)
                {
                    leadingPlayerName = this.SecondPlayer.PlayerName;
                }
                else
                {
                    leadingPlayerName = k_LeaderStringTie;
                }
            }

            return leadingPlayerName;
        }

        private bool isGameEnd()
        {
            return m_AmountOfDiscoveredPairs == (this.GameBoard.BoardHeight * this.GameBoard.BoardWidth) / 2;
        }

        // Property getter and setter method FirstPlayer object
        internal Player FirstPlayer
        {
            get
            {
                return m_FirstPlayer;
            }

            set
            {
                this.m_FirstPlayer = value;
            }
        }

        internal byte AmountOfFlipCardOnCurrentTurn
        {
            get
            {
                return m_AmountOfFlipCardOnCurrentTurn;
            }
        }

        internal CardInMemoryGame CurrentTurnFirstCard
        {
            get
            {
                return m_CurrentTurnFirstCard;
            }
        }

        internal CardInMemoryGame CurrentTurnSecondCard
        {
            get
            {
                return m_CurrentTurnSecondCard;
            }
        }

        // Property getter and setter method SecondPlayer object
        internal Player SecondPlayer
        {
            get
            {
                return m_SecondPlayer;
            }

            set
            {
                this.m_SecondPlayer = value;
            }
        }

        // Property getter method GameBoard
        internal Board GameBoard
        {
            get
            {
                return m_GameBoard;
            }

            set
            {
                this.m_GameBoard = value;
            }
        }

        // Property getter and setter method AmountOfDiscoveredPairs (amount of cards that reveal and out of the current game)
        internal int AmountOfDiscoveredPairs
        {
            get
            {
                return m_AmountOfDiscoveredPairs;
            }

            set
            {
                this.m_AmountOfDiscoveredPairs = value;
            }
        }

        // Property getter method AvailableCardForComputerChoose
        internal List<CardInMemoryGame> AvailableCardForComputerChoose
        {
            get
            {
                return m_AvailableCardForComputerChoose;
            }
        }

        // Property getter method AvailablePairsForComputerAIList
        internal List<CardInMemoryGame> AvailablePairsForComputerAIList
        {
            get
            {
                return m_AvailablePairsForComputerAIList;
            }
        }

        // Property getter method RevealedCardArray
        internal CardInMemoryGame[] RevealedCardArray
        {
            get
            {
                return m_RevealedCardArray;
            }
        }
    }
}