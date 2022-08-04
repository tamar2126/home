using COMMON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL
{
    public class CityD
    {
        private static readonly string _cityFilePath= Directory.GetCurrentDirectory() + "\\Json\\city.json";
        public static IList<ComCity> GetAllCities()
        {
          var cityList= Helper.ReadFromJsonFile<ComCity>(_cityFilePath);
          return cityList;
        }
    }
}
