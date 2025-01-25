using System;

namespace LMS.Application.Common.Exceptions
{
#pragma warning disable S3925 // Update this implementation of 'ISerializable' to conform to the recommended serialization pattern.
    // S3925 says to override GetDataObject to include any instance fields in the serialization process since they are
    // not included automatically, however there are none declared here, so it's a false positive
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
#pragma warning restore S3925 // Update this implementation of 'ISerializable' to conform to the recommended serialization pattern.
}
