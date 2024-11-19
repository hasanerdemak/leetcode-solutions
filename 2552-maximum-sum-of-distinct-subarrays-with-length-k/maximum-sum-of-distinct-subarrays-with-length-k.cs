public class Solution {
    public long MaximumSubarraySum(int[] nums, int k) {
        int n = nums.Length;
        if (k > n) return 0;

        HashSet<int> uniqueElements = new HashSet<int>();
        long maxSum = 0, currentSum = 0;
        int start = 0;

        for (int end = 0; end < n; end++)
        {
            // Add the current element to the sum and set
            currentSum += nums[end];
            while (!uniqueElements.Add(nums[end]))
            {
                // If the element is already in the set, shrink the window
                uniqueElements.Remove(nums[start]);
                currentSum -= nums[start];
                start++;
            }

            // Check if the window size is valid
            if (end - start + 1 == k)
            {
                maxSum = Math.Max(maxSum, currentSum);

                // Shrink the window to prepare for the next iteration
                uniqueElements.Remove(nums[start]);
                currentSum -= nums[start];
                start++;
            }
        }

        return maxSum;
    }
}