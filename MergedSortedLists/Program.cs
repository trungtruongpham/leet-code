// Problem link: https://leetcode.com/problems/merge-two-sorted-lists/?envType=study-plan-v2&envId=top-interview-150

  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
         this.next = next;
      }
  }

public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        // Edge cases based on examples
        if(list1 == null && list2 == null) {
            return list2;
        }

        if(list1== null && list2 != null) {
            return list2;
        }

        if(list1 != null && list2 == null) {
            return list1;
        }

        // Define head of merged list
        var head = new ListNode();
        if(list1.val > list2.val) {
            head = list2;
            list2 = list2.next;
        }
        else {
            head = list1;
            list1 = list1.next;
        }

        head.next = null;
        var node = head;
        
        while(list1 != null && list2 != null) {
            if(list1.val > list2.val) {
                node.next = list2;
                list2 = list2.next;
            }
            else {
                node.next = list1;
                list1 = list1.next;
            }
            
            // Only run 1st time while loop to set next node of head 
            if(node.next != null && head.next == null) {
                head.next = node;
            }

            node = node.next;
            node.next = null;
        }
        
        // When list1 is end we add all elements of list2 to merged list
        if(list1 == null) {
            while(list2 != null) {
                node.next = list2;
                node = node.next;
                list2 = list2.next;
            }
        }
        
        // When list2 is end we add all elements of list1 to merged list
        if(list2 == null) {
            while(list1 != null) {
                node.next = list1;
                node = node.next;
                list1 = list1.next;
            }
        }

        return head;
    }
}