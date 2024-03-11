using System.Text;
using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium;
public class StringToInteger : BaseTest<string, int>
{
    public override void Setup()
    {
        _inputs = new List<string>
        {
            "42",
            "   -42",
            "4193 with words",
            "words and 987",
            "-91283472332",
            "+-12",
            "21474836460",
            "2147483648",
            "1"
        };

        _outputs = new List<int>
        {
            42,
            -42,
            4193,
            0,
            -2147483648,
            0,
            2147483647,
            2147483647,
            1
        };
    }

    protected override int Solve(string input)
    {
        var sb = new StringBuilder();
        input = input.Trim();
        for (var i = 0; i < input.Length; i++)
        {
            var value = input[i];
            if (char.IsLetter(value) || value.Equals('.'))
            {
                return 0;
            }

            if (char.IsDigit(value))
            {
                if (i > 1)
                {
                    return 0;
                }
                
                if (i > 0 && input[i - 1] == '-')
                {
                    sb.Append('-');
                }

                sb.Append(value);
                var numberIndex = i + 1;
                while (numberIndex < input.Length)
                {
                    if (char.IsDigit(input[numberIndex]))
                    {
                        sb.Append(input[numberIndex]);
                        numberIndex++;
                    }
                    else
                    {
                        var resultString = sb.ToString();
                        if (int.TryParse(resultString, out var result))
                        {
                            return result;
                        }

                        return resultString[0] == '-' ? int.MinValue : int.MaxValue;
                    }
                }
                
                if (numberIndex == input.Length)
                {
                    var resultString = sb.ToString();
                    if (int.TryParse(resultString, out var result))
                    {
                        return result;
                    }

                    return resultString[0] == '-' ? int.MinValue : int.MaxValue;
                }
            }
        }

        return 0;
    }
}