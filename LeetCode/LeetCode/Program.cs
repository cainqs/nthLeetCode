using LeetCode.Helper;
using LeetCode.model;
using LeetCode.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //9 7 2 5 4 3 6

            ListNode l1 = new ListNode(9);
            ListNode l2 = new ListNode(7);
            ListNode l3 = new ListNode(2);
            ListNode l4 = new ListNode(5);
            ListNode l5 = new ListNode(4);
            ListNode l6 = new ListNode(3);
            ListNode l7 = new ListNode(6);

            l1.next = l2;
            l2.next = l3;
            l3.next = l4;
            l4.next = l5;
            l5.next = l6;
            l6.next = l7;

            reverseBetween(l1, 1, 6);

            Console.ReadLine();
        }

        public static ListNode reverseBetween(ListNode head, int left, int right)
        {
            // 因为头节点有可能发生变化，使用虚拟头节点可以避免复杂的分类讨论
            ListNode dummyNode = new ListNode(-1);
            dummyNode.next = head;

            ListNode pre = dummyNode;
            // 第 1 步：从虚拟头节点走 left - 1 步，来到 left 节点的前一个节点
            // 建议写在 for 循环里，语义清晰
            for (int i = 0; i < left - 1; i++)
            {
                pre = pre.next;
            }

            // 第 2 步：从 pre 再走 right - left + 1 步，来到 right 节点
            ListNode rightNode = pre;
            for (int i = 0; i < right - left + 1; i++)
            {
                rightNode = rightNode.next;
            }

            // 第 3 步：切断出一个子链表（截取链表）
            ListNode leftNode = pre.next;
            ListNode curr = rightNode.next;

            // 注意：切断链接
            pre.next = null;
            rightNode.next = null;

            // 第 4 步：同第 206 题，反转链表的子区间
            reverseLinkedList(leftNode);

            // 第 5 步：接回到原来的链表中
            pre.next = rightNode;
            leftNode.next = curr;
            return dummyNode.next;
        }

        private static void reverseLinkedList(ListNode head)
        {
            // 也可以使用递归反转一个链表
            ListNode pre = null;
            ListNode cur = head;

            while (cur != null)
            {
                ListNode next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
        }
    }
}
