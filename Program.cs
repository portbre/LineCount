using System;
using System.IO;

namespace LineCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int lines = GetLineCount(args[0]);
            Console.WriteLine("Lines: " + lines.ToString());
        }

        private static int GetLineCount(string fileName)
        {
            BinaryReader reader = new BinaryReader(File.OpenRead(fileName));
            int lineCount = 1;
            
            char lastChar = reader.ReadChar();
            char newChar = new char();
        
            do
            {
                newChar = reader.ReadChar();
                if (lastChar == '\r' && newChar == '\n')
                {
                    lineCount++;
                }
                lastChar = newChar;
            } while (reader.PeekChar() != -1);

            return lineCount;
        }
    }
}
