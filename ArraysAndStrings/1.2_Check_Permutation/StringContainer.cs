namespace ArraysAndStrings._1._2_Check_Permutation
{
    public sealed class StringContainer
    {
        private StringContainer(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; }

        public string Second { get; }

        public static StringContainer For(string first, string second) =>
            new StringContainer(first, second);
    }
}