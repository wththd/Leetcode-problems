using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium;
public class StringToIntegerWithNumber : BaseTest<string, int>
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
            "1",
            ""
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
            1,
            0
        };
    }

    protected override int Solve(string input)
    {
        var multiplier = 1;
        var result = 0;
        var position = 0;
        input = input.TrimStart();
        if (input.Length == 0)
        {
            return 0;
        }
        
        if (input[0] == '-')
        {
            multiplier = -1;
            position++;
        } else if (input[0] == '+')
        {
            multiplier = 1;
            position++;
        }
        
        while (position < input.Length && char.IsDigit(input[position]))
        {
            var digit = input[position] - '0';
            if (result > int.MaxValue / 10 || 
                result == int.MaxValue / 10 && digit > int.MaxValue % 10) {     
                return multiplier == 1 ? int.MaxValue : int.MinValue;
            }
            
            result = 10 * result + digit;
            position++;
        }

        return result * multiplier;
    }
}