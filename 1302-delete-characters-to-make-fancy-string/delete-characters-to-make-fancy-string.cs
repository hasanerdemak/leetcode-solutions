public class Solution {
    public string MakeFancyString(string s) {
        var sb = new StringBuilder();
        int count = 1;  // To track consecutive characters

        // Add the first character to the result as the starting point
        sb.Append(s[0]);

        for (int i = 1; i < s.Length; i++) {
            // If the current character is the same as the previous one, increase the count
            if (s[i] == s[i - 1]) {
                count++;
            } else {
                // Reset count if the character is different
                count = 1;
            }

            // Only add the character if it's not the third consecutive one
            if (count < 3) {
                sb.Append(s[i]);
            }
        }

        return sb.ToString();
    }
}