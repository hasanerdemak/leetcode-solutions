public class Solution {
    public int[] GetMaximumXor(int[] nums, int maximumBit) {
        int n = nums.Length;
        int[] answer = new int[n];
        
        // Calculate the maximum k value possible for the given maximumBit
        int maxKValue = (1 << maximumBit) - 1;
        
        // Compute the XOR of all elements in nums
        int totalXor = 0;
        foreach (var num in nums) {
            totalXor ^= num;
        }
        
        // Answer the queries by working from the end of nums to the beginning
        for (int i = 0; i < n; i++) {
            // k is chosen to maximize the XOR
            answer[i] = totalXor ^ maxKValue;
            
            // Remove the last element of nums in the cumulative XOR
            totalXor ^= nums[n - 1 - i];
        }
        
        return answer;
    }
}