using System;
using Xunit;

namespace Migs.EnumMetadata.Tests
{
    public class EnumMetadataTests
    {
        [Fact]
        [Trait("Category", "Attribute")]
        public void Constructor_WithValues_ShouldReturnValidObject()
        {
            const string name = "Test";
            const string description = "Just a test";

            var attribute = new EnumMetadataAttribute(name, description);

            Assert.NotNull(attribute);
            Assert.Equal(name, attribute.Name);
            Assert.Equal(description, attribute.Description);
        }

        [Theory]
        [Trait("Category", "Attribute")]
        [InlineData(null, "")]
        [InlineData("", null)]
        public void Constructor_NullValue_ShouldThrowException(string name, string description)
        {
            Assert.Throws<ArgumentNullException>(() => new EnumMetadataAttribute(name, description));
        }
    }
}
