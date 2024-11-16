public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        int n = nums.Length;
        int resLength = n - k + 1;
        int[] results = new int[resLength];
        
        for(int i = 0; i < resLength; i++) {
            bool isValid = true;
            for(int j = 1; j < k; j++) {
                if(nums[i+j] != nums[i+j-1] + 1) {
                    isValid = false;
                    break;
                }
            }
            if(isValid) {
                results[i] = nums[i+k-1];
            }
            else {
                results[i] = -1;
            }
        }
        
        return results;
    }
}