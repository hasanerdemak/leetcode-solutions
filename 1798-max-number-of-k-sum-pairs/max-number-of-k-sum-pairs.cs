public class Solution {
    public int MaxOperations(int[] nums, int k) {
        var dict = new Dictionary<int, int>(); // Dictionary to store number frequencies
        var count = 0;  // Counter to keep track of the number of operations

        // Iterate over each number in the array
        for (int i = 0; i < nums.Length; i++) {
            var res = k - nums[i];  // Calculate the required pair value to sum up to k
            // If the required pair exists in the dictionary
            if (dict.ContainsKey(res)) {
                count++;  // Increment the count for a valid pair
                // Decrement or remove the frequency of the pair
                if (dict[res] == 1) dict.Remove(res);  // Remove if frequency is 1
                else dict[res] = dict[res] - 1;  // Otherwise, decrement the frequency
            } else {
                // If the number doesn't have a pair, update its frequency in the dictionary
                if (dict.ContainsKey(nums[i])) {
                    dict[nums[i]] += 1;  // Increment its frequency if already present
                } else {
                    dict.Add(nums[i], 1);  // Add to the dictionary if not present
                }
            }
        }

        return count;  // Return the number of operations (valid pairs)
    }
}
