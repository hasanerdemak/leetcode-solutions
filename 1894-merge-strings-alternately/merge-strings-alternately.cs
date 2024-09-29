public class Solution {
    public string MergeAlternately(string word1, string word2) {
        // Create a StringBuilder to store the merged result
        var result = new StringBuilder();
        
        // Initialize a counter to keep track of the current index for both strings
        int i = 0;
        
        // Traverse strings as long as there are characters left in either 'word1' or 'word2'
        while (i < word1.Length || i < word2.Length) {
            // If there are still characters left in 'word1' or 'word2', append the characters at index 'i' to 'result' respectively
            if (i < word1.Length) {
                result.Append(word1[i]);
            }
            if (i < word2.Length) {
                result.Append(word2[i]);
            }

            // Increment the index counter to move to the next characters
            i++;
        }

        // Convert the StringBuilder to a string and return the merged result
        return result.ToString();
    }
}