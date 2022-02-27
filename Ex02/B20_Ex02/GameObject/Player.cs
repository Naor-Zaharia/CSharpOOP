using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02.GameObject
{
    internal class Player
    {
        private readonly string r_PlayerName;
        private readonly bool r_IsComputer;
        private int m_PlayerPoints;

        // The Constructor - create new player
        // Parameters: string - player name
        //             bool - indicate if the player is computer
        // Return: Constructor
        internal Player(string i_PlayerName, bool i_IsComputer)
        {
            this.r_PlayerName = i_PlayerName;
            this.r_IsComputer = i_IsComputer;
            this.m_PlayerPoints = 0;
        }

        // Property getter method PlayerName
        internal string PlayerName
        {
            get
            {
                return r_PlayerName;
            }
        }

        // Property getter setter method PlayerPoints
        internal int PlayerPoints
        {
            get
            {
                return m_PlayerPoints;
            }

            set
            {
                this.m_PlayerPoints = value;
            }
        }

        // Property getter method IsComputer
        internal bool IsComputer
        {
            get
            {
                return r_IsComputer;
            }
        }
    }
}
