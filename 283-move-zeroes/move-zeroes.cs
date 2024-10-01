public class Solution {
    public void MoveZeroes(int[] nums) {
        // 'j' will track the position to place non-zero elements.
        var j = 0;
        
        // Iterate through the array.
        for (int i = 0; i < nums.Length; i++) {
            // When we encounter a non-zero element, we move it to the position 'j'.
            if (nums[i] != 0) {
                nums[j] = nums[i];  // Place the non-zero element at index 'j'.
                
                // If 'i' and 'j' are not the same, set the current position 'i' to zero
                // This ensures we don't overwrite non-zero values that are already in their correct position.
                if (i != j) nums[i] = 0;
                
                // Increment 'j' to point to the next position for the next non-zero element.
                j++;
            }
        }
    }
}
