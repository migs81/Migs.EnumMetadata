namespace Migs.EnumMetadata.Benchmarks.TestData
{
    public static class Enums
    {
        public enum NameType
        {
            [EnumMetadata(name: "Test", description: "Just a test")]
            FirstName = 0,

            [EnumMetadata(name: "Test", description: "Just a test")]
            MiddleName,

            [EnumMetadata(name: "Test", description: "Just a test")]
            LastName,

            FullName
        }

        public enum Color
        {
            [Color(name: "Test", description: "Just a test", code: "T")]
            None = 0,

            [Color(name: "Blue", description: "The color blue.", code: "B")]
            Blue,
        }
    }
}
