using System;
using System.Collections.Generic;
using System.Text;
using B20_Ex02.GameObject;
using B20_Ex02.GameUtils;

namespace B20_Ex02.GameInterface
{
    internal class MemoryGameManager
    {
        // The method boolean which indicate if the new game is a rematch and two players objects, the method create
        // and run new memory game
        // Parameters: bool - indicate if the new game is a rematch
        //             Player - the two players object on the game
        // Return: void
        internal static void ManageMemoryGame(bool i_IsItRematch, Player i_FirstPlayerInRematch, Player i_SecondPlayerInRematch)
        {
            MemoryGame<char> currentGame = SetupMemoryGame.CreateNewGameSetup(i_IsItRematch, i_FirstPlayerInRematch, i_SecondPlayerInRematch);
            startMemoryGame(currentGame);
        }

        // The method run the turns of the game until all pairs reveal, and print game statistics
        // Parameters: MemoryGame - the game object, which the method play on.
        // Return: void
        private static void startMemoryGame(MemoryGame<char> i_CurrentGame)
        {
            while (i_CurrentGame.AmountOfDiscoveredPairs < (i_CurrentGame.GameBoard.BoardWidth * i_CurrentGame.GameBoard.BoardHeight) / 2)
            {
                PlayTurnInMemoryGame.PlayTurn(i_CurrentGame.FirstPlayer, i_CurrentGame);
                if (i_CurrentGame.AmountOfDiscoveredPairs < (i_CurrentGame.GameBoard.BoardWidth * i_CurrentGame.GameBoard.BoardHeight) / 2)
                {
                    PlayTurnInMemoryGame.PlayTurn(i_CurrentGame.SecondPlayer, i_CurrentGame);
                }
            }

            printGameStatistics(i_CurrentGame);
            ValidInput.AskForRematch(i_CurrentGame.FirstPlayer, i_CurrentGame.SecondPlayer);
            Console.WriteLine();
        }

        // The method print game statistics at end of game
        // Parameters: MemoryGame - the game object, which the method play on.
        // Return: void
        private static void printGameStatistics(MemoryGame<char> i_CurrentGame)
        {
            string matchWinnerName = null;
            StringBuilder gameResultStringBuilder = new StringBuilder();
            gameResultStringBuilder.Append(StringMessages.k_GameEndMessage);
            gameResultStringBuilder.AppendLine();
            gameResultStringBuilder.AppendFormat("{0}\"{1}\"{2} {3}{4}", StringMessages.k_GameEndStatisticsFirstMessage, i_CurrentGame.FirstPlayer.PlayerName, StringMessages.k_GameEndStatisticsSecondMessage, i_CurrentGame.FirstPlayer.PlayerPoints, StringMessages.k_GameEndStatisticsThirdMessage);
            gameResultStringBuilder.AppendLine();
            gameResultStringBuilder.AppendFormat("{0}\"{1}\"{2} {3}{4}", StringMessages.k_GameEndStatisticsFirstMessage, i_CurrentGame.SecondPlayer.PlayerName, StringMessages.k_GameEndStatisticsSecondMessage, i_CurrentGame.SecondPlayer.PlayerPoints, StringMessages.k_GameEndStatisticsThirdMessage);

            if (i_CurrentGame.FirstPlayer.PlayerPoints > i_CurrentGame.SecondPlayer.PlayerPoints)
            {
                matchWinnerName = i_CurrentGame.FirstPlayer.PlayerName;
            }
            else
            {
                if (i_CurrentGame.FirstPlayer.PlayerPoints < i_CurrentGame.SecondPlayer.PlayerPoints)
                {
                    matchWinnerName = i_CurrentGame.SecondPlayer.PlayerName;
                }
                else
                {
                    gameResultStringBuilder.AppendLine();
                    gameResultStringBuilder.Append(StringMessages.k_GameEndTieMessage);
                }
            }

            if (matchWinnerName != null)
            {
                gameResultStringBuilder.AppendLine();
                gameResultStringBuilder.AppendFormat("{0}\"{1}\"{2}", StringMessages.k_GameEndStatisticsFirstMessage, matchWinnerName, StringMessages.k_GameEndWinningMessage);
            }

            Console.WriteLine(gameResultStringBuilder);
        }
    }
}