using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Xamarin.Forms;

namespace Dotify
{
    /// <summary>
    /// Singleton instance of this class with global access
    /// </summary>
    [DataContract]
    sealed class ProfileInfo
    {
        // Data values that are stored into Json
        [DataMember(Name = "username")]
        public string username { get; set; }
        [DataMember(Name = "password")]
        public string password { get; set; }
        [DataMember(Name = "Security_Question_1")]
        public string securityQuestion1 { get; set; }
        [DataMember(Name = "Security_Question_2")]
        public string securityQuestion2 { get; set; }
        [DataMember(Name = "Security_Answer_1")]
        public string securityAnswer1 { get; set; }
        [DataMember(Name = "Security_Answer_2")]
        public string securityAnswer2 { get; set; }
        [DataMember(Name = "Join_Date")]
        public DateTime dateJoined { get; set; }
        [DataMember(Name = "Profile_Picture")]
        public Image profile_image { get; set; }
        [DataMember(Name = "Search_History")]
        public List<string> searchHist;

        // Keeps track to see if this class has been instantiated
        private static ProfileInfo instance = null;
        
        public static ProfileInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = JsonUtil.GetJsonUser();
                }
                return instance;
            }
        }

        /// <summary>
        /// Creates a new user instance
        /// </summary>
        /// <param name="user">The preferred username</param>
        /// <param name="pass">The preferred password</param>
        /// <param name="question1">The preferred security question</param>
        /// <param name="question2">The 2nd preferred security question</param>
        /// <param name="answer1">The user's answer to the first security question</param>
        /// <param name="answer2">The user's answer to the second security question</param>
        /// <returns></returns>
        public static ProfileInfo CreateNewUser(string user, string pass, string question1, string question2,
            string answer1, string answer2)
        {
            return new ProfileInfo(user, pass, question1, question2, answer1, answer2);
        }

        
        private ProfileInfo(string user, string pass, string question1, string question2,
            string answer1, string answer2)
        {
            username = user;
            password = pass;
            securityQuestion1 = question1;
            securityQuestion2 = question2;
            securityAnswer1 = answer1;
            securityAnswer2 = answer2;
            searchHist = new List<string>();
            dateJoined = DateTime.Today;
        }

        public ProfileInfo()
        {

        }
    }
}
