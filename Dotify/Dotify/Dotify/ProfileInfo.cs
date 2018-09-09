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
        string username { get; set; }
        [DataMember(Name = "password")]
        string password { get; set; }
        [DataMember(Name = "Security_Question_1")]
        string securityQuestion1 { get; set; }
        [DataMember(Name = "Security_Question_2")]
        string securityQuestion2 { get; set; }
        [DataMember(Name = "Security_Answer_1")]
        string securityAnswer1 { get; set; }
        [DataMember(Name = "Security_Answer_2")]
        string securityAnswer2 { get; set; }
        [DataMember(Name = "Search_History")]
        List<string> searchHist;
        [DataMember(Name = "Play_History")]
        List<string> playHist;

        public ProfileInfo()
        {
            username = "";
            password = "";
            searchHist = new List<string>();
            playHist = new List<string>();
        }

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
