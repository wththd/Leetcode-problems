using LeetCodeProblems.Basic;

namespace LeetCodeProblems;

public class TestIntTest : BaseTest<int ,int>
{
    public override void Setup()
    {
        _inputs = new List<int>
        {
            1, 2, 3
        };

        _outputs = new List<int>
        {
            1, 2, 3
        };
    }

    protected override int Solve(int input)
    {
        return input;
    }
}