using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium;

public class LetterCombinationsOfAPhoneNumber : BaseTest<string, string[]>
{
    public override void Setup()
    {
        _inputs = new List<string>
        {
            "23",
            "",
            "2"
        };

        _outputs = new List<string[]>
        {
            new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" },
            Array.Empty<string>(),
            new[] {"a","b","c"}
        };
    }

    private readonly Dictionary<char, char[]> NumberToTextDictionary = new Dictionary<char, char[]>
    {
        { '2', new[] { 'a', 'b', 'c' } },
        { '3', new[] { 'd', 'e', 'f' } },
        { '4', new[] { 'g', 'h', 'i' } },
        { '5', new[] { 'j', 'k', 'l' } },
        { '6', new[] { 'm', 'n', 'c' } },
        { '7', new[] { 'p', 'q', 'r', 's' } },
        { '8', new[] { 't', 'u', 'v' } },
        { '9', new[] { 'w', 'x', 'y', 'z' } }
    };

    protected override string[] Solve(string input)
    {
        var result = new List<string>();
        foreach (var numberChar in input)
        {
            result = AddNextNumber(numberChar, result);
        }

        return result.ToArray();
    }

    private List<string> AddNextNumber(char number, List<string> currentValues)
    {
        var result = new List<string>();
        var valuesToAdd = NumberToTextDictionary[number];
        if (currentValues.Count == 0)
        {
            foreach (var value in valuesToAdd)
            {
                result.Add(value.ToString());
            }
        }
        else
        {
            foreach (var value in currentValues)
            {
                foreach (var charValue in valuesToAdd)
                {
                    result.Add(value + charValue);
                }
            }
        }

        return result;
    }
}