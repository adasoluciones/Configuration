using System.Configuration;

namespace Ada.Framework.Configuration.Section
{
    public class FrameworkConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("ConfigFiles", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ColeccionArchivosConfiguracion),
            AddItemName = "File",
            ClearItemsName = "Clear",
            RemoveItemName = "Delete")]
        public ColeccionArchivosConfiguracion ConfigFiles
        {
            get
            {
                return (ColeccionArchivosConfiguracion)base["ConfigFiles"];
            }
        }

        [ConfigurationProperty("ConfigProperties", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(GrupoPropiedadesConfiguracion),
            AddItemName = "PropertiesGroup",
            ClearItemsName = "Clear",
            RemoveItemName = "Delete")]
        public GrupoPropiedadesConfiguracion ConfigProperties
        {
            get
            {
                return (GrupoPropiedadesConfiguracion)base["ConfigProperties"];
            }
        }

    }
}
