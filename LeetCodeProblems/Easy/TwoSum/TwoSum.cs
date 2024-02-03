using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Easy.TwoSum;

public class TwoSum : BaseTest<int[], int, int[]>
{
    /// <summary>
    /// O(n^2) complexity, O(1) space
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
        var result = new int[2];
        for (var i = 0; i < input1.Length; i++)
        {
            for (var j = input1.Length - 1; j > i; j--)
            {
                if (input1[i] + input1[j] == input2)
                {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }
        
        return result;
    }
}