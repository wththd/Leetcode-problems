using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Easy.TwoSum;

public class TwoSumDictionary : BaseTest<int[], int, int[]>
{
    /// <summary>
    /// O(n) complexity, O(n) space
    /// </summary>
    
    public override void Setup()
    {
        _inputs = new List<int[]>
        {
            new[] { 2, 7, 11, 15 },
            new[] { 3, 2, 4 },
            new[] { 3, 3 }
        };

        _inputs2 = new List<int>
        {
            9,
            6,
            6
        };

        _outputs = new List<int[]>
        {
            new[] { 0, 1 },
            new[] { 1, 2 },
            new[] { 0, 1 }
        };
    }

    protected override int[] Solve(int[] input1, int input2)
    {
        var dictionary = new Dictionary<int, int>();
        for (var i = 0; i < input1.Length; i++)
        {
            var value = input1[i];
            var target = input2 - value;
            if (dictionary.ContainsKey(target))
            {
                return new[] { dictionary[target], i };
            }
            
            dictionary.Add(value, i);
        }
        
        return Array.Empty<int>();
    }
}