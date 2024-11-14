public class Solution {
    public int MinimizedMaximum(int n, int[] quantities) {
        if (quantities == null || quantities.Length == 0) return 0;

        int left = 1;
        int right = 0;
        foreach (var q in quantities) {
            if (q > right) right = q;
        }

        int result = right;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            long totalStores = 0;
            foreach (var q in quantities) {
                totalStores += (q + mid - 1) / mid; // Equivalent to ceil(q / mid)
                if (totalStores > n) break; // Early termination if exceeding
            }

            if (totalStores <= n) {
                result = mid;
                right = mid - 1;
            }
            else {
                left = mid + 1;
            }
        }

        return result;
    }
}
