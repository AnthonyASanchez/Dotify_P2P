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
        // Where the user information is located
        public const string USER_JSON_FILE = "user.json";

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
        /// Saves a stringified object to the specified file name path
        /// </summary>
        /// <param name="stringifiedObject">The stringified Json object</param>
        /// <param name="fileName">The file name in which to place the Json object</param>
        public static void SaveJsonToFile(string stringifiedObject, string fileName)
        {
            // Create the path to the file location
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string saveLocation = Path.Combine(path, fileName);
            
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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string userJsonLocation = Path.Combine(path, USER_JSON_FILE);

            // If the file doesn't exist, return null
            if (!File.Exists(userJsonLocation))
            {
                return null;
            }
            else
            {
                // Retrieve the contents
                using (var streamReader = new StreamReader(userJsonLocation))
                {
                    string stringifiedUser = streamReader.ReadToEnd();
                    ProfileInfo user = ToObject<ProfileInfo>(stringifiedUser);
                    return user;
                }
            }
        }
        
    }
}
