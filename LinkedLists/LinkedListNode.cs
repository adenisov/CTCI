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

    public sealed class LinkedListNode<T>
    {
        public LinkedListNode<T> Next { get; set; }

        public T Value { get; set; }


        public override string ToString()
        {
            var builder = new StringBuilder();

            var node = this;
            while (node != null)
            {
                builder.Append($"{node.Value}");

                node = node.Next;

                if (node != null)
                {
                    builder.Append(" -> ");
                }
            }

            return builder.ToString();
        }
    }
}