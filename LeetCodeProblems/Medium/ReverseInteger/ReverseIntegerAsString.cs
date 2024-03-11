using System.Text;
using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium;
public class ReverseIntegerAsString : BaseTest<int, int>
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
        var result = new StringBuilder();
        var inputAsString = input.ToString();
        for (var i = inputAsString.Length - 1; i >= 0 ; i--)
        {
            var value = inputAsString[i];
            if (value == '-')
            {
                result.Insert(0, value);
            }
            else
            {
                result.Append(value);
            }
        }

        if (int.TryParse(result.ToString(), out var number))
        {
            return number;
        }

        return 0;
    }
}