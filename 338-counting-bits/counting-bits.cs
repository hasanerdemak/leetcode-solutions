public class Solution {
    public int[] CountBits(int n) {
        var res = new int[n+1];
        for (int i = 0; i < n + 1; i++) {
            res[i] = res[i >> 1] + (i&1);
        }

        return res;
    }
}