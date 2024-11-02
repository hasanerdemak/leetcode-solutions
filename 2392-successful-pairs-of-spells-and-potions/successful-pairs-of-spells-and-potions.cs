public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions); // Sort the potions array
        int m = potions.Length;
        int[] result = new int[spells.Length];

        for (int i = 0; i < spells.Length; i++) {
            int spell = spells[i];
            // Calculate the minimum potion strength needed for a successful pair
            long requiredPotionStrength = (success + spell - 1) / spell;
            
            // Binary search for the first potion that meets or exceeds the required strength
            int left = 0, right = m;
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (potions[mid] >= requiredPotionStrength) {
                    right = mid;
                } else {
                    left = mid + 1;
                }
            }
            
            // All potions from index `left` to the end of the array are successful
            result[i] = m - left;
        }

        return result;
    }
}