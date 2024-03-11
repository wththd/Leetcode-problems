using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Hard;

public class RegularExpressionMatching : BaseTest<string, string, bool>
{
    public override void Setup()
    {
        _inputs = new List<string>()
        {
            "aa",
            "aa",
            "ab",
            "aab",
            "mississippi"
        };

        _inputs2 = new List<string>()
        {
            "a",
            "a*",
            ".*",
            "c*a*b",
            "mis*is*p*."
        };

        _outputs = new List<bool>()
        {
            false,
            true,
            true,
            true,
            false
        };
    }

    protected override bool Solve(string input, string input2)
    {
        if (string.IsNullOrEmpty(input2))
        {
            return string.IsNullOrEmpty(input);
        }

        var firstMatch = !string.IsNullOrEmpty(input) &&
                         (input2[0] == input[0] || input2[0] == '.');

        if (input2.Length >= 2 && input2[1] == '*')
        {
            return Solve(input, input2.Substring(2)) ||
                   firstMatch && Solve(input.Substring(1), input2);
        }

        return firstMatch && Solve(input.Substring(1), input2.Substring(1));
    }
}