public class Solution {
    public int MinimumSubarrayLength(int[] nums, int k) {
        if (k == 0) return 1; // Any non-empty subarray satisfies OR >= 0

        int n = nums.Length;
        int minLength = int.MaxValue;

        // Dictionary to store OR values and their minimum lengths for subarrays ending at previous index
        Dictionary<int, int> prevORs = new Dictionary<int, int>();

        foreach (int num in nums) {
            Dictionary<int, int> currentORs = new Dictionary<int, int>();

            // Start a new subarray with the current number
            currentORs[num] = 1;

            // Extend previous subarrays by OR-ing with current number
            foreach (var entry in prevORs) {
                int newOR = entry.Key | num;
                int newLength = entry.Value + 1;

                if (currentORs.ContainsKey(newOR)) {
                    currentORs[newOR] = Math.Min(currentORs[newOR], newLength);
                } else {
                    currentORs[newOR] = newLength;
                }
            }

            // Check if any OR value meets or exceeds k
            foreach (var entry in currentORs) {
                if (entry.Key >= k) {
                    minLength = Math.Min(minLength, entry.Value);
                }
            }

            // Update prevORs for the next iteration
            prevORs = currentORs;
        }

        return minLength == int.MaxValue ? -1 : minLength;
    }
}