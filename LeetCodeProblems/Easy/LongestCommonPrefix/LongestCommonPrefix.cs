using System.Text;
using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Easy.LongestCommonPrefix;

public class LongestCommonPrefix : BaseTest<string[], string>
{
    public override void Setup()
    {
        _inputs = new List<string[]>
        {
            new[] { "flower", "flow", "flight" },
            new[] { "dog", "racecar", "car" },
            new[] { "" }
        };

        _outputs = new List<string>
        {
            "fl",
            "",
            ""
        };
    }

    protected override string Solve(string[] input)
    {
        var sb = new StringBuilder();
        for (var i = 0; i <= 200; i++)
        {
            if (input[0].Length == i)
            {
                return sb.ToString();
            }
            
            var targetChar = input[0][i];
            for (var j = 1; j < input.Length; j++)
            {
                if (input[j].Length == i)
                {
                    return sb.ToString();
                }
                
                if (input[j][i] != targetChar)
                {
                    return sb.ToString();
                }
            }

            sb.Append(targetChar);
        }

        return sb.ToString();
    }
}