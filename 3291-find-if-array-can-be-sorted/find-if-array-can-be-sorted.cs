public class Solution {
    public bool CanSortArray(int[] nums) {
        int prevMax = int.MinValue;
        int currMax = nums[0];
        int currMin = nums[0];
        int setBits = GetSetBitsCount(nums[0]);

        for (int i = 1; i < nums.Length; i++)
        {
            if (setBits == GetSetBitsCount(nums[i]))
            {
                currMax = Math.Max(currMax, nums[i]);
                currMin = Math.Min(currMin, nums[i]);
            }
            else
            {
                if (currMin < prevMax)
                    return false;

                prevMax = currMax;
                setBits = GetSetBitsCount(nums[i]);
                currMin = nums[i];
                currMax = nums[i];
            }
        }

        return currMin > prevMax;
    }

    private int GetSetBitsCount(int number) {
        int count = 0;
        while (number > 0)
        {
            count += number & 1;
            number >>= 1;
        }
        return count;
    }
}