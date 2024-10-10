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
    public ListNode DeleteMiddle(ListNode head) {
        // If there's only one node in the list, return null (deleting the only node)
        if (head.next == null) {
            return null;
        }

        // Use three pointers:
        ListNode prev = null; // 'prev' will keep track of the node before the middle node.
        ListNode slow = head; // 'slow' will move one step at a time and will eventually point to the middle node.
        ListNode fast = head; // 'fast' will move two steps at a time, allowing us to find the middle node by the time 'fast' reaches the end.

        // Traverse the list using the slow and fast pointers.
        // 'fast' moves two steps, and 'slow' moves one step.
        // This will position 'slow' at the middle node when 'fast' reaches the end.
        while (fast != null && fast.next != null) {
            prev = slow;            // Track the node before 'slow'
            slow = slow.next;       // Move 'slow' one step
            fast = fast.next.next;  // Move 'fast' two steps
        }

        // At this point, 'slow' is pointing to the middle node.
        // 'prev' is the node just before 'slow'. Remove the middle node by skipping it.
        prev.next = slow.next;

        // Return the modified list starting from the head.
        return head;
    }
}