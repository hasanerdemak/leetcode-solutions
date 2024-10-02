public class Solution {
    public int LargestAltitude(int[] gain) {
        var current = 0; // Initialize the starting altitude at point 0
        var max = 0; // 'max' will track the highest altitude reached during the trip

        // Iterate through the 'gain' array to compute the altitude changes
        foreach (var g in gain) {
            // Update the current altitude by adding the gain value
            current += g; 
            // Update the max altitude if the current altitude is higher
            max = Math.Max(max, current);
        }

        // Return the highest altitude reached
        return max;
    }
}
