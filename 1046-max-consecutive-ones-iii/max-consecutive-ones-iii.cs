public class Solution {
    public int LongestOnes(int[] nums, int k) {
        // Two pointers: left is the start of the current window, right is the end
        var left = 0;
        var right = 0;

        // Traverse the array with the right pointer
        while (right < nums.Length) {
            // If we encounter a 0, decrease the available number of flips (k)
            if (nums[right] == 0) k--;

            // If k is less than 0, it means we have flipped more than the allowed number of 0's
            // So, we need to adjust the left pointer to shrink the window
            if (k < 0) {
                // If the element at the left pointer was a 0, we need to undo that flip (increase k)
                if (nums[left] == 0) k++;

                // Move the left pointer forward to reduce the window size
                left++;
            }

            // Move the right pointer to the next element, expanding the window
            right++;
        }

        // The length of the longest window containing the maximum number of 1's is (right - left)
        return right - left;
    }
}