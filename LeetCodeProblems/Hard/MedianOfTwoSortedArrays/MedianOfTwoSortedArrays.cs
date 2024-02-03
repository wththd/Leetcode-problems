using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Hard.MedianOfTwoSortedArrays;

public class MedianOfTwoSortedArrays : BaseTest<int[], int[], float>
{
    /// <summary>
    /// Quick sort O(n log n) average
    /// </summary>
    public override void Setup()
    {
        _inputs = new List<int[]>
        {
            new[] { 1, 3 },
            new[] { 1, 2 }
        };
        
        _inputs2 = new List<int[]>
        {
            new[] { 2 },
            new[] { 3,4 }
        };

        _outputs = new List<float>
        {
            2f,
            2.5f
        };
    }

    protected override float Solve(int[] input1, int[] input2)
    {
        var resultArray = new int[input1.Length + input2.Length];
        Array.Copy(input1, resultArray, input1.Length);
        Array.Copy(input2, 0, resultArray, input1.Length, input2.Length);
        Array.Sort(resultArray);
        return resultArray.Length % 2 == 1
            ? resultArray[resultArray.Length / 2]
            : (float)(resultArray[resultArray.Length / 2 - 1] + resultArray[resultArray.Length / 2]) / 2;
    }
}