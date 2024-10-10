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
    public ListNode OddEvenList(ListNode head) {
        // If the list is empty or contains only one node, return the head as is.
        if (head == null || head.next == null) 
            return head;

        // Initialize two pointers:
        ListNode odd = head;        // 'odd' will point to the head of the odd-indexed nodes.
        ListNode even = head.next;  // 'even' will point to the head of the even-indexed nodes (which is the second node).
        ListNode temp = even;       // 'temp' stores the starting point of the even-indexed nodes, which we will need to reconnect later.
        
        // Iterate through the list while both 'even' and 'even.next' are non-null.
        // This ensures that we can safely update pointers without null reference issues.
        while (even != null && even.next != null) {
            // Move the 'odd' pointer to the next odd-indexed node (skipping the current 'even' node).
            odd.next = odd.next.next;

            // Move the 'even' pointer to the next even-indexed node (skipping the next 'odd' node).
            even.next = even.next.next;

            // Advance both the 'odd' and 'even' pointers.
            odd = odd.next;
            even = even.next;
        }

        // After the loop, connect the last odd-indexed node to the head of the even-indexed nodes.
        odd.next = temp;

        // Return the modified list starting from the head.
        return head;
    }
}