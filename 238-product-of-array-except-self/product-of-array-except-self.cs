public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var n = nums.Length;
        
        // Create an array 'answer' to store the final result and initialize all elements to 1
        var answer = new int[n];
        Array.Fill(answer, 1); 

        // Initialize 'product' as 1, which will be used to track the product of all elements to the left of the current index
        var product = 1;
        
        // First pass: Calculate the product of all elements to the left of each index
        for (int i = 0; i < n; i++) {
            // At index i, 'product' holds the product of all elements to the left of i
            answer[i] = product;
            // Update 'product' by multiplying it with the current element in nums
            product *= nums[i];
        }

        // Reset 'product' to 1 to start the second pass from the right side
        product = 1;
        
        // Second pass: Multiply each element in 'answer' with the product of all elements to the right of the current index
        for (int i = n - 1; i >= 0; i--) {
            // Multiply the current value in 'answer' (which contains the product of elements to the left) with 'product' (product of elements to the right)
            answer[i] *= product;
            // Update 'product' by multiplying it with the current element in nums (moving leftwards)
            product *= nums[i];
        }

        return answer;
    }
}
