using System;
using System.Linq;
using Core;
using JetBrains.Annotations;

// ReSharper disable ForCanBeConvertedToForeach

namespace ArraysAndStrings._1._2_Check_Permutation
{
    [UsedImplicitly]
    public sealed class CheckPermutation : ITask
    {
        internal static StringContainer Hint1 = StringContainer.For("a", "abc");
        internal static StringContainer Hint2 = StringContainer.For("acb", "abbac");
        internal static StringContainer Hint3 = StringContainer.For("bca", "acb");

        /*
         * Permutations of 'abc' is
         * abc
         * acb
         * bac
         * cab
         * bca
         * cba
         * total permutations number is always n!
         */

        public void Run(IOutput output)
        {
            // Naive implementation with optimization
            {
                // False
                output.Write(() => NaiveImplementation(Hint1));
                output.WriteTab();

                // False
                output.Write(() => NaiveImplementation(Hint2));
                output.WriteTab();

                // True
                output.Write(() => NaiveImplementation(Hint3));
                output.WriteTab();
            }

            output.WriteNewLine();

            // No sorting implementation
            {
                output.Write(() => NoSortImplementation(Hint1));
                output.WriteTab();

                // False
                output.Write(() => NoSortImplementation(Hint2));
                output.WriteTab();

                // True
                output.Write(() => NoSortImplementation(Hint3));
                output.WriteTab();
            }
        }

        private static bool NaiveImplementation(StringContainer container)
        {
            // Space compexity O(1)
            // Time complexity two sorts assuming quick sort log(n) O(2 log(n))

            var left = container.First.ToCharArray();
            var right = container.Second.ToCharArray();

            Array.Sort(left);
            Array.Sort(right);

            return left.SequenceEqual(right);
        }

        private static bool NoSortImplementation(StringContainer container)
        {
            /*
             * Permutations contains the same symbols exactly the same amount of time in both strings
             * Simple count and check
             */

            // Space complexity O(n)
            // Time complexity O(2 n)

            // Say ASCII or HashSet for Unicode :)
            var alphabet = new int[128];
            for (var i = 0; i < container.First.Length; i++)
            {
                alphabet[container.First[i]]++;
            }

            for (var i = 0; i < container.Second.Length; i++)
            {
                alphabet[container.Second[i]]--;

                if (alphabet[container.Second[i]] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}