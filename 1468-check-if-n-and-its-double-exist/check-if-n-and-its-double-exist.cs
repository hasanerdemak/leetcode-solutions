public class Solution {
    public bool CheckIfExist(int[] arr)
    {
        // Create a HashSet to store the elements of the array
        HashSet<int> seen = new HashSet<int>();

        // Iterate through the array
        foreach (int num in arr)
        {
            // Check if the current number's double or half is in the set
            if (seen.Contains(2 * num) || (num % 2 == 0 && seen.Contains(num / 2)))
            {
                return true;
            }

            // Add the current number to the set
            seen.Add(num);
        }

        return false;
    }
}