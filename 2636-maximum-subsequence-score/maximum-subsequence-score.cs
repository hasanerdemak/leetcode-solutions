public class Solution {
    public long MaxScore(int[] nums1, int[] nums2, int k) {
        int n = nums1.Length;
        
        // Pair elements with indices and sort by nums2 in descending order
        var pairs = nums1.Select((val, idx) => new { Num1 = val, Num2 = nums2[idx] })
                         .OrderByDescending(pair => pair.Num2)
                         .ToList();

        // Min-heap for the top k elements from nums1
        var minHeap = new SortedSet<(int val, int index)>();
        long currentSum = 0;
        long maxScore = 0;

        // Loop through sorted pairs
        for (int i = 0; i < n; i++) {
            int value1 = pairs[i].Num1;
            int value2 = pairs[i].Num2;

            // Add current element to heap and sum
            minHeap.Add((value1, i));
            currentSum += value1;

            // Ensure heap has at most k elements
            if (minHeap.Count > k) {
                var minElement = minHeap.Min;
                currentSum -= minElement.val;
                minHeap.Remove(minElement);
            }

            // Calculate score when we have exactly k elements
            if (minHeap.Count == k) {
                long score = currentSum * value2;
                maxScore = Math.Max(maxScore, score);
            }
        }

        return maxScore;
    }
}