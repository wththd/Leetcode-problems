using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium.ReverseInteger;

public class ReverseIntegerAsNumber : BaseTest<int, int>
{
    public override void Setup()
    {
        _inputs = new List<int>
        {
            123,
            -123,
            120,
            -2147483412
        };

        _outputs = new List<int>
        {
            321,
            -321,
            21,
            -2143847412
        };
    }

    protected override int Solve(int input)
    {
        var result = 0;
        
        while (input != 0)
        {
            var addition = input % 10;
            input /= 10;
            if (int.MaxValue / 10 < result || int.MinValue / 10 > result)
            {
                return 0;
            }
            result = result * 10 + addition;
        }

        return result;
    }
}