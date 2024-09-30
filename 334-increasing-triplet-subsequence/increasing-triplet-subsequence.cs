public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        // If the array has less than 3 elements, it's impossible to have an increasing triplet
        if (nums.Length < 3) return false;

        // Initialize two variables to track the smallest and second smallest values
        int a = int.MaxValue;  // 'a' will hold the smallest value encountered so far
        int b = int.MaxValue;  // 'b' will hold the second smallest value encountered so far

        // Iterate through the array
        foreach (var num in nums) {
            // If the current number is smaller or equal to 'a', update 'a' to be the current number
            if (num <= a) a = num;
            // Otherwise, if the current number is smaller or equal to 'b', update 'b' to be the current number
            else if (num <= b) b = num;
            // If the current number is greater than both 'a' and 'b', we have found a triplet (a < b < num)
            else return true;
        }

        // If we finish the loop without finding an increasing triplet, return false
        return false;
    }
}
