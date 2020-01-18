using System;

namespace TestCleverbit.DataAccess.EntityFrameworkConfiguration
{
    public class UpdateConcurrencyException : Exception
    {
        public UpdateConcurrencyException() { }

        public UpdateConcurrencyException(string message) : base(message) { }

        public UpdateConcurrencyException(string message, Exception innerException) : base(message, innerException) { }

        public static UpdateConcurrencyException From(Exception ex)
            => new UpdateConcurrencyException(ex.Message, ex.InnerException);
    }
}
