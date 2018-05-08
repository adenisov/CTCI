using Core;
using JetBrains.Annotations;

// ReSharper disable AccessToModifiedClosure

namespace LinkedLists._2._3_Delete_Middle_Node
{
    [UsedImplicitly]
    public sealed class DeleteMiddleNode : ITask
    {
        public void Run(IOutput output)
        {
            var input = new[] { 1, 4, 5, 9, 2, 6, 5 };
            var node = input.ToLinkedList();

            {
                // Odd
                output.WriteLine(() => TwoPointerImplementation(node));
            }

            input = new[] { 1, 4, 5, 9, 2, 6 };
            node = input.ToLinkedList();

            {
                // Even
                output.WriteLine(() => TwoPointerImplementation(node));
            }
        }

        private static LinkedListNode<int> TwoPointerImplementation(LinkedListNode<int> node)
        {
            // Space complexity O(1)
            // Time complexity O(n)

            // Assume first pointer travels two times faster than the second one
            // and when first reaches tail the second will be in the middle (ie. half or 2 ways slower)
            
            // Disclaimer: assuming task is to remove middle node having no access to this node
            
            var head = node;

            var first = node.Next;
            var second = node;

            while (first != null)
            {
                first = first.Next?.Next;
                if (first != null)
                {
                    second = second.Next;
                }
            }

            second.Next = second.Next.Next;
            return head;
        }
    }
}