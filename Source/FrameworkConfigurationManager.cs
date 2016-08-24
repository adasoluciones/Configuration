using Ada.Framework.Configuration.Exceptions;
using Ada.Framework.Configuration.Section;
using System;
using System.Collections.Generic;

namespace Ada.Framework.Configuration
{
    public static class FrameworkConfigurationManager
    {
        public static IList<PropiedadConfiguracion> ObtenerPropiedades(string grupo)
        {
            IList<PropiedadConfiguracion> retorno = new List<PropiedadConfiguracion>();

            object seccion = System.Configuration.ConfigurationManager.GetSection("FrameworkConfigSection/FrameworkConfig");

            FrameworkConfigSection config = seccion as FrameworkConfigSection;

            if (config == null)
            {
                throw new AdaFrameworkConfigurationException("¡No está declarada la sección de configuración en el archivo!");
            }

            if (!(seccion is FrameworkConfigSection))
            {
                throw new AdaFrameworkConfigurationException("¡El tipo de la sección FrameworkConfigSection/FrameworkConfig no es Ada.Framework.Config.Section.AdaFrameworkConfigSection!");
            }

            if (string.IsNullOrEmpty(grupo))
            {
                throw new AdaFrameworkConfigurationException("¡El grupo no puede ser nulo o vacio!");
            }

            foreach (ColeccionPropiedadesConfiguracion xGrupo in config.ConfigProperties)
            {
                if (xGrupo.Nombre.Equals(grupo, StringComparison.InvariantCultureIgnoreCase))
                {
                    foreach (PropiedadConfiguracion propiedad in xGrupo)
                    {
                        retorno.Add(propiedad);
                    }
                    break;
                }
            }

            return retorno;
        }

        public static IList<ColeccionPropiedadesConfiguracion> ObtenerGrupos()
        {
            IList<ColeccionPropiedadesConfiguracion> retorno = new List<ColeccionPropiedadesConfiguracion>();

            object seccion = System.Configuration.ConfigurationManager.GetSection("FrameworkConfigSection/FrameworkConfig");

            FrameworkConfigSection config = seccion as FrameworkConfigSection;

            if (config == null)
            {
                throw new AdaFrameworkConfigurationException("¡No está declarada la sección de configuración en el archivo!");
            }

            if (!(seccion is FrameworkConfigSection))
            {
                throw new AdaFrameworkConfigurationException("¡El tipo de la sección FrameworkConfigSection/FrameworkConfig no es Ada.Framework.Config.Section.AdaFrameworkConfigSection!");
            }

            foreach (ColeccionPropiedadesConfiguracion grupo in config.ConfigProperties)
            {
                retorno.Add(grupo);
            }

            return retorno;
        }

        public static PropiedadConfiguracion ObtenerPropiedad(string grupo, string nombre)
        {
            object seccion = System.Configuration.ConfigurationManager.GetSection("FrameworkConfigSection/FrameworkConfig");

            FrameworkConfigSection config = seccion as FrameworkConfigSection;

            if (config == null)
            {
                throw new AdaFrameworkConfigurationException("¡No está declarada la sección de configuración en el archivo!");
            }

            if (!(seccion is FrameworkConfigSection))
            {
                throw new AdaFrameworkConfigurationException("¡El tipo de la sección FrameworkConfigSection/FrameworkConfig no es Ada.Framework.Config.Section.AdaFrameworkConfigSection!");
            }

            if (string.IsNullOrEmpty(grupo))
            {
                throw new AdaFrameworkConfigurationException("¡El grupo no puede ser nulo o vacio!");
            }

            if (string.IsNullOrEmpty(nombre))
            {
                throw new AdaFrameworkConfigurationException("¡El nombre de la propiedad no puede ser nulo o vacio!");
            }

            bool existeGrupo = false;

            foreach (ColeccionPropiedadesConfiguracion xGrupo in config.ConfigProperties)
            {
                if (xGrupo.Nombre.Equals(grupo, StringComparison.InvariantCultureIgnoreCase))
                {
                    existeGrupo = true;
                    foreach (PropiedadConfiguracion propiedad in xGrupo)
                    {
                        if (propiedad.Nombre.Equals(nombre, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return propiedad;
                        }
                    }
                    break;
                }
            }
            if (!existeGrupo)
            {
                throw new AdaFrameworkConfigurationException(string.Format("¡No está declarado el grupo de propiedades {0}!", grupo));
            }
            else
            {
                throw new AdaFrameworkConfigurationException(string.Format("¡No está declarado la propiedad {0} del grupo de propiedades {1}!", nombre, grupo));
            }
        }

        public static object ObtenerValorPropiedad(string grupo, string nombre)
        {
            return ObtenerPropiedad(grupo, nombre).Valor;
        }

        public static T ObtenerValorPropiedad<T>(string grupo, string nombre)
        {
            return (T)ObtenerPropiedad(grupo, nombre).Valor;
        }

        public static ArchivoConfiguracion ObtenerArchivoConfiguracion(string nombre)
        {
            object seccion = System.Configuration.ConfigurationManager.GetSection("FrameworkConfigSection/FrameworkConfig");

            FrameworkConfigSection config = seccion as FrameworkConfigSection;

            if (config == null)
            {
                throw new AdaFrameworkConfigurationException("¡No está declarada la sección de configuración en el archivo!");
            }

            if (!(seccion is FrameworkConfigSection))
            {
                throw new AdaFrameworkConfigurationException("¡El tipo de la sección FrameworkConfigSection/FrameworkConfig no es Ada.Framework.Config.Section.AdaFrameworkConfigSection!");
            }

            if (string.IsNullOrEmpty(nombre))
            {
                throw new AdaFrameworkConfigurationException("¡El nombre no puede ser nulo o vacio!");
            }

            foreach (ArchivoConfiguracion archivoConfiguracion in config.ConfigFiles)
            {
                if (archivoConfiguracion.Nombre.Equals(nombre, StringComparison.InvariantCultureIgnoreCase))
                {
                    return archivoConfiguracion;
                }
            }

            throw new AdaFrameworkConfigurationException(string.Format("¡No está declarado el archivo de configuración {0}!", nombre));
        }

        public static string ObtenerRutaArchivoConfiguracion(string nombre)
        {
            return ObtenerArchivoConfiguracion(nombre).Ruta;
        }
    }
}
