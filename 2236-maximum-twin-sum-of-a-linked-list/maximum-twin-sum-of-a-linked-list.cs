/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int PairSum(ListNode head) {
        // Initialize two pointers, 'slow' and 'fast', to traverse the list.
        // 'slow' will move one step at a time, 'fast' moves two steps at a time.
        ListNode slow = head;
        ListNode fast = head.next;
        var i = 0; // Initialize i to count half size of the list

        // Use the two-pointer technique to find the middle of the linked list.
        // When 'fast' reaches the end, 'slow' will be at the middle.
        while (fast != null && fast.next != null) {
            i++;
            slow = slow.next;  // Move 'slow' one step forward.
            fast = fast.next.next;  // Move 'fast' two steps forward.
        }

        // Now, 'slow' is at the middle of the list.
        // Reverse the second half of the list starting from 'slow'.
        ListNode prev = null;
        ListNode curr = slow;
        while (curr != null) {
            ListNode temp = curr.next;  // Temporarily store the next node.
            curr.next = prev;  // Reverse the current node's pointer.
            prev = curr;  // Move 'prev' to the current node.
            curr = temp;  // Move 'curr' to the next node (original next).
        }

        // 'prev' now points to the head of the reversed second half.
        // Initialize 'left' pointer at the beginning of the list (first half).
        // Initialize 'right' pointer at the head of the reversed second half.
        var max = 0;  // To keep track of the maximum twin sum.
        ListNode left = head;
        ListNode right = prev;

        // Iterate through both halves of the list to compute the twin sums.
        while (i >= 0) {
            max = Math.Max(left.val + right.val, max);  // Calculate twin sum and update max.
            left = left.next;  // Move 'left' pointer one step forward.
            right = right.next;  // Move 'right' pointer one step forward.
            i--;  // Decrease the iteration count.
        }

        return max;  // Return the maximum twin sum.
    }
}