using System.Linq;
using Core;
using JetBrains.Annotations;

namespace LinkedLists._2._5_Sum_Lists
{
    [UsedImplicitly]
    public sealed class SumLists : ITask
    {
        public void Run(IOutput output)
        {
            const string first = "99";
            const string second = "1";

            // 3 -> 5 -> 1
            var l1 = first.Select(c => int.Parse(c.ToString())).ToLinkedList();

            // 4 -> 8 -> 9
            var l2 = second.Select(c => int.Parse(c.ToString())).ToLinkedList();

            {
                // 7 -> 3 -> 1 -> 1
                output.WriteLine(() => SumBackward(l1, l2));
            }

            {
                // output.WriteLine(() => SumForward(null, null));
            }
        }

        private static LinkedListNode<int> SumBackward(LinkedListNode<int> first, LinkedListNode<int> second)
        {
            // Time complexity O(n)

            var node = new LinkedListNode<int> { Value = 0 };
            var current = node;

            while (first != null || second != null)
            {
                var nextSum = current.Value + (first?.Value ?? 0) + (second?.Value ?? 0);
                current.Value = nextSum % 10;
                if (first?.Next != null || second?.Next != null || nextSum / 10 > 0)
                {
                    current.Next = new LinkedListNode<int> { Value = nextSum / 10 };
                }

                current = current.Next;

                first = first?.Next;
                second = second?.Next;
            }

            return node;
        }

        /*
         * ToDo: Reverse, pad with zeros and call SumBackward
         */
        private static LinkedListNode<int> SumForward(LinkedListNode<int> first, LinkedListNode<int> second) => null;
    }
}