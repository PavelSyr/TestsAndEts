using Span.String.Examples;

namespace OtherStaff.Tests
{
    public class UniqueWordsCount_Test
    {
        [Theory]
        [InlineData("aa a a a aa bb as 1 1 1 1 1 1 1 1 1 1 1 a a a a a a a", 5, 20000)]
        [InlineData("a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z",
            26, 20000)]
        [InlineData("aa ", 1, 20000)]
        public void GetUniqueWordsCount_Test(string input, int expected, int memoryLimit)
        {
            //GC.TryStartNoGCRegion(1048576);
            var bytesBefore = GC.GetTotalAllocatedBytes(true);
            var actual = StringStan.GetUniqueWordsCount(input);
            var bytesAfter = GC.GetTotalAllocatedBytes(true);
            var allocatedBytes = bytesAfter - bytesBefore;

            Assert.True(allocatedBytes < memoryLimit, $"Memory limit exceed: allocated={allocatedBytes}; limit={memoryLimit}");

            Assert.Equal(expected, actual);
        }
    }
}