using System.Collections.Generic;
using Core;
using JetBrains.Annotations;

namespace LinkedLists._2._8_Loop_Detection
{
    [UsedImplicitly]
    public sealed class LoopDetection : ITask
    {
        public void Run(IOutput output)
        {
            var node = new LinkedListNode<char>('A',
                new LinkedListNode<char>('B',
                    new LinkedListNode<char>('C',
                        new LinkedListNode<char>('D',
                            new LinkedListNode<char>('E', null)))));

            // Create cycle
            // A -> B -> [C] -> D -> E -> [C] -> D
            node.Next.Next.Next.Next.Next = node.Next.Next;

            {
                output.WriteLine(() => NaiveHashSetImplementation(node));
            }

            {
                output.WriteLine(() => TortoiseHareImplementation(node));
            }

            {
                output.WriteLine(() => BreakLinkImplementation(node));
            }
        }

        private static LinkedListNode<T> NaiveHashSetImplementation<T>(LinkedListNode<T> node)
        {
            var visitedNodes = new HashSet<LinkedListNode<T>>();
            var current = node;
            while (current != null)
            {
                if (visitedNodes.Contains(current))
                {
                    return current;
                }

                visitedNodes.Add(current);
                current = current.Next;
            }

            return null;
        }

        private static LinkedListNode<T> BreakLinkImplementation<T>(LinkedListNode<T> node)
        {
            var current = node;
            while (current != null)
            {
                var next = current.Next;
                if (next == null)
                {
                    return current;
                }

                current.Next = null;
                current = next;
            }

            return null;
        }

        private static LinkedListNode<T> TortoiseHareImplementation<T>(LinkedListNode<T> node)
        {
            var fast = node;
            var slow = node;

            while (fast?.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    // collistion
                    break;
                }
            }

            slow = node;
            while (fast != slow)
            {
                // ReSharper disable once PossibleNullReferenceException
                fast = fast.Next;
                slow = slow.Next;
            }

            return fast ?? slow;
        }
    }
}