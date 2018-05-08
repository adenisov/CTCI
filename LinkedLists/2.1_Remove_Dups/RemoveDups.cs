using Core;
using JetBrains.Annotations;

namespace LinkedLists._2._1_Remove_Dups
{
    [UsedImplicitly]
    public sealed class RemoveDups : ITask
    {
        public void Run(IOutput output)
        {
            const string input = "FOLLOW UP !!!";

            var node = input.ToLinkedList();

            {
                output.Write(() => Implementation(node));
            }
        }

        private static LinkedListNode<char> Implementation(LinkedListNode<char> node)
        {
            // Time complexity O(n)
            // Space complexity O(1)

            /* Disclaimer:
             * The original answer is to remove duplicates from the whole linked list itself
             * but not just repeating characters
             * Here we are removing repeating characters ONLY
             * To solve the original task just iterate using two pointers making O(n^2) time complexity
             */

            var current = node;
            while (current != null)
            {
                var runner = current;
                while (runner.Next != null)
                {
                    if (runner.Next.Value == current.Value)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }

            return node;
        }
    }
}