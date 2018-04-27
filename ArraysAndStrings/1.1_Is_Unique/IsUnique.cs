using System.Collections.Generic;
using Core;
using JetBrains.Annotations;

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForCanBeConvertedToForeach

namespace ArraysAndStrings._1._1_Is_Unique
{
    [UsedImplicitly]
    public sealed class IsUnique : ITask
    {
        internal const string Hint1 = "44";
        internal const string Hint2 = "117";
        internal const string Hint3 = "132";

        public void Run(IOutput output)
        {
            // Naive
            {
                // -> False
                output.Write(() => NaiveImplementation(Hint1));
                output.WriteTab();

                // -> False
                output.Write(() => NaiveImplementation(Hint2));
                output.WriteTab();

                // -> True
                output.Write(() => NaiveImplementation(Hint3));
                output.WriteTab();
            }

            output.WriteNewLine();

            // Without additional data structures
            {
                // -> False
                output.Write(() => NoAdditionalSpaceUsageImplementation(Hint1));
                output.WriteTab();

                // -> False
                output.Write(() => NoAdditionalSpaceUsageImplementation(Hint2));
                output.WriteTab();

                // -> True
                output.Write(() => NoAdditionalSpaceUsageImplementation(Hint3));
                output.WriteTab();
            }

            output.WriteNewLine();

            {
                // -> False
                output.Write(() => AlphabetDictionaryImplementation(Hint1));
                output.WriteTab();

                // -> False
                output.Write(() => AlphabetDictionaryImplementation(Hint2));
                output.WriteTab();

                // -> True
                output.Write(() => AlphabetDictionaryImplementation(Hint3));
                output.WriteTab();
            }
        }

        private static bool NaiveImplementation(string input)
        {
            // Space complexity O(n)
            // Time complexity O(n)

            var hashTable = new HashSet<char>();
            for (var i = 0; i < input.Length; i++)
            {
                if (hashTable.Contains(input[i]))
                {
                    return false;
                }

                hashTable.Add(input[i]);
            }

            return true;
        }

        private static bool NoAdditionalSpaceUsageImplementation(string input)
        {
            // Space complexity O(1)
            // Time complexity O(n^2)

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool AlphabetDictionaryImplementation(string input)
        {
            // Suitable for small alphabet sizes only like ASCII
            // Space complexity O(alphabet size), for ASCII is 256
            // Time complexity O(n)

            var alphabet = new bool[256];

            for (var i = 0; i < input.Length; i++)
            {
                if (alphabet[input[i]])
                {
                    return false;
                }

                alphabet[input[i]] = true;
            }

            return true;
        }
    }
}