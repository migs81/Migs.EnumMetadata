using System.Diagnostics.CodeAnalysis;

namespace Migs.EnumMetadata.Benchmarks.TestData
{
    public class ColorAttribute : EnumMetadataAttribute
    {
        public string Code { get; }

        public ColorAttribute(
            [DisallowNull] string name,
            [DisallowNull] string description,
            [DisallowNull] string code)
            : base(name, description)
        {
            Code = code;
        }

        public ColorAttribute(
            [DisallowNull] string name,
            [DisallowNull] string description)
            : base(name, description)
        {
            Code = "";
        }
    }
}
