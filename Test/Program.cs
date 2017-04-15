using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Lex_CS4;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Viewers.SetSize();



            //The idea is to create new lexer object for a given source file
            //and call "Tokenize()" on it in order to obtain a reader that 
            //can be passed to a parser, or a "List<Token>" to feed to the parser yourself.

            string scr = File.ReadAllText(@"MySourceFile.cs");          //get C# source code as a string e.g.
            Lexer lex = new Lexer(scr);                                 //construct instance of the lexer with the source
            
            TokenReader reader = lex.Tokenize();                        //call "Tokenize()" to analize the source
            TokenReader samereader = lex.GetReader();                   //other way to obtain a reader if allready tokenized
            List<Token> tokens = lex.Tokens;                            //get "List<Token>" instead

            bool tokenized = lex.Tokenized;                             //has the lexer been tokenized yet?

            string lexed = lex.GetTokens();                             //see the result in a nice way (for debugging) 
            string samelexed = lex.ToString();                          //same as above



            Viewers.Write(lexed, ConsoleColor.Yellow, ConsoleColor.Magenta, true);
        }
    }
    class Viewers
    {
        public static void SetSize()
        {
            int width = (Console.LargestWindowWidth / 6) * 5;
            int height = (Console.LargestWindowHeight / 6) * 5;
            Console.SetWindowSize(width, height);
        }
        public static void Write(string lexed, ConsoleColor main, ConsoleColor system, bool delimit = false)
        {
            Console.ForegroundColor = main;
            int lines = lexed.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length;
            lines += Console.BufferHeight;
            Console.BufferHeight = lines <= (Int16.MaxValue - 1) ? lines : (Int16.MaxValue - 1);

            if (delimit)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine(lexed);
            Console.WriteLine();
            Console.ForegroundColor = system;
            Console.WriteLine("ChemicalLexer for C# 4.0");
            Console.Write("Press any key to continue ...");

            Console.ReadLine();
        }
    }
}
