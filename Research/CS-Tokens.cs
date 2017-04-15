
enum eTokenRole							//with LexGen
{
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
	unknown_sign,
}