public class Solution {
    public IList<string> LetterCombinations(string digits) {
        // Check if the input is empty
        if (string.IsNullOrEmpty(digits)) return new List<string>();

        // Mapping of digits to corresponding letters
        var phoneMap = new Dictionary<char, string> {
            {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"},
            {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}
        };

        var result = new List<string>();
        Backtrack(digits, 0, "", result, phoneMap);
        return result;
    }

    // Recursive backtracking method to build combinations
    private void Backtrack(string digits, int index, string current, IList<string> result, Dictionary<char, string> phoneMap) {
        // If we've reached the end of the digits string, add the combination to the result
        if (index == digits.Length) {
            result.Add(current);
            return;
        }

        // Get the letters for the current digit
        string letters = phoneMap[digits[index]];

        // Recursively append each letter and move to the next digit
        foreach (char letter in letters) {
            Backtrack(digits, index + 1, current + letter, result, phoneMap);
        }
    }
}
