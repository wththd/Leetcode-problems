using System.Text;
using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium;
public class IntegerToRoman : BaseTest<int, string>
{
    public override void Setup()
    {
        _inputs = new List<int>
        {
            3,
            58,
            1994
        };

        _outputs = new List<string>
        {
            "III",
            "LVIII",
            "MCMXCIV"
        };
    }

    private Dictionary<int, string> RomanDictionary = new Dictionary<int, string>
    {
        { 1, "I" },
        { 5, "V" },
        { 10, "X" },
        { 50, "L" },
        { 100, "C" },
        { 500, "D" },
        { 1000, "M" }
    };

    protected override string Solve(int input)
    {
        var position = 0;
        var sb = new StringBuilder();
        while (input > 0)
        {
            var digit = input % 10;
            WriteRomanString(digit * (int)Math.Pow(10, position) , sb);
            position++;

            input /= 10;
        }

        return sb.ToString();
    }

    private void WriteRomanString(int digit, StringBuilder stringBuilder)
    {
        if (digit == 0)
        {
            return;
        }
        
        if (digit < 4)
        {
            for (var i = 0; i < digit; i++)
            {
                stringBuilder.Insert(0, RomanDictionary[1]);
            }
            return;
        }

        if (digit == 4)
        {
            stringBuilder.Insert(0, RomanDictionary[5]);
            stringBuilder.Insert(0, RomanDictionary[1]);
            return;
        }

        if (digit == 5)
        {
            stringBuilder.Insert(0, RomanDictionary[5]);
            return;
        }

        if (digit < 9)
        {
            for (var i = 0; i < digit % 5; i++)
            {
                stringBuilder.Insert(0, RomanDictionary[1]);
            }
            stringBuilder.Insert(0, RomanDictionary[5]);
            return;
        }

        if (digit == 9)
        {
            stringBuilder.Insert(0, RomanDictionary[10]);
            stringBuilder.Insert(0, RomanDictionary[1]);
            return;
        }

        if (digit < 40)
        {
            for (var i = 0; i < digit / 10; i++)
            {
                stringBuilder.Insert(0, RomanDictionary[10]);
            }
            return;
        }

        if (digit == 40)
        {
            stringBuilder.Insert(0, RomanDictionary[50]);
            stringBuilder.Insert(0, RomanDictionary[10]);
            return;
        }

        if (digit < 90)
        {
            for (var i = 0; i < (digit - 50) / 10; i++)
            {
                stringBuilder.Insert(0, RomanDictionary[10]);
            }
            stringBuilder.Insert(0, RomanDictionary[50]);
            return;
        }

        if (digit == 90)
        {
            stringBuilder.Insert(0, RomanDictionary[100]);
            stringBuilder.Insert(0, RomanDictionary[10]);
            return;
        }

        if (digit < 400)
        {
            for (var i = 0; i < digit / 100; i++)
            {
                stringBuilder.Insert(0, RomanDictionary[100]);
            }
            return;
        }

        if (digit == 400)
        {
            stringBuilder.Insert(0, RomanDictionary[500]);
            stringBuilder.Insert(0, RomanDictionary[100]);
            return;
        }

        if (digit < 900)
        {
            for (var i = 0; i < (digit - 500) / 100; i++)
            {
                stringBuilder.Insert(0, RomanDictionary[100]);
            }
            stringBuilder.Insert(0, RomanDictionary[500]);
            return;
        }

        if (digit == 900)
        {            
            stringBuilder.Insert(0, RomanDictionary[1000]);
            stringBuilder.Insert(0, RomanDictionary[100]);
            return;
        }

        for (var i = 0; i < digit / 1000; i++)
        {
            stringBuilder.Insert(0, RomanDictionary[1000]);
        }
    }
}