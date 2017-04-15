token {
<token> ->
      <identifier>
	| <keyword>
	| <integer_literal>
	| <real_literal>
	| <character_literal>
	| <string_literal>
	| <operator_or_punctuator>
}

identifier {
<identifier> -> <available_identifier> | "@" <identifier_or_keyword>
	<available_identifier>	->	//<An identifier_or_keyword that is not a keyword>
	<identifier_or_keyword> -> 	<identifier_start_character> {<identifier_part_characters>}
		<identifier_start_character> 		-> 		<letter_character> | "_"
		<identifier_part_characters>		->	 	<identifier_part_character> | <identifier_part_characters> <identifier_part_character>
		<identifier_part_character>			->
													  <letter_character> 
													| <decimal_digit_character>
													| <connecting_character>
													| <combining_character>
													| <formatting_character>
													
		<letter_character> 					-> 		//<A Unicode character of classes Lu, Ll, Lt, Lm, Lo, or Nl> | <A unicode_escape_sequence representing a character of classes Lu, Ll, Lt, Lm, Lo, or Nl>
		<decimal_digit_character>			-> 		//<A Unicode character of the class Nd> | <A unicode_escape_sequence representing a character of the class Nd>
		<connecting_character>				-> 		//<A Unicode character of the class Pc> | <A unicode_escape_sequence representing a character of the class Pc>
		<combining_character>				-> 		//<A Unicode character of classes Mn or Mc> | <A unicode_escape_sequence representing a character of classes Mn or Mc>
		<formatting_character>				-> 		//<A Unicode character of the class Cf> | <A unicode_escape_sequence representing a character of the class Cf>
}
keyword {	
<keyword> ->			//keywords
	  "abstract"
    | "as"
    | "base"
    | "bool"
    | "break"
    | "byte"
    | "case"
    | "catch"
    | "char"
    | "checked"
    | "class"
    | "const"
    | "continue"
    | "decimal"
    | "default"
    | "delegate"
    | "do"
    | "double"
    | "else"
    | "enum"
    | "event"
    | "explicit"
    | "extern"
    | "false"
    | "finally"
    | "fixed"
    | "float"
    | "for"
    | "foreach"
    | "goto"
    | "if"
    | "implicit"
    | "in"
    | "int"
    | "interface"
    | "internal"
    | "is"
    | "lock"
    | "long"
    | "namespace"
    | "new"
    | "null"
    | "object"
    | "operator"
    | "out"
    | "override"
    | "params"
    | "private"
    | "protected"
    | "public"
    | "readonly"
    | "ref"
    | "return"
    | "sbyte"
    | "sealed"
    | "short"
    | "sizeof"
    | "stackalloc"
    | "static"
    | "string"
    | "struct"
    | "switch"
    | "this"
    | "throw"
    | "true"
    | "try"
    | "typeof"
    | "uint"
    | "ulong"
    | "unchecked"
    | "unsafe"
    | "ushort"
    | "using"
    | "virtual"
    | "void"
    | "volatile"
    | "while"
}
integer_literal {
<integer_literal> 				->		<decimal_integer_literal> | <hexadecimal_integer_literal>

		<decimal_integer_literal>  		-> 		<decimal_digits> [<integer_type_suffix>]
			<decimal_digit>					-> 	"0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9"
			<decimal_digits> 				->	<decimal_digit> | <decimal_digits> <decimal_digit>
			<integer_type_suffix>   		->	"U" | "u" | "L" | "l" | "UL" | "Ul" | "uL" | "ul" | "LU" | "Lu" | "lU" | "lu"

		<hexadecimal_integer_literal> 	-> 	"0x" <hex_digits> [<integer_type_suffix>]
			<hex_digit>						->	"0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" | "A" | "B" | "C" | "D" | "E" | "F" | "a" | "b" | "c" | "d" | "e" | "f"
			<hex_digits> 					->	<hex_digit> | <hex_digits> <hex_digit>
}
real_literal {
<real_literal>					->
										  <decimal_digits> "." <decimal_digits> [<exponent_part>] [<real_type_suffix>]
										| "." <decimal_digits> [<exponent_part>] [<real_type_suffix>]
										| <decimal_digits> <exponent_part> [<real_type_suffix>]
										| <decimal_digits> <real_type_suffix>
											
	<real_type_suffix> 	 			->	"F" | "f" | "D" | "d" | "M" | "m"
	<exponent_part>					->  "e" [<sign>] <decimal_digits> | "E" [<sign>] <decimal_digits>
	<sign>							->	"+" | "-"
}
character_literal {

<character_literal> 		->		"'" <character> "'"
	<character>					->		<single_character>
										<simple_escape_sequence>
										<hexadecimal_escape_sequence>
										<unicode_escape_sequence>

	<single_character>			-> 		<Any character except ' (U+0027), \ (U+005C), and new_line_character>
	<simple_escape_sequence>	->
									 "\'"
									|"\""
									|"\\"
									|"\0"
									|"\a"
									|"\b"
									|"\f"
									|"\n"
									|"\r"
									|"\t"
									|"\v"
	<hexadecimal_escape_sequence> ->"\x" <hex_digit> [<hex_digit>] [<hex_digit>] [<hex_digit>]
	<unicode_escape_sequence> 	  ->"\u" <hex_digit> <hex_digit> <hex_digit> <hex_digit>
									|"\U" <hex_digit> <hex_digit> <hex_digit> <hex_digit> <hex_digit> <hex_digit> <hex_digit> <hex_digit>
}
string literal {
<string_literal>			-> 		<regular_string_literal> | <verbatim_string_literal>
	
	<regular_string_literal>					->		""" [<regular_string_literal_characters>] """
		<regular_string_literal_characters>			->		<regular_string_literal_character> | <regular_string_literal_characters> <regular_string_literal_character>
		<regular_string_literal_character>   		->		 <single_regular_string_literal_character>
															|<simple_escape_sequence>
															|<hexadecimal_escape_sequence>
															|<unicode_escape_sequence>
															
			<single_regular_string_literal_character>	-> 		<Any character except " (U+0022), \ (U+005C), and new_line_character>
			<simple_escape_sequence>	->   "\'"
											|"\""
											|"\\"
											|"\0"
											|"\a"
											|"\b"
											|"\f"
											|"\n"
											|"\r"
											|"\t"
											|"\v"
			<hexadecimal_escape_sequence> ->"\x" <hex_digit> [<hex_digit>] [<hex_digit>] [<hex_digit>]
			<unicode_escape_sequence> 	  ->"\u" <hex_digit> <hex_digit> <hex_digit> <hex_digit>
											"\U" <hex_digit> <hex_digit> <hex_digit> <hex_digit> <hex_digit> <hex_digit> <hex_digit> <hex_digit>													
	
	
	<verbatim_string_literal>				->		"@"" [<verbatim_string_literal_characters>] "
	<verbatim_string_literal_characters>	->		<verbatim_string_literal_character> | <verbatim_string_literal_characters> <verbatim_string_literal_character>
	<verbatim_string_literal_character>		->		<single_verbatim_string_literal_character> | <quote_escape_sequence>
	
		<single_verbatim_string_literal_character>		->		<any character except ">
		<quote_escape_sequence>							->		"""
}
operator_or_punctuator {
<operator_or_punctuator> ->		//signs
      "{"
    | "}"
    | "["
    | "]"
    | "("
    | ")"
    | "."
    | ","
    | ":"
    | ";"
    | "+"
    | "-"
    | "*"
    | "/"
    | "%"
    | "&"
    | "|"
    | "^"
    | "!"
    | "~"
    | "="
    | "<"
    | ">"
    | "?"
    | "??"
    | "::"
    | "++"
    | "--"
    | "&&"
    | "||"
    | "->"
    | "=="
    | "!="
    | "<="
    | ">="
    | "+="
    | "-="
    | "*="
    | "/="
    | "%="
    | "&="
    | "|="
    | "^="
    | "<<"
    | "<<="
    | "=>"
}

predefined_type {
<predefined_type> ->		//primitive keywords
      "bool"
    | "byte"
    | "char"
    | "decimal"
    | "double"
    | "float"
    | "int"
    | "long"
    | "object"
    | "sbyte"
    | "short"
    | "string"
    | "uint"
    | "ulong"
    | "ushort"
}
meaningless {
<meaningless>	->			//meaningless
	 " "
    |"\t"
    |"\r"
    |"\n"
	|<new_line>
	|<whitespace>
	
	<new_line> -> 		//<Carriage return character (U+000D)> | <Line feed character (U+000A)> | <Carriage return character (U+000D) followed by line feed character (U+000A)> | <Next line character (U+0085)> | <Line separator character (U+2028)> | <Paragraph separator character (U+2029)>
	<whitespace> -> 	//<Any character with Unicode class Zs> | <Horizontal tab character (U+0009)> | <Vertical tab character (U+000B)> | <Form feed character (U+000C)>
}
comment {
<comment>		-> 		<single_line_comment> | <delimited_comment>

	<single_line_comment>		->	 	"//" [<input_characters>]
	<input_characters>				-> 	<input_character> | <input_characters> <input_character>
	<input_character> 				->	//<Any Unicode character except a new_line_character>

	<delimited_comment> 		->		"/*" [<delimited_comment_text>] asterisks "/"
	<asterisks>						->	"*" | asterisks "*"
	<delimited_comment_text> 		-> 	<delimited_comment_section> | <delimited_comment_text> <delimited_comment_section>
	<delimited_comment_section>		->	"/" | [<asterisks>] <not_slash_or_asterisk>
	<not_slash_or_asterisk>			->  //<Any Unicode character except / or *>
}
directive {
<pp_directive>			->
      <pp_declaration>
    | <pp_conditional>
    | <pp_line>
    | <pp_diagnostic>
    | <pp_region>
    | <pp_pragma>
}