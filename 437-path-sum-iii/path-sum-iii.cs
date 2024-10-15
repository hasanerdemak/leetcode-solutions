/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int PathSum(TreeNode root, int targetSum) {
        // Dictionary to store prefix sums and their counts
        var prefixSumCount = new Dictionary<long, int>();
        // Base case: if the current sum equals the targetSum exactly
        prefixSumCount[0] = 1;

        // Start recursive traversal
        return CountPaths(root, 0, targetSum, prefixSumCount);
    }

    private int CountPaths(TreeNode node, long currentSum, int targetSum, Dictionary<long, int> prefixSumCount) {
        // Base case: if the node is null, no paths can be found
        if (node == null) {
            return 0;
        }

        // Update the current cumulative sum
        currentSum += node.val;

        // Check how many times (currentSum - targetSum) has been seen so far
        int pathCount = prefixSumCount.ContainsKey(currentSum - targetSum) ? prefixSumCount[currentSum - targetSum] : 0;

        // Update the prefix sum count with the current sum
        if (!prefixSumCount.ContainsKey(currentSum)) {
            prefixSumCount[currentSum] = 0;
        }
        prefixSumCount[currentSum]++;

        // Recurse into the left and right subtrees
        pathCount += CountPaths(node.left, currentSum, targetSum, prefixSumCount);
        pathCount += CountPaths(node.right, currentSum, targetSum, prefixSumCount);

        // Backtrack: remove the current sum from the hashmap as we return
        prefixSumCount[currentSum]--;

        return pathCount;
    }
}