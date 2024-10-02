public class Solution {
    public int PivotIndex(int[] nums) {
        // Initialize leftSum to 0 as there's no element on the left of the first index
        var leftSum = 0;
        // Calculate the total sum of the array, which will be used as the right sum initially
        var rightSum = nums.Sum();

        // Iterate through the array
        for (int i = 0; i < nums.Length; i++) {
            // We subtract the current element from rightSum as it no longer belongs to the right side
            rightSum -= nums[i];

            // Check if leftSum is equal to rightSum at this index
            if (leftSum == rightSum) {
                return i; // Pivot index found
            }

            // Add the current element to leftSum as we move the pivot to the right
            leftSum += nums[i];
        }

        // If no pivot index is found, return -1
        return -1;
    }
}
