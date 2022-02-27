using System;
using System.Text;

namespace B20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            PrintSandClock(5);
        }

        // The method get the length of the first line and print sand clock 
        // Parameters: i_LengthOfFirstLine length of the first line
        // Return: void
        public static void PrintSandClock(int i_LengthOfFirstLine)
        {
            StringBuilder sandClockStringBuilder = new StringBuilder();
            Console.WriteLine(createSandClockString(i_LengthOfFirstLine, sandClockStringBuilder, 0));
            Console.WriteLine("Press any key to exit");
            Console.ReadLine(); // Keep the console open
        }

        // The recursive method get the length of the first line and print sand clock 
        // Parameters: i_LengthOfFirstLine length of the first line
        //             i_SandClockStringBuilder the string builder of sand clock
        //             i_CurrentRowToAdd the current row of the sand clock
        // Return: StringBuilder the sand clock
        private static StringBuilder createSandClockString(int i_LengthOfFirstLine, StringBuilder i_SandClockStringBuilder, int i_CurrentRowToAdd)
        {
            if (i_LengthOfFirstLine > 0)
            {
                i_SandClockStringBuilder.Append("\n");
                i_SandClockStringBuilder.Append(new string(' ', i_CurrentRowToAdd));
                i_SandClockStringBuilder.Append(new string('*', i_LengthOfFirstLine));
                i_SandClockStringBuilder.Append(new string(' ', i_CurrentRowToAdd));

                if (i_LengthOfFirstLine > 1)
                {
                    createSandClockString(i_LengthOfFirstLine - 2, i_SandClockStringBuilder, i_CurrentRowToAdd + 1);
                }

                if(i_LengthOfFirstLine != 1)
                {
                    i_SandClockStringBuilder.Append("\n");
                    i_SandClockStringBuilder.Append(new string(' ', i_CurrentRowToAdd));
                    i_SandClockStringBuilder.Append(new string('*', i_LengthOfFirstLine));
                    i_SandClockStringBuilder.Append(new string(' ', i_CurrentRowToAdd));
                }
            }

            return i_SandClockStringBuilder;
        }
    }
}
