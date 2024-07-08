// Problem link: https://leetcode.com/problems/linked-list-cycle/?source=submission-noac

bool HasCycle(ListNode? head)
{
    if(head == null) {
        return false;
    }

    var node = head.next;
    var hashNodes = new HashSet<ListNode>();

    while(node.next != null) {
        if(!hashNodes.Add(node)) {
            return true;
        }

        node = node.next;
    }

    return false;
}

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}