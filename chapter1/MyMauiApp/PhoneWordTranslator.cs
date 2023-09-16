using System.Text;

namespace MyMauiApp;

public static class PhoneWordTranslator
{
    private static readonly string[] Digits =
    {
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    };

    public static string ToNumber(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return null;

        raw = raw.ToUpperInvariant();

        var newNumber = new StringBuilder();
        foreach (var c in raw)
            if (" -0123456789".Contains(c))
            {
                newNumber.Append(c);
            }
            else
            {
                var result = TranslateToNumber(c);
                if (result != null)
                    newNumber.Append(result);
                // Bad character?
                else
                    return null;
            }

        return newNumber.ToString();
    }

    private static int? TranslateToNumber(char c)
    {
        for (var i = 0; i < Digits.Length; i++)
            if (Digits[i].Contains(c))
                return 2 + i;
        return null;
    }
}