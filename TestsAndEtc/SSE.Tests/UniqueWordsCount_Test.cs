using Span.String.Examples;

namespace OtherStaff.Tests
{
    public class UniqueWordsCount_Test
    {
        private const string LONG_INPUT = "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z " +
            "a b c d e f g h i j k l m n o p q r s t u v w x y z";

        [Theory(DisplayName = "Memory allocation is not expected")]
        [InlineData("aa a a a aa bb as 1 1 1 1 1 1 1 1 1 1 1 a a a a a a a", 5, 20000)]
        [InlineData(LONG_INPUT, 26, 20000)]
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

        [Theory(DisplayName = "Memory allocation is expected")]
        [InlineData(LONG_INPUT, 26, 20000)]
        public void GetUniqueWordsCount2_Test(string input, int expected, int memoryLimit)
        {
            //GC.TryStartNoGCRegion(1048576);
            var bytesBefore = GC.GetTotalAllocatedBytes(true);
            var actual = StringStan.GetUniqueWordsCount2(input);
            var bytesAfter = GC.GetTotalAllocatedBytes(true);
            var allocatedBytes = bytesAfter - bytesBefore;

            Assert.True(allocatedBytes > memoryLimit, $"Memory limit not exceed: allocated={allocatedBytes}; limit={memoryLimit}");

            Assert.Equal(expected, actual);
        }
    }
}