using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium.LongestPalindromicSubstring;

public class LongestPalindromicSubstring : BaseTest<string, string>
{
    public override void Setup()
    {
        _inputs = new List<string>()
        {
            "babad",
            "cbbd"
        };

        _outputs = new List<string>()
        {
            "bab",
            "bb"
        };
    }

    protected override string Solve(string input)
    {
        var maxLength = 0;
        var result = "";
        for (var i = 0; i < input.Length; i++) {
            
            // Check for odd palindrome
            var start = i;
            var end = i;
            while (start >= 0 && end < input.Length && input[start] == input[end]) {
                if (end - start + 1 > maxLength) {
                    maxLength = Math.Max(maxLength, end - start + 1);
                    result = input.Substring(start, end - start + 1);
                }
                
                start--;
                end++;
            }

            // Check for even palindrome
            start = i;
            end = i + 1;
            while(start >= 0 && end < input.Length && input[start] == input[end]) {
                if (end - start + 1 > maxLength) {
                    maxLength = Math.Max(maxLength, end - start + 1);
                    result = input.Substring(start, end - start + 1);
                }
                
                start--;
                end++;
            }
        }
        
        return result;
    }
}