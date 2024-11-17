public class Solution
{
    public int ShortestSubarray(int[] nums, int k)
    {
        int n = nums.Length;
        long[] prefixSum = new long[n + 1];
        
        // Calculate prefix sum
        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        // Deque to maintain indices
        LinkedList<int> deque = new LinkedList<int>();
        int minLength = int.MaxValue;

        for (int i = 0; i <= n; i++)
        {
            // Remove elements from the deque if the current subarray satisfies the condition
            while (deque.Count > 0 && prefixSum[i] - prefixSum[deque.First.Value] >= k)
            {
                minLength = Math.Min(minLength, i - deque.First.Value);
                deque.RemoveFirst();
            }

            // Remove indices from the deque where prefixSum[i] is less than prefixSum[deque.Last.Value]
            // as they are no longer useful
            while (deque.Count > 0 && prefixSum[i] <= prefixSum[deque.Last.Value])
            {
                deque.RemoveLast();
            }

            // Add the current index to the deque
            deque.AddLast(i);
        }

        return minLength == int.MaxValue ? -1 : minLength;
    }
}