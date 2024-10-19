public class Solution {
    public char FindKthBit(int n, int k) {
        // Initialize the base case for the binary string sequence, S1 = "0".
        var temp = "0";

        // Iteratively build the binary string for Sn following the pattern:
        // Si = Si-1 + "1" + reverse(invert(Si-1))
        for (int i = 2; i <= n; i++) {
            // Build the next sequence by concatenating "1", the reversed and inverted previous sequence.
            temp = temp + "1" + Reverse(Invert(temp));
        }

        // Return the k-th bit in the resulting Sn string (using 0-based indexing, so k-1).
        return temp[k - 1];
    }

    // Helper function to reverse a string.
    private string Reverse(string s) {
        // Convert the string to a character array, reverse it, and convert it back to a string.
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // Helper function to invert a binary string (flip '0' to '1' and '1' to '0').
    private string Invert(string s) {
        char[] inverted = new char[s.Length];
        for (int i = 0; i < s.Length; i++) {
            inverted[i] = s[i] == '1' ? '0' : '1';
        }
        return new string(inverted);
    }
}