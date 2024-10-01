public class Solution {
    public int LongestSubarray(int[] nums) {
        var n = nums.Length;
        
        // Initialize two pointers 'left' and 'right' for the sliding window approach
        var left = 0;
        var right = 0;
        
        // 'k' represents the number of 0's we are allowed to remove (only one is allowed in this problem)
        var k = 1;

        // Iterate over the array using the 'right' pointer
        while (right < n) {
            // If we encounter a 0, decrement k
            if (nums[right] == 0) k--;
            
            // If more than one 0 has been removed (k < 0), shrink the window from the left
            if (k < 0) {
                // If the left pointer is at a 0, increment k since we're no longer removing that 0
                if (nums[left] == 0) k++;
                
                // Move the left pointer to shrink the window
                left++;
            }
            
            // Move the right pointer to expand the window
            right++;
        }

        // The final result is the size of the longest subarray of 1's, but we must subtract 1
        // since the problem requires us to delete exactly one element.
        return right - left - 1;
    }
}
