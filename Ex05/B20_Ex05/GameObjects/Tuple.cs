namespace B20_Ex05.GameObjects
{
   public class Tuple
    {
        private readonly byte r_FirstValueOfTuple;
        private readonly byte r_SecondValueOfTuple;

        public Tuple(byte i_FirstValueOfTuple, byte i_SecondValueOfTuple)
        {
            this.r_FirstValueOfTuple = i_FirstValueOfTuple;
            this.r_SecondValueOfTuple = i_SecondValueOfTuple;
        }

        public byte FirstValueOfTuple
        {
            get
            {
                return this.r_FirstValueOfTuple;
            }
        }

        public byte SecondValueOfTuple
        {
            get
            {
                return this.r_SecondValueOfTuple;
            }
        }
    }
}
