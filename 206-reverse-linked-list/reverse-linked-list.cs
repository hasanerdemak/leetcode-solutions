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
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;  // Initialize a pointer for the previous node, starting with null
        // Iterate through the linked list until reaching the end
        while (head != null) {
            ListNode temp = head.next;   // Store the next node temporarily
            head.next = prev;            // Reverse the link: point current node's next to the previous node
            prev = head;                 // Move the previous pointer to the current node
            head = temp;                 // Move to the next node in the original list
        }

        // At the end of the loop, prev will be the new head of the reversed list
        return prev;
    }
}