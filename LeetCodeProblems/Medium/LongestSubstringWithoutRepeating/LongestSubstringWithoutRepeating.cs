using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium.LongestSubstringWithoutRepeating;

public class LongestSubstringWithoutRepeating : BaseTest<string, int>
{
    public override void Setup()
    {
        _inputs = new List<string>
        {
            "abcabcbb",
            "bbbbb",
            "pwwkew",
            " ",
            "dvdf"
        };

        _outputs = new List<int>
        {
            3,
            1,
            3,
            1,
            3
        };
    }

    protected override int Solve(string input)
    {
        var dictionary = new Dictionary<char, int>();
        var result = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var letter = input[i];
            if (dictionary.ContainsKey(letter))
            {
                if (dictionary.Count > result)
                {
                    result = dictionary.Count;
                }

                i = dictionary[letter];
                dictionary.Clear();
                continue;
            }

            dictionary[letter] = i;
        }

        return Math.Max(dictionary.Count, result);
    }
}