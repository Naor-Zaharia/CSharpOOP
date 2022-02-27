using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02.GameObject
{
    internal class CardInMemoryGame<T>
    {
        private readonly int r_WidthIndexOnBoard;
        private readonly int r_HeightIndexOnBoard;
        private readonly T r_CardValue;
        private bool m_IsCardFlipped;
        private bool m_IsPairDiscovered;
        private bool m_IsChosenCurrentTurn;

        // The Constructor - create new card
        // Parameters:  T - the current card value
        //              int - card position on board
        // Return: Constructor
        internal CardInMemoryGame(T i_CardValue, int i_WidthIndexOnBoard, int i_HeightIndexOnBoard)
        {
            this.r_CardValue = i_CardValue;
            this.r_WidthIndexOnBoard = i_WidthIndexOnBoard;
            this.r_HeightIndexOnBoard = i_HeightIndexOnBoard;
            this.m_IsPairDiscovered = false;
            this.m_IsCardFlipped = false;
            this.m_IsChosenCurrentTurn = false;
        }

        // Property getter method CardValue
        internal T CardValue
        {
            get
            {
                return r_CardValue;
            }
        }

        // Property getter method WidthIndexOnBoard
        internal int WidthIndexOnBoard
        {
            get
            {
                return r_WidthIndexOnBoard;
            }
        }

        // Property getter method HeightIndexOnBoard
        internal int HeightIndexOnBoard
        {
            get
            {
                return r_HeightIndexOnBoard;
            }
        }

        // Property getter and setter method IsPairDiscovered
        internal bool IsPairDiscovered
        {
            get
            {
                return m_IsPairDiscovered;
            }

            set
            {
                this.m_IsPairDiscovered = value;
            }
        }

        // Property getter and setter method IsCardFlipped
        internal bool IsCardFlipped
        {
            get
            {
                return m_IsCardFlipped;
            }

            set
            {
                m_IsCardFlipped = value;
            }
        }

        // Property getter and setter method IsChosenCurrentTurn (indicate the print method to show card on the next print) 
        internal bool IsChosenCurrentTurn
        {
            get
            {
                return m_IsChosenCurrentTurn;
            }

            set
            {
                this.m_IsChosenCurrentTurn = value;
            }
        }
    }
}
