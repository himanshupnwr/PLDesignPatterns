using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adaptor.V1_Basic
{
    public class CityFromExternalSystem_Class
    {
        public string Name { get; private set; }
        public string NickName { get; private set; }
        public int Inhabitants { get; private set; }

        public CityFromExternalSystem_Class(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }
    }

    /// <summary>
    /// Adaptee
    /// </summary>
    public class ExternalSystem_Class
    {
        public CityFromExternalSystem_Class GetCity()
        {
            return new CityFromExternalSystem_Class("Antwerp", "'t Stad", 500000);
        }
    }

    public class City_Class
    {
        public string FullName_Class { get; private set; }
        public long Inhabitants_Class { get; private set; }

        public City_Class(string fullName, long inhabitants)
        {
            FullName_Class = fullName;
            Inhabitants_Class = inhabitants;
        }
    }

    /// <summary>
    /// Target
    /// </summary>
    public interface ICityAdapter_Class
    {
        City_Class GetCity();
    }

    /// <summary>
    /// Adapter
    /// </summary>
    public class CityAdapter_Class : ExternalSystem_Class, ICityAdapter_Class
    {
        public City_Class GetCity()
        {
            // call into the external system 
            var cityFromExternalSystem = base.GetCity();

            // adapt the CityFromExternalCity to a City 
            return new City_Class($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}"
                , cityFromExternalSystem.Inhabitants);
        }
    }
}
