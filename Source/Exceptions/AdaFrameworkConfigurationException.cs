using System;

namespace Ada.Framework.Configuration.Exceptions
{
    public class AdaFrameworkConfigurationException: Exception
    {
        public AdaFrameworkConfigurationException() : base() { }

        public AdaFrameworkConfigurationException(string mensaje)
            : base(mensaje) { }

        public AdaFrameworkConfigurationException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}
