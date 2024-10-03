public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        // Dictionary to store the frequency of each number
        var freqs = new Dictionary<int, int>();
        
        // Count the occurrences of each number
        foreach (var num in arr) {
            if (!freqs.TryAdd(num, 1)) {
                freqs[num]++;
            }
        }

        // HashSet to track unique occurrences
        var occurrences = new HashSet<int>();
        
        // Check if the occurrences are unique
        foreach (var count in freqs.Values) {
            if (!occurrences.Add(count)) {
                return false; // If we cannot add the count, it means it's not unique
            }
        }

        return true; // All counts are unique
    }
}
