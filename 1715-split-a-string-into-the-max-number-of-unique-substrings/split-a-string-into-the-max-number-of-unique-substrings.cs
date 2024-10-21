public class Solution {
    public int MaxUniqueSplit(string s) {
        return Backtrack(s, new HashSet<string>(), 0);
    }

    private int Backtrack(string s, HashSet<string> uniqueSubstrings, int start) {
        // Base case: if we reach the end of the string, return 0 as no more splits can be made
        if (start == s.Length) {
            return 0;
        }

        int maxCount = 0;

        // Try splitting at all possible positions starting from 'start'
        for (int i = start; i < s.Length; i++) {
            string currentSubstring = s.Substring(start, i - start + 1);
            
            // If this substring is not used, we try to add it and continue
            if (!uniqueSubstrings.Contains(currentSubstring)) {
                uniqueSubstrings.Add(currentSubstring);
                // Recursively try splitting the remaining string and add 1 to the result
                maxCount = Math.Max(maxCount, 1 + Backtrack(s, uniqueSubstrings, i + 1));
                // Backtrack: remove the substring to explore other possibilities
                uniqueSubstrings.Remove(currentSubstring);
            }
        }

        return maxCount;
    }
}