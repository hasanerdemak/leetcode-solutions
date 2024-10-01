public class Solution {
    public bool IsSubsequence(string s, string t) {
        // Initialize two pointers: 'i' for string 's' and 'j' for string 't'
        var i = 0; // Tracks the current character in 's'
        var j = 0; // Tracks the current character in 't'

        // Iterate through both strings until we reach the end of one of them
        while (i < s.Length && j < t.Length) {
            // If the current characters of 's' and 't' match, move to the next character in 's'
            if (t[j] == s[i]) i++;
            
            // Always move to the next character in 't'
            j++;
        }

        // If 'i' has reached the end of 's', it means 's' is a subsequence of 't'
        return i == s.Length;
    }
}
