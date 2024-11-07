public class Solution {
    private int max = 0;
    private int[] arr = new int[32];

    public int LargestCombination(int[] candidates) {
        foreach(var candidate in candidates)
            bitCount(candidate);
        
        return max;
    }

    private void bitCount(int number) {
        for (int i = 0; i < 32; ++i) {
            int mask = 1 << i;
            if ((mask & number) != 0)
                arr[i]++;
            max = Math.Max(max, arr[i]);
        }
    }
}