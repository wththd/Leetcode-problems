using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Easy.NumberPalindrome;

public class NumberPalindrome : BaseTest<int, bool>
{
    public override void Setup()
    {
        _inputs = new List<int>()
        {
            121,
            -121,
            10
        };

        _outputs = new List<bool>
        {
            true,
            false,
            false
        };
    }

    protected override bool Solve(int input)
    {
        if (input < 0)
        {
            return false;
        }

        var reversedNumber = 0;
        var targetNumber = input;
        while (targetNumber != 0)
        {
            reversedNumber = reversedNumber * 10 + targetNumber % 10;
            targetNumber /= 10;
        }

        return reversedNumber == input;
    }
}