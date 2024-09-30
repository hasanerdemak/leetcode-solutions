public class Solution {
    public int Compress(char[] chars) {
        // Edge case: If the input array is empty, return 0
        if (chars.Length == 0) return 0;

        var index = 0;                  // 'index' will keep track of where we are writing the compressed characters
        var tempChar = chars[index++];  // 'tempChar' will store the current character we are processing
        var count = 0;                  // 'count' will keep track of how many times the current character is repeated
        
        // Iterate through each character in the input array
        foreach (var c in chars) {
            // If the current character 'c' is different from 'tempChar' (the previous character)
            if (c != tempChar) {
                // If the previous character had more than 1 occurrence, append the count to the array
                if (count > 1) {
                    var countStr = count.ToString(); // Convert the count to a string
                    // Append each digit of the count string to the array
                    foreach (var t in countStr) {
                        chars[index++] = t;
                    }
                }
                // Move to the new character
                chars[index++] = c;  // Write the current character to the array
                tempChar = c;        // Update 'tempChar' to the new character
                count = 1;           // Reset count to 1 for the new character
            } else {
                // If the current character is the same as 'tempChar', increase the count
                count++;
            }
        }

        // After the loop, handle the last group (if there was a count > 1)
        if (count > 1) {
            var countStr = count.ToString(); // Convert the count to a string
            // Append each digit of the count string to the array
            foreach (var t in countStr) {
                chars[index++] = t;
            }
        }

        // Return the length of the compressed array
        return index;
    }
}
