using System.Configuration;

namespace Ada.Framework.Configuration.Section
{
    public class ColeccionPropiedadesConfiguracion : ConfigurationElementCollection
    {
        public ColeccionPropiedadesConfiguracion()
        {
            AddElementName = "Property";
        }

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

        public PropiedadConfiguracion this[int index]
        {
            get { return (PropiedadConfiguracion)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(PropiedadConfiguracion propiedadConfiguracion)
        {
            BaseAdd(propiedadConfiguracion);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PropiedadConfiguracion();
        }

        protected override object GetElementKey(ConfigurationElement propiedadConfiguracion)
        {
            return ((PropiedadConfiguracion)propiedadConfiguracion).Nombre;
        }

        public void Remove(PropiedadConfiguracion propiedadConfiguracion)
        {
            BaseRemove(propiedadConfiguracion.Nombre);
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
