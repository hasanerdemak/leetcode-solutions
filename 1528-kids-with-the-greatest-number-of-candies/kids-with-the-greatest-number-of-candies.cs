public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        // Find the maximum number of candies that any child currently has
        var max = candies.Max();
        
        // Create a list to store the boolean results
        List<bool> result = new List<bool>();

        // Loop through each child's candies count
        for (var i = 0; i < candies.Length; i++) {
            // Check if the current child can have greater than or equal to the maximum number of candies 
            // after receiving the extra candies. Add the result (true or false) to the list.
            result.Add(candies[i] + extraCandies >= max);
        }

        // Return the list of boolean values
        return result;
    }
}
