using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium.FourSum;

public class FourSum : BaseTest<int[], int, List<List<int>>> 
{
    public override void Setup()
    {
        _inputs = new List<int[]>
        {
            // -2 -1 0 0 1 2
            new [] { 1, 0, -1, 0, -2, 2 },
            new[] { 2, 2, 2, 2, 2 },
            new[] { 1000000000, 1000000000, 1000000000, 1000000000 }
        };

        _inputs2 = new List<int>
        {
            0, 8, -294967296
        };

        _outputs = new List<List<List<int>>>()
        {
            new()
            {
                new()
                {
                    -2, -1, 1, 2
                },
                new()
                {
                    -2, 0, 0, 2
                },
                new()
                {
                    -1, 0, 0, 1
                }
            },
            new ()
            {
                new ()
                {
                    2, 2, 2, 2
                }
            },
            new ()
            {
                
            }
        };
    }

    protected override List<List<int>> Solve(int[] input, int input2)
    {
        var result = new List<List<int>>();
        Array.Sort(input);
        for (var i = 0; i < input.Length - 3; i++)
        {
            if (i > 0 && input[i] == input[i - 1]) continue;
            
            var firstNumber = input[i];
            for (var j = i + 1; j < input.Length - 2; j++)
            {
                if (j > i + 1 && input[j] == input[j - 1]) continue;

                var secondNumber = input[j];
                var leftIndex = j + 1;
                var rightIndex = input.Length - 1;
                var target = input2 - (long)(firstNumber + secondNumber);
                while (leftIndex < rightIndex)
                {
                    var sum = (long)(input[leftIndex] + input[rightIndex]);
                    if (sum == target)
                    {
                        result.Add(new List<int>{ firstNumber, secondNumber, input[leftIndex], input[rightIndex]});
                        leftIndex++;
                        while (leftIndex < rightIndex && input[leftIndex] == input[leftIndex - 1]) leftIndex++;
                    } else if (sum < target)
                    {
                        leftIndex++;
                    }
                    else
                    {
                        rightIndex--;
                    }
                }
            }
        }
        
        return result;
    }
}