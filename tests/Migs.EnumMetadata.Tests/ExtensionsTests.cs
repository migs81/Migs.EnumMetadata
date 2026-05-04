using Xunit;

namespace Migs.EnumMetadata.Tests
{
    public class ExtensionsTests
    {
        private const string Name = "Test";
        private const string Description = "Just a test";

        private enum Default
        {
            [EnumMetadata(Name, Description)]
            None,
        }

        private enum Color
        {
            [EnumMetadata(Name, Description)]
            None = 0,

            [EnumMetadata(Name, Description)]
            Black = 1,

            [EnumMetadata(Name, Description)]
            Red = 2,

            [EnumMetadata(Name, Description)]
            Green = 4,

            [EnumMetadata(Name, Description)]
            Blue = 8
        }

        [Fact]
        [Trait("Category", "Extension")]
        public void GetAttribute_DefaultEnum_ShouldBeEqual()
        {
            Assert.Equal(Name, Default.None.GetAttribute<EnumMetadataAttribute>().Name);
            Assert.Equal(Description, Default.None.GetAttribute<EnumMetadataAttribute>().Description);
        }

        [Fact]
        [Trait("Category", "Extension")]
        public void GetAttribute_FlaggedEnum_ShouldBeEqual()
        {
            Assert.Equal(Name, Color.Black.GetAttribute<EnumMetadataAttribute>().Name);
            Assert.Equal(Description, Color.Blue.GetAttribute<EnumMetadataAttribute>().Description);
        }
    }
}
