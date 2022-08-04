using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DAL
{
    public class Helper
    {
        public static IList<T> ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                IList<T> fileContents = new List<T>();
                if (File.Exists(filePath))
                {
                    reader = new StreamReader(filePath);
                    string item;
                    while ((item = reader.ReadLine()) != null)
                    {
                        fileContents.Add(JsonSerializer.Deserialize<T>(item));
                    }
                }
                return fileContents;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        public static void DeleteFromJsonFile<T>(string filePath, T objectToDelete, bool append = false) where T : new()
        {                
                List<string> quotelist = File.ReadAllLines(filePath).ToList();
                int index = quotelist.IndexOf(JsonSerializer.Serialize(objectToDelete));
            if (index >= 0)
            {
                quotelist.RemoveAt(index);
                File.WriteAllLines(filePath, quotelist.ToArray());
            }
            }
        public static T UpdateJsonFile<T>(string filePath, T objectToUpdate, T oldObject, bool append = false) where T : new()
        {
            List<string> quotelist = File.ReadAllLines(filePath).ToList();
            int index = quotelist.IndexOf(JsonSerializer.Serialize(oldObject)); 
            if(index>=0)
            {
                quotelist.RemoveAt(index);
                quotelist.Insert(index, JsonSerializer.Serialize(objectToUpdate));
                File.WriteAllLines(filePath, quotelist.ToArray());
            }               
            return objectToUpdate;
        }
        public static T WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonSerializer.Serialize(objectToWrite);
                var directoryPath = filePath.Substring(0, filePath.LastIndexOf("\\"));
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                writer = new StreamWriter(filePath, append);
                writer.WriteLine(contentsToWriteToFile);
                return objectToWrite;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }


    }

}

