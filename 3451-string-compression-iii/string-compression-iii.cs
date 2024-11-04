public class Solution {
    public string CompressedString(string word) {
        StringBuilder compressed = new StringBuilder();
        int i = 0;
        
        while (i < word.Length)
        {
            char currentChar = word[i];
            int count = 0;
            
            // Count up to 9 consecutive characters of the same type
            while (i < word.Length && word[i] == currentChar && count < 9)
            {
                count++;
                i++;
            }
            
            // Append the count and character to the compressed result
            compressed.Append(count).Append(currentChar);
        }
        
        return compressed.ToString();
    }
}