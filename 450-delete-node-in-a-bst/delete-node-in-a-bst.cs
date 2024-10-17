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
    public TreeNode DeleteNode(TreeNode root, int key) {
        // Base case: If the root is null, simply return null (no node to delete).
        if (root == null) return null;

        // If the key to be deleted is smaller than the root's value,
        // move to the left subtree since all smaller values are on the left in a BST.
        if (root.val > key) {
            root.left = DeleteNode(root.left, key);
        }
        // If the key to be deleted is larger than the root's value,
        // move to the right subtree since all larger values are on the right in a BST.
        else if (root.val < key) {
            root.right = DeleteNode(root.right, key);
        }
        // If the root's value matches the key, this is the node to be deleted.
        else {
            // Case 1: The node is a leaf node (no children), so return null.
            if (root.left == null && root.right == null) {
                return null;
            } 
            // Case 2: The node has only one child (right child), so return the right child.
            else if (root.left == null) {
                return root.right;
            } 
            // Case 3: The node has only one child (left child), so return the left child.
            else if (root.right == null) {
                return root.left;
            } 
            // Case 4: The node has two children. Find the inorder successor (smallest value in the right subtree)
            // to replace the current node's value and then delete the inorder successor node.
            else {
                TreeNode inorderSuccessor = findInorderSuccessor(root.right);  // Finding the inorder successor
                root.val = inorderSuccessor.val;  // Replace the current node's value with the inorder successor's value
                root.right = DeleteNode(root.right, inorderSuccessor.val);  // Delete the inorder successor
            }
        }

        // Return the (possibly updated) root after deletion.
        return root;
    }

    // Helper function to find the inorder successor (smallest value in the right subtree).
    private TreeNode findInorderSuccessor(TreeNode root){
        // The leftmost node in the right subtree is the inorder successor.
        while(root.left != null){
            root = root.left;
        }
        return root;
    }
}