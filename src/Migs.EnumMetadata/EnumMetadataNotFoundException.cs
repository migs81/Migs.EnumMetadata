using System;

namespace Migs.EnumMetadata.Exceptions
{
    public class EnumDataNotFoundException : Exception
    {
        public EnumDataNotFoundException()
        {
        }

        public EnumDataNotFoundException(string? message) 
            : base(message)
        {
        }

        public EnumDataNotFoundException(string? message, Exception? innerException) 
            : base(message, innerException)
        {
        }

        public EnumDataNotFoundException(Type attributeType, Enum value)
            : base($"Could not find the requested '{attributeType.Name}' for '{value.GetType().Name}.{value}'!")
        {
        }
    }
}
