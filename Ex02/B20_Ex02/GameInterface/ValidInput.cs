using System;
using System.Collections.Generic;
using System.Text;
using B20_Ex02.GameObject;
using B20_Ex02.GameUtils;

namespace B20_Ex02.GameInterface
{
    internal class ValidInput
    {
        private const string k_YesAnswer = "Y";
        private const string k_NoAnswer = "N";
        private const string k_QuitAnswer = "Q";
        private const char k_FirstRow = '1';
        private const char k_FirstColumn = 'A';
        private const string k_ComputerPlayerName = "The computer";
        private const int k_MinimalSize = 4;
        private const int k_MaximalSize = 6;

        // The method ask the player for rematch game, and create new game if the answer is Y or Quit if not
        // Parameters: Player - the players that will play on the rematch memory game
        // Return: void
        internal static void AskForRematch(Player i_FirstPlayerInRematch, Player i_SecondPlayerInRematch)
        {
            Console.WriteLine(StringMessages.k_RematchMessage);
            string answerForRematch = Console.ReadLine();

            while (answerForRematch != k_YesAnswer && answerForRematch != k_NoAnswer)
            {
                Console.WriteLine(StringMessages.k_InvalidInputMessage);
                answerForRematch = Console.ReadLine();
            }

            if (answerForRematch == k_YesAnswer)
            {
                i_FirstPlayerInRematch.PlayerPoints = 0;
                i_SecondPlayerInRematch.PlayerPoints = 0;
                MemoryGameManager.ManageMemoryGame(true, i_FirstPlayerInRematch, i_SecondPlayerInRematch);
            }

            Environment.Exit(0);
        }

        // The method get valid input for memory board measurements
        // Parameters: none
        // Return: int - the board measurement
        internal static int GetBoardMeasurements()
        {
            string boardMeasurementString;
            int boardMeasurementInt;
            bool isValidMeasurement = false;

            while (true)
            {
                boardMeasurementString = Console.ReadLine();
                isValidMeasurement = int.TryParse(boardMeasurementString, out boardMeasurementInt);
                if (isValidMeasurement && boardMeasurementInt >= k_MinimalSize && boardMeasurementInt <= k_MaximalSize)
                {
                    return boardMeasurementInt;
                }

                Console.WriteLine(StringMessages.k_InvalidInputMessage);
            }
        }

        // The method ask for second player, and create the second player object according to the given input
        // Parameters: none
        // Return: Player - the second player on the game
        internal static Player GetSecondPlayer()
        {
            string secondPlayerQuestionString;
            Console.WriteLine(StringMessages.k_AskIfSecondPlayerIsComputerMessage);

            while (true)
            {
                secondPlayerQuestionString = Console.ReadLine();
                string secondPlayerName;
                bool isComputer = false;

                if (secondPlayerQuestionString == k_YesAnswer || secondPlayerQuestionString == k_NoAnswer)
                {
                    if (secondPlayerQuestionString == k_YesAnswer)
                    {
                        secondPlayerName = k_ComputerPlayerName;
                        isComputer = true;
                    }
                    else
                    {
                        Console.WriteLine(StringMessages.k_InputSecondNamePlayerMessage);
                        secondPlayerName = Console.ReadLine();
                    }

                    return new Player(secondPlayerName, isComputer);
                }

                Console.WriteLine(StringMessages.k_InvalidInputMessage);
            }
        }

        // The method ask for valid card input to flip
        // Parameters: MemoryGame - the game object, which the method play on.
        // Return: CardInMemoryGame - valid card to flip
        internal static CardInMemoryGame<char> GetValidCell(MemoryGame<char> i_CurrentGame)
        {
            char colChar = ' ';
            char rowChar = ' ';
            while (true)
            {
                string currentCell = Console.ReadLine();
                if (currentCell != null && currentCell.Length == 2)
                {
                    colChar = currentCell[0];
                    rowChar = currentCell[1];
                }

                if (currentCell == k_QuitAnswer)
                {
                    Environment.Exit(0);
                }

                if ((currentCell != null && currentCell.Length == 2) && (char.IsDigit(rowChar) && char.IsUpper(colChar)))
                {
                    int rowIndexOfCell = getRowOfCell(rowChar);
                    int colIndexOfCell = getColOfCell(colChar);
                    if (rowIndexOfCell < i_CurrentGame.GameBoard.BoardHeight && rowIndexOfCell >= 0 && colIndexOfCell < i_CurrentGame.GameBoard.BoardWidth && colIndexOfCell >= 0)
                    {
                        if (i_CurrentGame.GameBoard.GetItemOnIndex(rowIndexOfCell, colIndexOfCell).IsPairDiscovered)
                        {
                            Console.WriteLine(StringMessages.k_InvalidInputChosenOpenedCellMessage);
                        }
                        else
                        {
                            i_CurrentGame.GameBoard.GetItemOnIndex(rowIndexOfCell, colIndexOfCell).IsChosenCurrentTurn = true;
                            return i_CurrentGame.GameBoard.GetItemOnIndex(rowIndexOfCell, colIndexOfCell);
                        }
                    }
                    else
                    {
                        Console.WriteLine(StringMessages.k_InvalidInputOutOfBoundCellMessage);
                    }
                }
                else
                {
                    Console.WriteLine("{0}{1}{2}", StringMessages.k_InvalidInputWrongFormatCellFirstMessage, Environment.NewLine, StringMessages.k_InvalidInputWrongFormatCellSecondMessage);
                }
            }
        }

        // The method get char and convert it to the relevant int according to k_FirstColumn
        // Parameters: i_CurrentChar - the char for convert
        // Return: int - the relevant number which represent the char
        internal static int GetIntFromCharLetter(char i_CurrentChar)
        {
            i_CurrentChar = char.ToUpper(i_CurrentChar);
            return i_CurrentChar - k_FirstColumn;
        }

        // The method get row char and convert it to the relevant int according to k_FirstRow
        // Parameters: i_CurrentChar - the char for convert
        // Return: int - the relevant number which represent the char
        private static int getRowOfCell(char i_RowChar)
        {
            return i_RowChar - k_FirstRow;
        }

        // The method get column char and convert it to the relevant int according to k_FirstColumn
        // Parameters: i_ColChar - the char for convert
        // Return: int - the relevant number which represent the char
        private static int getColOfCell(char i_ColChar)
        {
            return char.ToUpper(i_ColChar) - k_FirstColumn;
        }
    }
}
