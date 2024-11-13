public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        int n = nums.Length;
        long count = 0;

        for(int i = 0; i < n-1; i++) {
            long targetLower = (long)lower - nums[i];
            long targetUpper = (long)upper - nums[i];

            int lowerIndex = LowerBound(nums, i + 1, n, targetLower);
            int upperIndex = UpperBound(nums, i + 1, n, targetUpper) - 1;

            if (lowerIndex < n && upperIndex >= lowerIndex) {
                count += (upperIndex - lowerIndex + 1);
            }
        }

        return count;
    }

    // Finds the first index in nums[start..end) where nums[index] >= target
    private int LowerBound(int[] nums, int start, int end, long target) {
        int left = start;
        int right = end;
        while(left < right){
            int mid = left + (right - left)/2;
            if((long)nums[mid] < target){
                left = mid + 1;
            }
            else{
                right = mid;
            }
        }
        return left;
    }

    // Finds the first index in nums[start..end) where nums[index] > target
    private int UpperBound(int[] nums, int start, int end, long target) {
        int left = start;
        int right = end;
        while(left < right){
            int mid = left + (right - left)/2;
            if((long)nums[mid] <= target){
                left = mid + 1;
            }
            else{
                right = mid;
            }
        }
        return left;
    }
}
