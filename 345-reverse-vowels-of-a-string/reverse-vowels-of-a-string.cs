public class Solution {
    public string ReverseVowels(string s) {
        // Convert the input string to a character array for easier manipulation
        var chars = s.ToCharArray();

        // Two pointers, one starting from the beginning and the other from the end of the string
        var i = 0;
        var j = s.Length - 1;

        // Iterate until the two pointers meet
        while (i < j) {
            // Move the left pointer forward if the current character is not a vowel
            if (!isVowel(s[i])) {
                i++;
            }

            // Move the right pointer backward if the current character is not a vowel
            if (!isVowel(s[j])) {
                j--;
            }

            // If both pointers point to vowels, swap them
            if (isVowel(s[i]) && isVowel(s[j])) {
                var temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;

                // Move both pointers toward the center
                i++;
                j--;
            }
        }        

        // Convert the character array back to a string and return the result
        return new string(chars);
    }

    // Helper function to check if a character is a vowel (both lowercase and uppercase)
    private bool isVowel(char c) {
        return "aeiouAEIOU".IndexOf(c) >= 0;
    }
}
