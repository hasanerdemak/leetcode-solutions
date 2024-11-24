public class Solution {
    public long MaxMatrixSum(int[][] matrix) {
        int n = matrix.Length;
        long totalSum = 0;
        int negativeCount = 0;
        int minAbsValue = int.MaxValue;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int value = matrix[i][j];
                totalSum += Math.Abs(value); // Add the absolute value
                if (value < 0) negativeCount++; // Count negatives
                minAbsValue = Math.Min(minAbsValue, Math.Abs(value)); // Track the smallest absolute value
            }
        }

        // If odd number of negatives, adjust by removing twice the smallest absolute value
        if (negativeCount % 2 != 0) {
            totalSum -= 2 * minAbsValue;
        }

        return totalSum;
    }
}
