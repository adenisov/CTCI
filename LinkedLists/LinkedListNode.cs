using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedLists
{
    public static class Extensions
    {
        public static LinkedListNode<T> ToLinkedList<T>(this IEnumerable<T> sequence)
        {
            var enumerable = sequence as T[] ?? sequence.ToArray();
            var previous = new LinkedListNode<T> { Value = enumerable.First() };
            var head = previous;

            foreach (var c in enumerable.Skip(1))
            {
                var node = new LinkedListNode<T> { Value = c };
                previous.Next = node;
                previous = node;
            }

            return head;
        }
    }

    public sealed class LinkedListNode<T> : ICloneable
    {
        public LinkedListNode()
        {
        }

        public LinkedListNode(T value) : this()
        {
            Value = value;
        }

        public LinkedListNode(T value, LinkedListNode<T> next) : this(value)
        {
            Next = next;
        }

        public LinkedListNode<T> Next { get; set; }

        public T Value { get; set; }

        public override string ToString()
        {
            var visited = new HashSet<LinkedListNode<T>>();
            var builder = new StringBuilder();

            var node = this;
            while (node != null)
            {
                if (visited.Contains(node))
                {
                    builder.Append($"{node.Value} ... Loop Detected");
                    return builder.ToString();
                }

                builder.Append($"{node.Value}");

                visited.Add(node);
                node = node.Next;

                if (node != null)
                {
                    builder.Append(" -> ");
                }
            }

            return builder.ToString();
        }

        public object Clone() => new LinkedListNode<T>(Value, (LinkedListNode<T>) Next?.Clone());
    }
}