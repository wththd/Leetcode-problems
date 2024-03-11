using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Easy;

public class ValidParentheses : BaseTest<string, bool>
{
    public override void Setup()
    {
        _inputs = new List<string>()
        {
            "()",
            "()[]{}",
            "(]"
        };

        _outputs = new List<bool>()
        {
            true,
            true,
            false
        };
    }

    private Dictionary<char, char> Pairs = new Dictionary<char, char>()
    {
        { '(', ')' },
        { '{', '}' },
        { '[', ']' },
    };

    protected override bool Solve(string input)
    {        
        if (input.Length % 2 != 0) return false;

        var result = new Stack<char>();
        foreach (var letter in input)
        {
            if (Pairs.ContainsKey(letter))
            {
                result.Push(letter);
                continue;
            }
            
            if (result.Count == 0)
            {
                return false;
            }

            var value = result.Pop();
            if (Pairs[value] != letter)
            {
                return false;
            }
        }

        return result.Count == 0;
    }
}