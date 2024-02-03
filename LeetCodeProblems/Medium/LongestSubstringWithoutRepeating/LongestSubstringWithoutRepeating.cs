using System.Collections;
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
        var hashSet = new HashSet<char>();
        var result = 0;
        foreach (var letter in input)
        {
            if (hashSet.Contains(letter))
            {
                if (hashSet.Count > result)
                {
                    result = hashSet.Count;
                }
                
                hashSet.Clear();
            }
            
            hashSet.Add(letter);
        }

        return Math.Max(hashSet.Count, result);
    }
}