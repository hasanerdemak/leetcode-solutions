public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        int n = arr.Length;
        int left = 0;
        
        // Find the non-decreasing prefix
        while (left + 1 < n && arr[left] <= arr[left + 1]) {
            left++;
        }
        
        // If the entire array is non-decreasing
        if (left == n - 1) return 0;
        
        int right = n - 1;
        
        // Find the non-decreasing suffix
        while (right > left && arr[right - 1] <= arr[right]) {
            right--;
        }
        
        // The minimum to remove is either the suffix or the prefix
        int res = Math.Min(n - left - 1, right);
        
        // Try to find a pair of prefix and suffix
        int i = 0;
        int j = right;
        while (i <= left && j < n) {
            if (arr[j] >= arr[i]) {
                res = Math.Min(res, j - i - 1);
                i++;
            }
            else {
                j++;
            }
        }
        
        return res;
    }
}
