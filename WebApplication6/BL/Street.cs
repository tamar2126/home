using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
  public  class Street
    {
        public static List<ComStreet> GetAllStreetsByCityId(int cityId)
        {
            return StreetD.GetAllStreetsByCityId().Where(a=>a.CityId==cityId).ToList();
        }

        public static void DeleteStreet(int streetId)
        {
            StreetD.DeleteStreet(streetId);
        }

        public static ComStreet UpdateStreet(ComStreet street)
        {
          return StreetD.UpdateStreet(street);
        }

        public static ComStreet AddStreet(ComStreet street)
        {
            return StreetD.AddStreet(street);
        }
    }
}
