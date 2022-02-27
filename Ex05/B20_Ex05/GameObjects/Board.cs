using System;
using System.Collections.Generic;

namespace B20_Ex05.GameObjects
{
    internal class Board
    {
        private const char k_FirstAvailableCardSymbol = 'A';
        private static readonly Random sr_BuildBoardRandom = new Random();
        private readonly int r_BoardWidth;
        private readonly int r_BoardHeight;
        private readonly List<char> r_AvailableValuesList;
        private CardInMemoryGame[,] m_MatrixGameBoard;

        // The Constructor - create new board
        // Parameters: int - the board measurements
        // Return: Constructor
        internal Board(int i_BoardWidth, int i_BoardHeight)
        {
            this.r_BoardWidth = i_BoardWidth;
            this.r_BoardHeight = i_BoardHeight;
            this.r_AvailableValuesList = createValuesList(i_BoardWidth * i_BoardHeight);
            BuildMemoryGameBoard();
        }

        // The method fill the current board, of the memory game with symbols on random positions
        // Parameters: None        
        // Return: void
        internal void BuildMemoryGameBoard()
        {
            this.m_MatrixGameBoard = new CardInMemoryGame[this.r_BoardHeight, this.r_BoardWidth];

            for (int heightIndex = 0; heightIndex < this.r_BoardHeight; heightIndex++)
            {
                for (int weightIndex = 0; weightIndex < this.r_BoardWidth; weightIndex++)
                {
                    int choosenIndexItem = sr_BuildBoardRandom.Next(0, r_AvailableValuesList.Count);
                    this.m_MatrixGameBoard[heightIndex, weightIndex] = new CardInMemoryGame(
                        r_AvailableValuesList[choosenIndexItem],
                        weightIndex,
                        heightIndex);
                    r_AvailableValuesList.RemoveAt(choosenIndexItem);
                }
            }
        }

        // Property - getter method BoardWidth
        internal int BoardWidth
        {
            get
            {
                return r_BoardWidth;
            }
        }

        // Property getter method BoardHeight
        internal int BoardHeight
        {
            get
            {
                return r_BoardHeight;
            }
        }

        // Property getter method MatrixGameBoard
        internal CardInMemoryGame[,] MatrixGameBoard
        {
            get
            {
                return m_MatrixGameBoard;
            }
        }

        // The method get item on board according to x,y coordinate 
        // Parameters: int - x,y coordinate
        // Return: CardInMemoryGame - the required card 
        internal CardInMemoryGame GetItemOnIndex(int i_RowIndex, int i_ColIndex)
        {
            return this.m_MatrixGameBoard[i_RowIndex, i_ColIndex];
        }

        // The method create list of the available card symbols for board creation
        // Parameters: int - the length of the given list (the amount of card on the new current game)           
        // Return: List<char> - List of card symbols
        private static List<char> createValuesList(int i_ListLength)
        {
            List<char> availableValuesList = new List<char>();
            for (int currentIndex = 0; currentIndex < i_ListLength / 2; currentIndex++)
            {
                availableValuesList.Add((char)((int)k_FirstAvailableCardSymbol + currentIndex));
                availableValuesList.Add((char)((int)k_FirstAvailableCardSymbol + currentIndex));
            }

            return availableValuesList;
        }
    }
}
