using System;

namespace Migs.EnumMetadata.Benchmarks.TestData
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorAttribute : EnumMetadataAttribute
    {
        public string Code { get; }

        public ColorAttribute(string name, string description, string code) : base(name, description)
        {
            Code = code;
        }

        public ColorAttribute(string name, string description) : base(name, description)
        {
            Code = "";
        }
    }
}
