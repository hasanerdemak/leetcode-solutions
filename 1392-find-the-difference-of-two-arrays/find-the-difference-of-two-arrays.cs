public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        // Create HashSets from the arrays to eliminate duplicates and for quick lookups
        var set1 = new HashSet<int>(nums1);
        var set2 = new HashSet<int>(nums2);
        
        // HashSets to store the results
        var res1 = new HashSet<int>();
        var res2 = new HashSet<int>();

        // Loop through nums1 and add to res1 if the number is not in set2
        foreach (var num in nums1) {
            if (!set2.Contains(num)) res1.Add(num);
        }

        // Loop through nums2 and add to res2 if the number is not in set1
        foreach (var num in nums2) {
            if (!set1.Contains(num)) res2.Add(num);
        }

        // Return the results as lists
        return new List<IList<int>> { res1.ToList(), res2.ToList() };
    }
}
