using System;

namespace LicenseManager.Core.Domain
{
    public class DomainException : Exception
    {
        public string Code { get; }

        public DomainException()
        {
        }

        public DomainException(string code)
        {
            Code = code;
        }

        public DomainException(string message, params object[] args)
            : this(code: String.Empty, message: message, args: args)
        {
        }

        public DomainException(string code, string message, params object[] args)
            : this(innerException: null, code: code, message: message, args: args)
        {
        }

        public DomainException(Exception innerException, string message, params object[] args)
            : this(innerException: innerException, code: string.Empty, message: message, args: args)
        {
        }

        public DomainException(Exception innerException, string code, string message, params object[] args)
            : base(message: string.Format(message, args), innerException: innerException)
        {
            Code = code;
        }
    }
}