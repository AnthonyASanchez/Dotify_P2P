using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Dotify
{
    /// <summary>
    /// Universal Json utilities
    /// </summary>
    class JsonUtil
    {
        // The path that contains all of the Json files
        private static string SYSTEM_SAVE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        // Where the user information is located
        public const string USER_JSON_FILE = "user.json";
        // Where the system cache information is located
        public const string SYSTEM_CACHE_FILE = "system_cache.json";

        /// <summary>
        /// Converts an object to a Json String instance
        /// </summary>
        /// <param name="obj">The object to stringify</param>
        /// <returns>The object in Json Format</returns>
        public static string Stringify(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Turns a string item into an object
        /// </summary>
        /// <param name="str">The stringified object</param>
        /// <returns>The string in Object form</returns>
        public static Type ToObject<Type>(string str)
        {
            return JsonConvert.DeserializeObject<Type>(str);
        }

        /// <summary>
        /// Read contents the of the specified filepath and return it
        /// </summary>
        /// <param name="filePath">The filepath to read from</param>
        /// <returns>Null if the filepath does not exist, a String otherwise</returns>
        private static string ReadContents(string filePath)
        {

            // If the file doesn't exist, return null
            if (!File.Exists(filePath))
            {
                return null;
            }
            // Retrieve the contents
            using (var streamReader = new StreamReader(filePath))
            {
                string stringifiedItem = streamReader.ReadToEnd();
                return stringifiedItem;
            }
        }

        /// <summary>
        /// Saves a stringified object to the specified file name path
        /// </summary>
        /// <param name="stringifiedObject">The stringified Json object</param>
        /// <param name="fileName">The file name in which to place the Json object</param>
        public static void SaveJsonToFile(string stringifiedObject, string fileName)
        {
            // Create the path to the file location
            string saveLocation = Path.Combine(SYSTEM_SAVE_PATH, fileName);
            
            // If the file already exists, delete the file so we can overwrite it
            if (File.Exists(saveLocation))
            {
                File.Delete(saveLocation);
            }

            // Write the stringified json object over to the save location
            using (var streamWriter = new StreamWriter(saveLocation, true))
            {
                streamWriter.WriteLine(stringifiedObject);
            }
        }

        /// <summary>
        /// Retrieves a stored ProfileInfo object
        /// </summary>
        /// <returns>Null if there is no stored information and ProfileInfo if there is</returns>
        public static ProfileInfo GetJsonUser()
        {
            // The path to the stringified ProfileInfo object
            string userJsonLocation = Path.Combine(SYSTEM_SAVE_PATH, USER_JSON_FILE);

            string stringifiedUser = ReadContents(userJsonLocation);
            if (stringifiedUser == null)
            {
                return null;
            }
            // Type cast the user object and return
            return ToObject<ProfileInfo>(stringifiedUser);

        }        

        /// <summary>
        /// Retrieves a stored SystemCache object
        /// </summary>
        /// <returns>Null if there is no stored information and ProfileInfo if there is</returns>
        public static SystemCache GetJsonSystemCache()
        {
            // The path to the stringified SystemCache object
            string systemCacheLocation = Path.Combine(SYSTEM_SAVE_PATH, USER_JSON_FILE);

            string stringifiedSystemCache = ReadContents(systemCacheLocation);
            if (stringifiedSystemCache == null)
            {
                return null;
            }

            // Type case the SystemCache object and return
            return ToObject<SystemCache>(stringifiedSystemCache);
        }
    }
}
