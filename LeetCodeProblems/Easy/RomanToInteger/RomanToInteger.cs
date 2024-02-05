using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Easy.RomanToInteger;

public class RomanToInteger : BaseTest<string, int>
{
    public override void Setup()
    {
        _inputs = new List<string>
        {
            "III",
            "LVIII",
            "MCMXCIV"
        };

        _outputs = new List<int>
        {
            3,
            58,
            1994
        };
    }
    
    private Dictionary<char, int> RomanDictionary = new Dictionary<char, int>
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    protected override int Solve(string input)
    {
        var result = RomanDictionary[input[0]];
        var previousNumber = result;
        for (var i = 1; i < input.Length; i++)
        {
            var digit = input[i];
            var number = RomanDictionary[digit];
            if (previousNumber < number)
            {
                number -= 2 * previousNumber;
            }

            previousNumber = number;
            result += number;
        }

        return result;
    }
}