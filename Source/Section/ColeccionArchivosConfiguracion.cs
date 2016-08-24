using System.Configuration;

namespace Ada.Framework.Configuration.Section
{
    public class ColeccionArchivosConfiguracion : ConfigurationElementCollection
    {
        public ArchivoConfiguracion this[int index]
        {
            get { return (ArchivoConfiguracion)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ArchivoConfiguracion archivoConfiguracion)
        {
            BaseAdd(archivoConfiguracion);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ArchivoConfiguracion();
        }

        protected override object GetElementKey(ConfigurationElement archivoConfiguracion)
        {
            return ((ArchivoConfiguracion)archivoConfiguracion).Nombre;
        }

        public void Remove(ArchivoConfiguracion archivoConfiguracion)
        {
            BaseRemove(archivoConfiguracion.Nombre);
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
