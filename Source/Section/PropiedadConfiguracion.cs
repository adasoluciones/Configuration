using System.Configuration;

namespace Ada.Framework.Configuration.Section
{
    public class PropiedadConfiguracion : ConfigurationElement
    {
        /// <summary>
        /// Obtiene o establece el nombre identificador del archivo. Puede no corresponder al nombre del archivo físico.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 06/10/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [ConfigurationProperty("Name", IsRequired = true, IsKey = true)]
        public string Nombre
        {
            get
            {
                return this["Name"] as string;
            }

            set
            {
                this["Name"] = value;
            }
        }

        /// <summary>
        /// Obtiene o establece la ruta del archivo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 06/10/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [ConfigurationProperty("Value", IsRequired = true)]
        private string _Valor
        {
            get
            {
                return this["Value"] as string;
            }

            set
            {
                this["Value"] = value;
            }
        }

        public object Valor 
        {
            get
            {
                return Ada.Framework.Data.Json.JsonConverterFactory.ObtenerJsonConverter().ToObject(_Valor, false);
            }

            set
            {
                _Valor = Ada.Framework.Data.Json.JsonConverterFactory.ObtenerJsonConverter().ToJson(value);
            }
        }
    }
}
