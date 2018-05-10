using Core;
using JetBrains.Annotations;

namespace LinkedLists._2._4_Partition
{
    [UsedImplicitly]
    public sealed class Partition : ITask
    {
        public void Run(IOutput output)
        {
            const int partitioner = 5;

            // [3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 -> 9]
            var node = new LinkedListNode<int>(3,
                new LinkedListNode<int>(5,
                    new LinkedListNode<int>(8,
                        new LinkedListNode<int>(5,
                            new LinkedListNode<int>(10,
                                new LinkedListNode<int>(2,
                                    new LinkedListNode<int>(1,
                                        new LinkedListNode<int>(9))))))));

            var node2 = node.Clone();

            output.WriteLine(() => node);
            output.WriteNewLine();

            // Solution from the book
            {
                output.WriteLine(() => HeadTailExpansionImplementation(node, partitioner));
            }

            // Throw to the head
            {
                output.WriteLine(() => ThrowBeforeHeadImplementation((LinkedListNode<int>) node2, partitioner));
            }
        }

        private static LinkedListNode<int> ThrowBeforeHeadImplementation(LinkedListNode<int> node, int partitioner)
        {
            var current = node;
            var head = node;

            while (current != null)
            {
                if (current.Next?.Value < partitioner)
                {
                    var tmp = current.Next;
                    current.Next = current.Next.Next;
                    tmp.Next = head;
                    head = tmp;

                    continue;
                }

                current = current.Next;
            }

            return head;
        }

        private static LinkedListNode<int> HeadTailExpansionImplementation(LinkedListNode<int> node, int partitioner)
        {
            var head = node;
            var tail = node;

            while (node != null)
            {
                var next = node.Next;
                if (node.Value < partitioner)
                {
                    node.Next = head;
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    tail = node;
                }

                node = next;
            }

            tail.Next = null;

            return head;
        }
    }
}