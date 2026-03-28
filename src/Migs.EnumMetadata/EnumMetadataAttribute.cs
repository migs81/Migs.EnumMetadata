using System;
using System.Diagnostics.CodeAnalysis;

namespace Migs.EnumMetadata
{
    /// <summary>
    /// Attribute to append additional data to enumerations.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnumMetadataAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumMetadataAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public EnumMetadataAttribute([DisallowNull] string name, [DisallowNull] string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}