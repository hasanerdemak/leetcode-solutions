public class Solution {
    public int MaxArea(int[] height) {
        var maxArea = 0;  // Variable to keep track of the maximum area
        var i = 0;        // Left pointer starting from the beginning
        var j = height.Length - 1;  // Right pointer starting from the end

        // Continue until the two pointers meet
        while (i < j) {
            // Calculate the area between the lines at index i and j
            var area = Math.Min(height[i], height[j]) * (j - i);

            // Update maxArea if the current area is larger
            maxArea = Math.Max(area, maxArea);

            // Move the pointer that is at the shorter height to try to increase the area
            if (height[i] < height[j]) i++;  // Move the left pointer if it's shorter
            else j--;  // Otherwise, move the right pointer
        }

        return maxArea;  // Return the maximum area found
    }
}
