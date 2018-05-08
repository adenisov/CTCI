using Core;
using JetBrains.Annotations;

namespace LinkedLists._2._2_Return_Kth_To_Last
{
    [UsedImplicitly]
    public sealed class ReturnKthToLast : ITask
    {
        public void Run(IOutput output)
        {
            var input = new[] { 1, 4, 5, 9, 2, 6, 5 };

            var node = input.ToLinkedList();

            {
                output.WriteLine(() => NaiveImplementation(node, 6));
            }

            {
                output.WriteLine(() => OnePassImplementation(node, 6));
            }
        }

        private static int NaiveImplementation(LinkedListNode<int> node, int k)
        {
            // Space complexity O(1)
            // Time complexity O(2 n)

            var current = node;
            var size = 0;
            while (current != null)
            {
                size++;
                current = current.Next;
            }

            current = node;
            var index = size - k;
            while (index != 0)
            {
                index--;
                current = current.Next;
            }

            return current.Value;
        }

        private static int OnePassImplementation(LinkedListNode<int> node, int k)
        {
            // Space complexity O(1)
            // Time complexity O(n)

            var first = node;
            var second = node;
            for (var i = 0; i < k; i++)
            {
                first = first.Next;
            }

            while (first != null)
            {
                first = first.Next;
                second = second.Next;
            }

            return second.Value;
        }
    }
}