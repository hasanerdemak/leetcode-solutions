public class Solution {
    public string ReverseWords(string s) {
        // Split the input string into words, removing any empty entries caused by multiple spaces
        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        // Initialize a StringBuilder to construct the reversed string
        var result = new StringBuilder();
        
        // Iterate over the words in reverse order
        for (int i = words.Length - 1; i >= 0; i--) {
            // Append each word followed by a space
            result.Append(words[i] + " ");
        }

        // Remove the trailing space and return the result
        return result.ToString().TrimEnd();
    }
}
