using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium.ThreeSum;

public class ThreeSum : BaseTest<int[], List<IList<int>>>
{
    public override void Setup()
    {
        _inputs = new List<int[]>
        {
            new[] { -1, 0, 1, 2, -1, -4 },
            new[] { 0, 1, 1 },
            new[] { 0, 0, 0 },
            new[] { 0, 0, 0, 0 }
        };

        _outputs = new List<List<IList<int>>>()
        {
            new List<IList<int>>
            {
                new List<int>
                {
                    -1,-1,2
                },
                new List<int>
                {
                    -1,0,1
                }
            },
            new List<IList<int>>
            {
            },
            new List<IList<int>>
            {
                new List<int>
                {
                    0, 0, 0
                }
            },
            new List<IList<int>>
            {
                new List<int>
                {
                    0, 0, 0
                }
            }
        };
    }

    protected override List<IList<int>> Solve(int[] input)
    {
        var result = new List<IList<int>>();
        if (input.Length < 2)
        {
            return result;
        }
        
        Array.Sort(input);

        for (var i = 0; i < input.Length - 2; i++)
        {
            var firstNumber = input[i];
            if (firstNumber > 0) break;
            if (i > 0 && firstNumber == input[i - 1]) continue;
            var nextIndex = i + 1;
            var lastIndex = input.Length - 1;
            while (nextIndex < lastIndex)
            {
                var sum = firstNumber + input[nextIndex] + input[lastIndex];
                if (sum == 0)
                {
                    var resultList = new List<int> { firstNumber, input[nextIndex], input[lastIndex] };
                    result.Add(resultList);
                    nextIndex++;
                    while(input[nextIndex] == input[nextIndex-1] && nextIndex < lastIndex)
                    {
                        nextIndex++;
                    }
                } else if (sum < 0)
                {
                    nextIndex++;
                }
                else
                {
                    lastIndex--;
                }
            }
        }
        
        return result;
    }
}