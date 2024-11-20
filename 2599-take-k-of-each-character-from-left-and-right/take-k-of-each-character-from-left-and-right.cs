public class Solution {
    public int TakeCharacters(string s, int k) {
        if (k == 0) return 0;

        // Count total occurrences of each character
        var totalCounts = new Dictionary<char, int>() { { 'a', 0 }, { 'b', 0 }, { 'c', 0 } };
        foreach (char c in s) totalCounts[c]++;

        // If any character count is less than k, return -1
        if (totalCounts['a'] < k || totalCounts['b'] < k || totalCounts['c'] < k) return -1;

        // Sliding window to minimize the characters left in the middle
        int n = s.Length;
        var currentCounts = new Dictionary<char, int>() { { 'a', 0 }, { 'b', 0 }, { 'c', 0 } };
        int maxWindowLength = 0, left = 0;

        for (int right = 0; right < n; right++) {
            currentCounts[s[right]]++;

            // Shrink the window if it leaves more than (totalCount - k) characters in the middle
            while (currentCounts['a'] > totalCounts['a'] - k ||
                   currentCounts['b'] > totalCounts['b'] - k ||
                   currentCounts['c'] > totalCounts['c'] - k) {
                currentCounts[s[left]]--;
                left++;
            }

            // Update max window length
            maxWindowLength = Math.Max(maxWindowLength, right - left + 1);
        }

        // Minimum minutes = total characters - maximum characters in the middle
        return n - maxWindowLength;
    }
}
