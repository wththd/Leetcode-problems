using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium;
public class ThreeSumClosest : BaseTest<int[], int, int>
{
    public override void Setup()
    {
        _inputs = new List<int[]>
        {
            new[] { -1, 2, 1, -4 },
            new[] { 0, 0, 0 }
        };

        _inputs2 = new List<int>
        {
            1,
            1
        };

        _outputs = new List<int>
        {
            2,
            0
        };
    }

    protected override int Solve(int[] input, int input2)
    {
        var result = 0;
        var minDifference = int.MaxValue;
        
        Array.Sort(input);

        for (var i = 0; i < input.Length - 2; i++)
        {
            var left = i + 1;
            var right = input.Length - 1;
            while (left < right)
            {
                var sum = input[i] + input[left] + input[right];
                if (sum == input2)
                {
                    return sum;
                }
                
                var difference = Math.Abs(sum - input2);
                if (difference < minDifference)
                {
                    result = sum;
                    minDifference = difference;
                }

                if (sum > input2)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }

        return result;
    }
}