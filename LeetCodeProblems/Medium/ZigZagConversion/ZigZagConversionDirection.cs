using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium.ZigZagConversion;

public class ZigZagConversionDirection : BaseTest<string, int, string>
{
    /// <summary>
    /// O(N) with direction, 3 arrays with strings
    /// </summary>
    
    public override void Setup()
    {
        _inputs = new List<string>()
        {
            "PAYPALISHIRING",
            "PAYPALISHIRING",
            "A"
        };

        _inputs2 = new List<int>()
        {
            3,
            4,
            1
        };

        _outputs = new List<string>()
        {
            "PAHNAPLSIIGYIR",
            "PINALSIGYAHRPI",
            "A"
        };
    }

    protected override string Solve(string input, int input2)
    {
        if (input2 == 1 || input.Length <= 1)
        {
            return input;
        }

        var result = new string[input2];

        var i = 0;
        var direction = 1;
        
        foreach(var letter in input)
        {
            result[i] += letter;

            i += direction;

            if (i == input2-1 || i==0) direction *= -1;
        }

        return string.Concat(result);
    }
}