public class Solution {
    public int SingleNumber(int[] nums) {
        int result = 0;
        for (int i = 0; i < nums.Count(); i++)
        {
            result ^= nums[i];
        }
/*

        0100
        0001  0101
        0010        0111
        0001            0110
        0010                0100
*/
        return result;
    }
}