using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Dotify
{
    [DataContract]
    class ProfileInfo
    {
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
        [DataMember(Name = "Join_Data")]
        public DateTime dateJoined { get; set; }
        [DataMember(Name = "Search_History")]
        public List<string> searchHist;
        [DataMember(Name = "Play_History")]
        public List<string> playHist;

        public ProfileInfo(string user, string pass, string question1, string question2,
            string answer1, string answer2)
        {
            username = user;
            password = pass;
            securityQuestion1 = question1;
            securityQuestion2 = question2;
            securityAnswer1 = answer1;
            securityAnswer2 = answer2;
            searchHist = new List<string>();
            playHist = new List<string>();
            dateJoined = DateTime.Today;
        }

        public void AddSearchInfo(string info)
        {
            searchHist.Add(info);
        }
        public void AddPlayInfo(string songInfo)
        {
            playHist.Add(songInfo);
        } 
    }
}
