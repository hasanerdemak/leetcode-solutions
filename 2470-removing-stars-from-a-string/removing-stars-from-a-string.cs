public class Solution {
    public string RemoveStars(string s) {
        var sb = new StringBuilder();
        foreach (char c in s) {
            if (c == '*') {
                // Remove the last character from StringBuilder when a star is found
                sb.Length--;
            } else {
                // Append non-star characters to StringBuilder
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}