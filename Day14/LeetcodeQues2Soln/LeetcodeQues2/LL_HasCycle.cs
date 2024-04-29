using System;

namespace LeetcodeQues2
{
    internal class LL_HasCycle
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public async Task<bool> HasCycle(ListNode head)
        {
            if (head == null) 
                return false;

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }

            return false;
        }

        public static async Task Main(string[] args)
        { 
            ListNode head = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);

            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node2; // creates a cycle

            LL_HasCycle solution = new LL_HasCycle();
            bool hasCycle = await solution.HasCycle(head);
            Console.WriteLine("\nLinked list has cycle: " + hasCycle);
        }
    }
}
