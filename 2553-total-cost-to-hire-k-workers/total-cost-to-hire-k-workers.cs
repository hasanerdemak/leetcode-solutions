public class Solution {
    public long TotalCost(int[] costs, int k, int candidates) {
        int n = costs.Length;
        PriorityQueue<(int cost, int index), (int, int)> leftQueue = new PriorityQueue<(int, int), (int, int)>();
        PriorityQueue<(int cost, int index), (int, int)> rightQueue = new PriorityQueue<(int, int), (int, int)>();

        // Initialize queues with left and right candidates
        int left = 0, right = n - 1;
        for (int i = 0; i < candidates && left <= right; i++) {
            leftQueue.Enqueue((costs[left], left), (costs[left], left));
            if (left != right) rightQueue.Enqueue((costs[right], right), (costs[right], right));
            left++;
            right--;
        }

        long totalCost = 0;
        int hired = 0;

        while (hired < k) {
            (int cost, int index) chosen;

            // Choose the worker with the lower cost between both queues
            if (rightQueue.Count == 0 || (leftQueue.Count > 0 && leftQueue.Peek().cost <= rightQueue.Peek().cost)) {
                chosen = leftQueue.Dequeue();
                // Add next left-side candidate if within range
                if (left <= right) {
                    leftQueue.Enqueue((costs[left], left), (costs[left], left));
                    left++;
                }
            } else {
                chosen = rightQueue.Dequeue();
                // Add next right-side candidate if within range
                if (right >= left) {
                    rightQueue.Enqueue((costs[right], right), (costs[right], right));
                    right--;
                }
            }

            totalCost += chosen.cost;
            hired++;
        }

        return totalCost;
    }
}