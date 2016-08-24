using System.Configuration;

namespace Ada.Framework.Configuration.Section
{
    [ConfigurationCollection(typeof(ColeccionPropiedadesConfiguracion),
            AddItemName = "Property",
            ClearItemsName = "Clear",
            RemoveItemName = "Delete")]
    public class GrupoPropiedadesConfiguracion  : ConfigurationElementCollection
    {
        public ColeccionPropiedadesConfiguracion this[int index]
        {
            get { return (ColeccionPropiedadesConfiguracion)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ColeccionPropiedadesConfiguracion coleccionPropiedadesConfiguracion)
        {
            BaseAdd(coleccionPropiedadesConfiguracion);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ColeccionPropiedadesConfiguracion();
        }

        protected override object GetElementKey(ConfigurationElement coleccionPropiedadesConfiguracion)
        {
            return ((ColeccionPropiedadesConfiguracion)coleccionPropiedadesConfiguracion);
        }

        public void Remove(ColeccionPropiedadesConfiguracion coleccionPropiedadesConfiguracion)
        {
            BaseRemove(coleccionPropiedadesConfiguracion);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}
