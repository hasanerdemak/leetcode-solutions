public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1;
        int right = 0;

        foreach (int pile in piles) {
            if (pile > right) {
                right = pile;
            }
        }

        while (left < right) {
            int mid = left + (right - left) / 2;

            long hoursNeeded = 0;
            foreach (int pile in piles) {
                hoursNeeded += (pile + mid - 1) / mid;
                if (hoursNeeded > h) {
                    break;
                }
            }

            if (hoursNeeded <= h) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }

        return left;
    }
}
