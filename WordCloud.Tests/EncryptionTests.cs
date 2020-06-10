using WordCloud.Infrastructure;
using Xunit;

namespace WordCloud.Tests
{
    public class EncryptionTests
    {
        [Fact]
        public void ValidateSaltedHashDiffersForMultipleCallsWithSameTestString()
        {
            // Arrange
            var testString = "TestThis";

            // Act
            var result1 = Encryption.GenerateSaltedHash(testString);
            var result2 = Encryption.GenerateSaltedHash(testString);

            Assert.NotEqual(result1, result2);
        }
    }
}
