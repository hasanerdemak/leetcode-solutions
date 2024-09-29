public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        // If there is a common divisor, then str1 + str2 must be the same string as str2 + str1
        if (str1 + str2 != str2 + str1) return "";

        // Find the greatest common divisor (GCD) of the lengths of the two strings
        var gcd = GCD(str1.Length, str2.Length);

        // Return the substring of str1 from index 0 to the length of the GCD.
        // This substring is the greatest common divisor string.
        return str1.Substring(0, gcd);
    }

    // Helper method to calculate the GCD of two integers using the Euclidean algorithm
    private int GCD(int a, int b){
        // If b becomes 0, return a as the GCD. Otherwise, recursively calculate the GCD.
        return b == 0 ? a : GCD(b, a % b);
    }
}