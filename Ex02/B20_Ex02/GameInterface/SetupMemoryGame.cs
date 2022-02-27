using System;
using System.Collections.Generic;
using System.Text;
using B20_Ex02.GameObject;
using B20_Ex02.GameUtils;

namespace B20_Ex02.GameInterface
{
    internal class SetupMemoryGame
    {
        private const char k_FirstAvailableCardSymbol = 'A';

        // The method create new memory game setup according to the given input
        // Parameters: Player - the players that will play on the new memory game
        //             bool - indicate if the new game is a rematch
        // Return: void
        internal static MemoryGame<char> CreateNewGameSetup(bool i_RematchGame, Player i_FirstPlayerOnRematch, Player i_SecondPlayerOnRematch)
        {
            Player firstPlayer = i_FirstPlayerOnRematch;
            Player secondPlayer = i_SecondPlayerOnRematch;
            int boardWidth;
            int boardHeight;
            if (!i_RematchGame)
            {
                Console.WriteLine(StringMessages.k_InputNameMessage);
                string firstPlayerName = Console.ReadLine();
                firstPlayer = new Player(firstPlayerName, false);
                secondPlayer = ValidInput.GetSecondPlayer();
            }

            do
            {
                Console.WriteLine(StringMessages.k_InputBoardWidthMessage);
                boardWidth = ValidInput.GetBoardMeasurements();
                Console.WriteLine(StringMessages.k_InputBoardHeightMessage);
                boardHeight = ValidInput.GetBoardMeasurements();
                if ((boardWidth * boardHeight) % 2 != 0)
                {
                    Console.WriteLine(StringMessages.k_InputNeedHaveEvenCellsMessage);
                }
            }
            while ((boardWidth * boardHeight) % 2 != 0);

            Board<char> memoryGameBoard = new Board<char>(boardWidth, boardHeight);
            List<char> availableValuesList = createValuesList(boardWidth * boardHeight);
            memoryGameBoard.BuildMemoryGameBoard(availableValuesList);
            MemoryGame<char> currentMemoryGame = new MemoryGame<char>(memoryGameBoard, boardWidth, boardHeight, firstPlayer, secondPlayer);
            return currentMemoryGame;
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
