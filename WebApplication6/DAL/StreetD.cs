using COMMON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StreetD
    {
        private static readonly string _streetFilePath = Directory.GetCurrentDirectory() + "\\Json\\street.json";
        private static int _id;
        public StreetD()
        {
            var streets = Helper.ReadFromJsonFile<ComStreet>(_streetFilePath).ToList();
            _id = streets.First(a => a.Id == streets.Max(d => d.Id)).Id+1;
        }

        

        public static List<ComStreet> GetAllStreetsByCityId()
        {
            return Helper.ReadFromJsonFile<ComStreet>(_streetFilePath).ToList();
        }

        public static void DeleteStreet(int streetId)
        {
           var street= Helper.ReadFromJsonFile<ComStreet>(_streetFilePath).ToList().FirstOrDefault(s => s.Id == streetId);
            Helper.DeleteFromJsonFile(_streetFilePath, street);
        }

        public static ComStreet AddStreet(ComStreet street)
        {
            street.Id = _id;
            _id++;
           return Helper.WriteToJsonFile(_streetFilePath, street, true);

        }

        public static ComStreet UpdateStreet(ComStreet street)
        {
            var oldItem = Helper.ReadFromJsonFile<ComStreet>(_streetFilePath).ToList().FirstOrDefault(s => s.Id == street.Id);
          return  Helper.UpdateJsonFile(_streetFilePath, street, oldItem);
        }
    }
}
