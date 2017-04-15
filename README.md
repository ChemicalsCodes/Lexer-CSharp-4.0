# Lexer-CSharp-4.0
A lexical analyzer for C# 4.0

A Lexical analyzer created with LexGen, so you don't have to create your own.

Please, make sure to check the other amazing chemicals ;)

Usage :
___________________________________________________________________________________________________________________________
Create new lexer object for a given source file
and call "Tokenize()" on it in order to obtain a reader that 
can be passed to a parser, or a "List<Token>" to feed to the parser yourself.

            using Lex_CS4;
            
            string scr = File.ReadAllText(@"MySourceFile.cs");          //get C# source code as a string e.g.
            Lexer lex = new Lexer(scr);                                 //construct instance of the lexer with the source
            TokenReader reader = lex.Tokenize();                        //call "Tokenize()" to analize the source
___________________________________________________________________________________________________________________________

Output Token types :
___________________________________________________________________________________________________________________________
          character_literal,
          string_literal,
          integer_literal,
          real_literal,

          skipped,
          comment,
          directive,

          identifier,
          keyword,
          primitive,

          operator_or_punctuator,			//+= e.g.
          unknown_sign, ___________________________________________________________________________________________________________________________
