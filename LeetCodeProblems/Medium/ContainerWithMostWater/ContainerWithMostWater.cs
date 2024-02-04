using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium.ContainerWithMostWater;

public class ContainerWithMostWater : BaseTest<int[], int>
{
    public override void Setup()
    {
        _inputs = new()
        {
            new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },
            new[] { 1, 1 },
            new[] { 1, 0, 0, 0, 0, 0, 0, 2, 2 },
            new[] { 2, 3, 10, 5, 7, 8, 9 },
            new[] { 2, 3, 4, 5, 18, 17, 6 },
            new[] { 1, 8, 6, 2, 5, 4, 8, 25, 7 },
            new[]
            {
                76, 155, 15, 188, 180, 154, 84, 34, 187, 142, 22, 5, 27, 183, 111, 128, 50, 58, 2, 112, 179, 2, 100,
                111, 115, 76, 134, 120, 118, 103, 31, 146, 58, 198, 134, 38, 104, 170, 25, 92, 112, 199, 49, 140, 135,
                160, 20, 185, 171, 23, 98, 150, 177, 198, 61, 92, 26, 147, 164, 144, 51, 196, 42, 109, 194, 177, 100,
                99, 99, 125, 143, 12, 76, 192, 152, 11, 152, 124, 197, 123, 147, 95, 73, 124, 45, 86, 168, 24, 34, 133,
                120, 85, 81, 163, 146, 75, 92, 198, 126, 191
            }
        };

        _outputs = new List<int>
        {
            49,
            1,
            8,
            36,
            17,
            49,
            18048
        };
    }

    protected override int Solve(int[] input)
    {
        var leftPointer = 0;
        var rightPointer = input.Length - 1;
        var area = 0;

        while (leftPointer < rightPointer)
        {
            var minHeight = Math.Min(input[leftPointer], input[rightPointer]);
            var pointersArea = minHeight * (rightPointer - leftPointer);
            area = Math.Max(area, pointersArea);

            if (input[leftPointer] > input[rightPointer]) rightPointer--;
            else leftPointer++;
        }

        return area;
    }
}