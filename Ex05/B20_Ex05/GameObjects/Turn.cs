using System;
using System.Collections.Generic;

namespace B20_Ex05.GameObjects
{
   internal class Turn
    {
        private const char k_FirstColumn = 'A';
        private static readonly Random sr_Random = new Random();

        // The method play a turn on the current memory game according to the player parameter
        // Parameters: Player - the player that play the current turn
        //             MemoryGame - the game object, which the method play on.
        // Return: void
        internal static bool PlayTurn(Player i_CurrentPlayer, MemoryGame i_CurrentGame, CardInMemoryGame i_FirstCardChosen, CardInMemoryGame i_SecondCardChosen)
        {
            bool isAMatch = false;
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
                isAMatch = true;
            }
            else
            {
                updateAIList(i_CurrentGame, i_FirstCardChosen, i_SecondCardChosen);
            }

            i_FirstCardChosen.IsChosenCurrentTurn = false;
            i_SecondCardChosen.IsChosenCurrentTurn = false;

            i_FirstCardChosen.IsCardFlipped = true;
            i_SecondCardChosen.IsCardFlipped = true;
            return isAMatch;
        }

        // The method play computer turn with AI abilities
        // Parameters: Player - the player that play the current turn (The computer)
        //             MemoryGame - the game object, which the method play on           
        // Return: void
        internal static List<CardInMemoryGame> GetCardsForComputerTurnAI(MemoryGame i_CurrentGame)
        {
            CardInMemoryGame firstCardChosen;
            CardInMemoryGame secondCardChosen;
            List<CardInMemoryGame> chosenCardForComputerTurnList = new List<CardInMemoryGame>();
            if (i_CurrentGame.AvailablePairsForComputerAIList.Count == 0)
            {   // AI list is empty guess first card and check if can chose a match pair with previous data 
                Random cardRandom = new Random();
                int chosenIndexCard = cardRandom.Next(0, i_CurrentGame.AvailableCardForComputerChoose.Count);
                firstCardChosen = i_CurrentGame.AvailableCardForComputerChoose[chosenIndexCard];
                int intOfCharValueInRandomCard = GetIntFromCharLetter(firstCardChosen.CardValue);
                if (i_CurrentGame.RevealedCardArray[intOfCharValueInRandomCard] != null && firstCardChosen != i_CurrentGame.RevealedCardArray[intOfCharValueInRandomCard])
                {
                    secondCardChosen = i_CurrentGame.RevealedCardArray[intOfCharValueInRandomCard];
                    firstCardChosen.IsChosenCurrentTurn = true;
                    secondCardChosen.IsChosenCurrentTurn = true;
                    chosenCardForComputerTurnList.Add(firstCardChosen);
                    chosenCardForComputerTurnList.Add(secondCardChosen);
                }
                else
                {
                    // Don't have enough data to play second turn with AI
                    chosenCardForComputerTurnList = GetCardsForComputerTurnRandom(i_CurrentGame);
                }
            }
            else
            {
                // Don't have enough data to play turn with AI
                firstCardChosen = i_CurrentGame.AvailablePairsForComputerAIList[0];
                secondCardChosen = i_CurrentGame.RevealedCardArray[GetIntFromCharLetter(firstCardChosen.CardValue)];
                firstCardChosen.IsChosenCurrentTurn = true;
                secondCardChosen.IsChosenCurrentTurn = true;
                chosenCardForComputerTurnList.Add(firstCardChosen);
                chosenCardForComputerTurnList.Add(secondCardChosen);
            }

            return chosenCardForComputerTurnList;
        }

        // The method play computer turn by random choose
        // Parameters: Player - the player that play the current turn (The computer)
        //             MemoryGame - the game object, which the method play on             
        // Return: void
        internal static List<CardInMemoryGame> GetCardsForComputerTurnRandom(MemoryGame i_CurrentGame)
        {
            List<CardInMemoryGame> chosenCardForComputerTurnList = new List<CardInMemoryGame>();
            int chosenIndexCard = sr_Random.Next(0, i_CurrentGame.AvailableCardForComputerChoose.Count);
            CardInMemoryGame firstCardChosen = i_CurrentGame.AvailableCardForComputerChoose[chosenIndexCard];
            i_CurrentGame.AvailableCardForComputerChoose.RemoveAt(chosenIndexCard);
            chosenIndexCard = sr_Random.Next(0, i_CurrentGame.AvailableCardForComputerChoose.Count);
            CardInMemoryGame secondCardChosen = i_CurrentGame.AvailableCardForComputerChoose[chosenIndexCard];
            i_CurrentGame.AvailableCardForComputerChoose.RemoveAt(chosenIndexCard);
            firstCardChosen.IsChosenCurrentTurn = true;
            secondCardChosen.IsChosenCurrentTurn = true;
            chosenCardForComputerTurnList.Add(firstCardChosen);
            chosenCardForComputerTurnList.Add(secondCardChosen);
            if (firstCardChosen.CardValue != secondCardChosen.CardValue)
            {
                i_CurrentGame.AvailableCardForComputerChoose.Add(firstCardChosen);
                i_CurrentGame.AvailableCardForComputerChoose.Add(secondCardChosen);
                updateAIList(i_CurrentGame, firstCardChosen, secondCardChosen);
            }

            return chosenCardForComputerTurnList;
        }

        // The method update AI list of discover cards on each turn
        // Parameters: Player - the player that play the current turn (The computer)
        //             MemoryGame - the game object, which the method play on
        //            CardInMemoryGame - two cards that has been flipped
        // Return: void
        private static void updateAIList(MemoryGame i_CurrentGame, CardInMemoryGame i_FirstCardChosen, CardInMemoryGame i_SecondCardChosen)
        {
            int indexOfFirstCard = GetIntFromCharLetter(i_FirstCardChosen.CardValue);
            int indexOfSecondCard = GetIntFromCharLetter(i_SecondCardChosen.CardValue);

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

        // The method get char and convert it to the relevant int according to k_FirstColumn
        // Parameters: i_CurrentChar - the char for convert
        // Return: int - the relevant number which represent the char
        internal static int GetIntFromCharLetter(char i_CurrentChar)
        {
            i_CurrentChar = char.ToUpper(i_CurrentChar);
            return i_CurrentChar - k_FirstColumn;
        }
    }
}
