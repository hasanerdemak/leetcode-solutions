public class Solution {
    public int[] Decrypt(int[] code, int k) {
        int n = code.Length;
        int[] result = new int[n];

        if (k == 0) {
            // If k == 0, all elements should be replaced with 0
            return new int[n];
        }

        for (int i = 0; i < n; i++) {
            int sum = 0;

            if (k > 0) {
                // Calculate the sum of the next k numbers
                for (int j = 1; j <= k; j++) {
                    sum += code[(i + j) % n];
                }
            } else {
                // Calculate the sum of the previous k numbers
                for (int j = 1; j <= -k; j++) {
                    sum += code[(i - j + n) % n];
                }
            }

            result[i] = sum;
        }

        return result;
    }
}