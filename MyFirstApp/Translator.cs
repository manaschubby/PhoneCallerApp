using System.Text;
namespace MyFirstApp;

public static class Translator
{
	public static string ToNumber(string raw)
	{
		if (string.IsNullOrWhiteSpace(raw))
		{
			return null;
		}
		raw = raw.ToUpperInvariant();
		var number = new StringBuilder();
		foreach (var c in raw)
		{
			if ("-0123456789".Contains(c))
			{
				number.Append(c);
			}
			else
			{
				var result = TranslateToNumber(c);
				if (result != null)
				{
					number.Append(result);
				}
				else
				{
					return null;
				}
			}
		}
		return number.ToString();
	}
	static readonly string[] digits =
	{
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    };
	static int? TranslateToNumber(char c)
	{
		for (int i =0; i<digits.Length; i++)
		{
			if (digits[i].Contains(c))
				return i + 2;
		}
		return null;
	}
}

