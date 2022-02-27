using System;
using System.Collections.Generic;
using System.Text;
using B20_Ex02.GameObject;
using B20_Ex02.GameUtils;

namespace B20_Ex02.GameInterface
{
    internal class PlayTurnInMemoryGame
    {
        private static readonly Random sr_Random = new Random();

        // The method get player, memory game and two card on the game and flip them according to the game rules
        // Parameters: Player - the player that play the current turn
        //             MemoryGame - the game object, which the method play on.
        //             CardInMemoryGame - two cards to flip
        // Return: void
        private static void flipCells(Player i_CurrentPlayer, MemoryGame<char> i_CurrentGame, CardInMemoryGame<char> i_FirstCardChosen, CardInMemoryGame<char> i_SecondCardChosen)
        {
            if (i_FirstCardChosen.CardValue == i_SecondCardChosen.CardValue)
            {
                i_CurrentPlayer.PlayerPoints++;
                i_CurrentGame.AmountOfDiscoveredPairs++;
                i_FirstCardChosen.IsPairDiscovered = true;
                i_SecondCardChosen.IsPairDiscovered = true;

                i_CurrentGame.AvailableCardForComputerChoose.Remove(i_FirstCardChosen);
                i_CurrentGame.AvailableCardForComputerChoose.Remove(i_SecondCardChosen);

                i_CurrentGame.AvailablePairsForComputerAIList.Remove(i_FirstCardChosen);
                i_CurrentGame.AvailablePairsForComputerAIList.Remove(i_SecondCardChosen);
            }
            else
            {
                updateAIList(i_CurrentGame, i_FirstCardChosen, i_SecondCardChosen);
            }

            Ex02.ConsoleUtils.Screen.Clear();
            i_CurrentGame.GameBoard.PrintMemoryBoardGame();
            System.Threading.Thread.Sleep(2000);
            i_FirstCardChosen.IsChosenCurrentTurn = false;
            i_SecondCardChosen.IsChosenCurrentTurn = false;
            Ex02.ConsoleUtils.Screen.Clear();
            i_CurrentGame.GameBoard.PrintMemoryBoardGame();
            i_FirstCardChosen.IsCardFlipped = true;
            i_SecondCardChosen.IsCardFlipped = true;
        }

        // The method play a turn on the current memory game according to the player parameter
        // Parameters: Player - the player that play the current turn
        //             MemoryGame - the game object, which the method play on.
        // Return: void
        internal static void PlayTurn(Player i_CurrentPlayer, MemoryGame<char> i_CurrentGame)
        {
            CardInMemoryGame<char> firstCardChosen = null;
            CardInMemoryGame<char> secondCardChosen = null;
            Ex02.ConsoleUtils.Screen.Clear();
            i_CurrentGame.GameBoard.PrintMemoryBoardGame();
            Console.WriteLine("{0}\"{1}\"", StringMessages.k_TurnOfPlayer, i_CurrentPlayer.PlayerName);
            if (i_CurrentPlayer.IsComputer)
            {
                // Flip coin to choose if computer guess or choose from AI list, to change AI level expend the random range
                int coinResult = sr_Random.Next(0, 2);
                Console.WriteLine(StringMessages.k_ComputerThinkMessage);
                System.Threading.Thread.Sleep(3000);
                if (coinResult == 1)
                {
                    computerPlayTurnWithAI(i_CurrentPlayer, i_CurrentGame);
                }
                else
                {
                    computerPlayTurn(i_CurrentPlayer, i_CurrentGame);
                }
            }
            else
            {
                Console.WriteLine(StringMessages.k_ChoseTwoCellsMessage);
                firstCardChosen = ValidInput.GetValidCell(i_CurrentGame);
                Ex02.ConsoleUtils.Screen.Clear();
                i_CurrentGame.GameBoard.PrintMemoryBoardGame();
                Console.WriteLine(StringMessages.k_SecondCellToOpenMessage);
                secondCardChosen = ValidInput.GetValidCell(i_CurrentGame);
                flipCells(i_CurrentPlayer, i_CurrentGame, firstCardChosen, secondCardChosen);
            }
        }

        // The method play computer turn with AI abilities
        // Parameters: Player - the player that play the current turn (The computer)
        //             MemoryGame - the game object, which the method play on           
        // Return: void
        private static void computerPlayTurnWithAI(Player i_CurrentPlayer, MemoryGame<char> i_CurrentGame)
        {
            CardInMemoryGame<char> firstCardChosen;
            CardInMemoryGame<char> secondCardChosen;
            if (i_CurrentGame.AvailablePairsForComputerAIList.Count == 0)
            {   // AI list is empty guess first card and check if can chose a match pair with previous data 
                Random cardRandom = new Random();
                int chosenIndexCard = cardRandom.Next(0, i_CurrentGame.AvailableCardForComputerChoose.Count);
                firstCardChosen = i_CurrentGame.AvailableCardForComputerChoose[chosenIndexCard];
                int intOfCharValueInRandomCard = ValidInput.GetIntFromCharLetter(firstCardChosen.CardValue);
                if (i_CurrentGame.RevealedCardArray[intOfCharValueInRandomCard] != null && firstCardChosen != i_CurrentGame.RevealedCardArray[intOfCharValueInRandomCard])
                {
                    secondCardChosen = i_CurrentGame.RevealedCardArray[intOfCharValueInRandomCard];
                    firstCardChosen.IsChosenCurrentTurn = true;
                    secondCardChosen.IsChosenCurrentTurn = true;
                    flipCells(i_CurrentPlayer, i_CurrentGame, firstCardChosen, secondCardChosen);
                }
                else
                {
                    // Don't have enough data to play second turn with AI
                    computerPlayTurn(i_CurrentPlayer, i_CurrentGame);
                }
            }
            else
            {
                // Don't have enough data to play turn with AI
                firstCardChosen = i_CurrentGame.AvailablePairsForComputerAIList[0];
                secondCardChosen = i_CurrentGame.RevealedCardArray[ValidInput.GetIntFromCharLetter(firstCardChosen.CardValue)];
                firstCardChosen.IsChosenCurrentTurn = true;
                secondCardChosen.IsChosenCurrentTurn = true;
                flipCells(i_CurrentPlayer, i_CurrentGame, firstCardChosen, secondCardChosen);
            }
        }

        // The method play computer turn by random choose
        // Parameters: Player - the player that play the current turn (The computer)
        //             MemoryGame - the game object, which the method play on             
        // Return: void
        private static void computerPlayTurn(Player i_CurrentPlayer, MemoryGame<char> i_CurrentGame)
        {
            int chosenIndexCard = sr_Random.Next(0, i_CurrentGame.AvailableCardForComputerChoose.Count);
            CardInMemoryGame<char> firstCardChosen = i_CurrentGame.AvailableCardForComputerChoose[chosenIndexCard];
            i_CurrentGame.AvailableCardForComputerChoose.RemoveAt(chosenIndexCard);
            chosenIndexCard = sr_Random.Next(0, i_CurrentGame.AvailableCardForComputerChoose.Count);
            CardInMemoryGame<char> secondCardChosen = i_CurrentGame.AvailableCardForComputerChoose[chosenIndexCard];
            i_CurrentGame.AvailableCardForComputerChoose.RemoveAt(chosenIndexCard);
            firstCardChosen.IsChosenCurrentTurn = true;
            secondCardChosen.IsChosenCurrentTurn = true;
            flipCells(i_CurrentPlayer, i_CurrentGame, firstCardChosen, secondCardChosen);
            if (firstCardChosen.CardValue != secondCardChosen.CardValue)
            {
                i_CurrentGame.AvailableCardForComputerChoose.Add(firstCardChosen);
                i_CurrentGame.AvailableCardForComputerChoose.Add(secondCardChosen);
                updateAIList(i_CurrentGame, firstCardChosen, secondCardChosen);
            }
        }

        // The method update AI list of discover cards on each turn
        // Parameters: Player - the player that play the current turn (The computer)
        //             MemoryGame - the game object, which the method play on
        //            CardInMemoryGame - two cards that has been flipped
        // Return: void
        private static void updateAIList(MemoryGame<char> i_CurrentGame, CardInMemoryGame<char> i_FirstCardChosen, CardInMemoryGame<char> i_SecondCardChosen)
        {
            int indexOfFirstCard = ValidInput.GetIntFromCharLetter(i_FirstCardChosen.CardValue);
            int indexOfSecondCard = ValidInput.GetIntFromCharLetter(i_SecondCardChosen.CardValue);

            if (i_CurrentGame.RevealedCardArray[indexOfFirstCard] == null)
            {
                i_CurrentGame.RevealedCardArray[indexOfFirstCard] = i_FirstCardChosen;
            }
            else
            {
                if (i_CurrentGame.RevealedCardArray[indexOfFirstCard] != i_FirstCardChosen && !i_CurrentGame.AvailablePairsForComputerAIList.Contains(i_FirstCardChosen))
                {
                    i_CurrentGame.AvailablePairsForComputerAIList.Add(i_FirstCardChosen);
                }
            }

            if (i_CurrentGame.RevealedCardArray[indexOfSecondCard] == null)
            {
                i_CurrentGame.RevealedCardArray[indexOfSecondCard] = i_SecondCardChosen;
            }
            else
            {
                if (i_CurrentGame.RevealedCardArray[indexOfSecondCard] != i_SecondCardChosen && !i_CurrentGame.AvailablePairsForComputerAIList.Contains(i_SecondCardChosen))
                {
                    i_CurrentGame.AvailablePairsForComputerAIList.Add(i_SecondCardChosen);
                }
            }
        }
    }
}
