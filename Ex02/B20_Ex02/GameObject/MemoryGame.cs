using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02.GameObject
{
    internal class MemoryGame<T>
    {
        private readonly List<CardInMemoryGame<T>> r_AvailableCardForComputerChoose;
        private readonly List<CardInMemoryGame<T>> r_AvailablePairsForComputerAIList;
        private readonly Board<T> r_GameBoard;
        private readonly CardInMemoryGame<T>[] r_RevealedCardArray;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private int m_AmountOfDiscoveredPairs;

        // The Constructor - create new memory game
        // Parameters: Board - the board of current game
        //             int - the board measurements
        //             Player - the players on the current game
        // Return: Constructor
        internal MemoryGame(Board<T> i_MatrixMemoryGameBoard, int i_BoardWidth, int i_BoardHeight, Player i_FirstPlayer, Player i_SecondPlayer)
        {
            this.m_FirstPlayer = i_FirstPlayer;
            this.m_SecondPlayer = i_SecondPlayer;
            this.m_AmountOfDiscoveredPairs = 0;
            this.r_GameBoard = i_MatrixMemoryGameBoard;
            this.r_AvailableCardForComputerChoose = getAvailableCardsForComputerList();
            this.r_RevealedCardArray = new CardInMemoryGame<T>[((i_BoardWidth * i_BoardHeight) / 2)];
            this.r_AvailablePairsForComputerAIList = new List<CardInMemoryGame<T>>();
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
        internal Board<T> GameBoard
        {
            get
            {
                return r_GameBoard;
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
        internal List<CardInMemoryGame<T>> AvailableCardForComputerChoose
        {
            get
            {
                return r_AvailableCardForComputerChoose;
            }
        }

        // Property getter method AvailablePairsForComputerAIList
        internal List<CardInMemoryGame<T>> AvailablePairsForComputerAIList
        {
            get
            {
                return r_AvailablePairsForComputerAIList;
            }
        }

        // Property getter method RevealedCardArray
        internal CardInMemoryGame<T>[] RevealedCardArray
        {
            get
            {
                return r_RevealedCardArray;
            }
        }

        // The method return the available cards for computer chose on his turn
        // Parameters: none
        // Return: List<CardInMemoryGame<T>> - the available cards for computer
        private List<CardInMemoryGame<T>> getAvailableCardsForComputerList()
        {
            List<CardInMemoryGame<T>> availableCardForComputerChoose = new List<CardInMemoryGame<T>>();
            foreach (CardInMemoryGame<T> currentCard in this.r_GameBoard.MatrixGameBoard)
            {
                availableCardForComputerChoose.Add(currentCard);
            }

            return availableCardForComputerChoose;
        }
    }
}