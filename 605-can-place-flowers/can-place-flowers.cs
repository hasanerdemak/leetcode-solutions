public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        var len = flowerbed.Length;

        // If the flowerbed is empty or n is 0 (no need to plant any flowers), return true
        if (len == 0 || n == 0) return n == 0;

        // If the flowerbed has only one plot, check if it can accommodate n flowers
        if (len == 1) return flowerbed[0] != n;

        // Initialize a counter to keep track of how many flowers can be planted
        var count = 0;

        // Check the first plot: if it's empty and the next plot is also empty, plant a flower in the first plot
        if(flowerbed[0] == 0 && flowerbed[1] == 0){
            flowerbed[0] = 1; // Plant a flower
            count++; // Increment the flower count
        }

        // Loop through the middle plots (from the second plot to the second-last plot)
        for (int i = 1; i < len - 1; i++){
            // Check if the previous, current, and next plots are all empty
            if(flowerbed[i-1] == 0 && flowerbed[i] == 0 && flowerbed[i+1] == 0){
                count++; // Increment the flower count
                flowerbed[i] = 1; // Plant a flower in the current plot
                i++; // Skip the next plot since we can't plant adjacent flowers
            }
        }

        // Check the last plot: if it's empty and the second-to-last plot is also empty, plant a flower in the last plot
        if(flowerbed[len-2] == 0 && flowerbed[len-1] == 0){
            flowerbed[len-1] = 1; // Plant a flower
            count++; // Increment the flower count
        }

        // Return true if the number of flowers that can be planted is greater than or equal to n, otherwise return false
        return count >= n;
    }
}
