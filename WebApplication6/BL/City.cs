using COMMON;
using DAL;
using System;
using System.Collections.Generic;


namespace BL
{
    public class City
    {
      

        public static IList<ComCity> GetAllCities()
        {
            return DAL.CityD.GetAllCities();
        }

    }
}
