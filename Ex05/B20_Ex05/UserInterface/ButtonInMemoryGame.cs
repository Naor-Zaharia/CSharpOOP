using System.Windows.Forms;
using B20_Ex05.GameObjects;

namespace B20_Ex05.UserInterface
{
   internal class ButtonInMemoryGame : Button
    {
        private CardInMemoryGame m_CardInMemoryGame;

        public ButtonInMemoryGame(CardInMemoryGame i_CardInMemoryGame) : base()
        {
            this.m_CardInMemoryGame = i_CardInMemoryGame;
        }

        public CardInMemoryGame CardInMemoryGame
        {
            get
            {
                return m_CardInMemoryGame;
            }

            set
            {
                m_CardInMemoryGame = value;
            }
        }
    }
}
