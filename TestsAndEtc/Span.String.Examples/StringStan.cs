namespace Span.String.Examples
{
    public class StringStan
    {
        public static int GetUniqueWordsCount(string input)
        {
            var inputs = input.AsSpan();

            var startIndex = 0;

            var unique = new HashSet<int>();

            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] == ' ')
                {
                    var end = i;
                    var hash = new HashCode();
                    for (int j = startIndex; j < end; j++)
                    {
                        hash.Add(inputs[j]);
                    }

                    unique.Add(hash.ToHashCode());

                    startIndex = end + 1;
                }
            }

            return unique.Count();
        }

        public static int GetUniqueWordsCount2(string input)
        {
            return input.Split(' ').Distinct().Count();
        }
    }
}
