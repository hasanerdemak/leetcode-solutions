public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int prev2 = cost[0];
        int prev1 = cost[1];

        for (int i = 2; i < cost.Length ; i++) {
            int curr = cost[i] + Math.Min(prev1, prev2);
            prev2 = prev1;
            prev1 = curr;
        }

        return Math.Min(prev1, prev2);
    }
}