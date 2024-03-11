using System.Text;
using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium;
public class ZigZagConversionStringBuilder : BaseTest<string, int, string>
{
    /// <summary>
    /// O(N) with direction, string builder with index calculation
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
        if (input2 == 1 || input.Length <= 1) {
            return input;
        }

        var sb = new StringBuilder();
        for (var r = 0; r < input2; r++) {
            var increment = 2 * (input2 - 1);
            for (var i = r; i < input.Length; i += increment) {
                sb.Append(input[i]);
                if (r > 0 && r < input2 - 1 && i + increment - 2 * r < input.Length) {
                    sb.Append(input[i + increment - 2 * r]);
                }
            }
        }

        return sb.ToString();
    }
}