using System;

namespace Salon.Common.Exceptions
{
    public class SalonException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public SalonException(ErrorCode errorCode)
            : this(errorCode, errorCode.Message)
        {
        }

        public SalonException(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        {
        }

        public SalonException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
