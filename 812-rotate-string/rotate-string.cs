public class Solution {
    public bool RotateString(string s, string goal) {
        if (s.Length != goal.Length) return false;

        // Concatenate s with itself and check if goal is a substring
        string concatenated = s + s;
        return concatenated.Contains(goal);
    }
}