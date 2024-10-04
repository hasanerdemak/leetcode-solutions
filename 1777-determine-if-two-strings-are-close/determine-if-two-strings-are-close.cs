public class Solution {
    public bool CloseStrings(string word1, string word2) {
        // If the lengths are not equal, return false
        if (word1.Length != word2.Length) return false;

        // Frequency arrays to count occurrences of each character
        var freq1 = new int[26];
        var freq2 = new int[26];
        
        // Sets to store unique characters
        var set1 = new HashSet<char>();
        var set2 = new HashSet<char>();

        // Populate frequency arrays and sets for both words
        for (int i = 0; i < word1.Length; i++) {
            freq1[word1[i] - 'a']++;
            freq2[word2[i] - 'a']++;
            set1.Add(word1[i]);
            set2.Add(word2[i]);
        }

        // Check if the unique characters in both strings are the same
        if (!set1.SetEquals(set2)) return false;

        // Sort the frequency arrays to compare character frequency distributions
        Array.Sort(freq1);
        Array.Sort(freq2);
        
        // Check if the sorted frequencies are the same
        for (int i = 0; i < 26; i++) {
            if (freq1[i] != freq2[i]) return false;
        }

        // If all conditions are satisfied, return true
        return true;
    }
}
