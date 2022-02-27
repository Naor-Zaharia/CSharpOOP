using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace B20_Ex02.GameObject
{
    internal class Board<T>
    {
        private const char k_FirstRow = '1';
        private const char k_FirstColumn = 'A';
        private const char k_LineSeparator = '=';
        private static readonly Random sr_BuildBoardRandom = new Random();
        private readonly int r_BoardWidth;
        private readonly int r_BoardHeight;
        private CardInMemoryGame<T>[,] m_MatrixGameBoard;

        // The Constructor - create new board
        // Parameters: int - the board measurements
        // Return: Constructor
        internal Board(int i_BoardWidth, int i_BoardHeight)
        {
            this.m_MatrixGameBoard = null;
            this.r_BoardWidth = i_BoardWidth;
            this.r_BoardHeight = i_BoardHeight;
        }

        // The method fill the current board, of the memory game with symbols on random positions
        // Parameters: List<T> - List of card symbols           
        // Return: void
        internal void BuildMemoryGameBoard(List<T> i_AvailableValuesList)
        {
            this.m_MatrixGameBoard = new CardInMemoryGame<T>[this.r_BoardHeight, this.r_BoardWidth];

            for (int heightIndex = 0; heightIndex < this.r_BoardHeight; heightIndex++)
            {
                for (int weightIndex = 0; weightIndex < this.r_BoardWidth; weightIndex++)
                {
                    int choosenIndexItem = sr_BuildBoardRandom.Next(0, i_AvailableValuesList.Count);
                    this.m_MatrixGameBoard[heightIndex, weightIndex] = new CardInMemoryGame<T>(
                        i_AvailableValuesList[choosenIndexItem],
                        weightIndex,
                        heightIndex);
                    i_AvailableValuesList.RemoveAt(choosenIndexItem);
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
        internal CardInMemoryGame<T>[,] MatrixGameBoard
        {
            get
            {
                return m_MatrixGameBoard;
            }
        }

        // The method get item on board according to x,y coordinate 
        // Parameters: int - x,y coordinate
        // Return: CardInMemoryGame<T> - the required card 
        internal CardInMemoryGame<T> GetItemOnIndex(int i_RowIndex, int i_ColIndex)
        {
            return this.m_MatrixGameBoard[i_RowIndex, i_ColIndex];
        }

        // The method print the current game board
        // Parameters: none        
        // Return: void
        internal void PrintMemoryBoardGame()
        {
            int lengthOfSpacesStartIndentation = 5;
            StringBuilder memoryGameBoardStringBuilder = new StringBuilder();
            memoryGameBoardStringBuilder.Append("      ");
            for (int indexOnFirstLine = 0; indexOnFirstLine < r_BoardWidth; indexOnFirstLine++)
            {
                memoryGameBoardStringBuilder.AppendFormat("  {0}   ", (char)(k_FirstColumn + indexOnFirstLine));
            }

            int lengthOfLine = memoryGameBoardStringBuilder.Length;
            memoryGameBoardStringBuilder.AppendLine();
            memoryGameBoardStringBuilder.Append("     ");
            memoryGameBoardStringBuilder.Append(k_LineSeparator, lengthOfLine - lengthOfSpacesStartIndentation);
            memoryGameBoardStringBuilder.AppendLine();

            for (int indexOfCurrentRow = 0; indexOfCurrentRow < r_BoardHeight; indexOfCurrentRow++)
            {
                memoryGameBoardStringBuilder.AppendFormat("  {0}", (char)(k_FirstRow + indexOfCurrentRow) + "  |");
                for (int indexOfCurrentCol = 0; indexOfCurrentCol < r_BoardWidth; indexOfCurrentCol++)
                {
                    if (this.m_MatrixGameBoard[indexOfCurrentRow, indexOfCurrentCol].IsPairDiscovered
                       || this.m_MatrixGameBoard[indexOfCurrentRow, indexOfCurrentCol].IsChosenCurrentTurn)
                    {
                        memoryGameBoardStringBuilder.AppendFormat(
                            "  {0}",
                            this.m_MatrixGameBoard[indexOfCurrentRow, indexOfCurrentCol].CardValue + "  |");
                    }
                    else
                    {
                        memoryGameBoardStringBuilder.Append("     |");
                    }
                }

                memoryGameBoardStringBuilder.AppendLine();
                memoryGameBoardStringBuilder.Append("     ");
                memoryGameBoardStringBuilder.Append(k_LineSeparator, lengthOfLine - lengthOfSpacesStartIndentation);
                memoryGameBoardStringBuilder.AppendLine();
            }

            Console.WriteLine(memoryGameBoardStringBuilder);
        }
    }
}
