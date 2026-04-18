using System;

namespace Migs.EnumMetadata
{
    public class EnumMetadataNotFoundException : Exception
    {
        public EnumMetadataNotFoundException()
        {
        }

        public EnumMetadataNotFoundException(string? message) 
            : base(message)
        {
        }

        public EnumMetadataNotFoundException(string? message, Exception? innerException) 
            : base(message, innerException)
        {
        }

        public EnumMetadataNotFoundException(Type attributeType, Enum value)
            : base($"Could not find the requested '{attributeType.Name}' for '{value.GetType().Name}.{value}'!")
        {
        }
    }
}
