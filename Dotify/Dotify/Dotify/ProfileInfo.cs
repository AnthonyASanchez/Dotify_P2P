using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify
{
    class ProfileInfo
    {
        string username { get; set; }
        string password { get; set; }
        List<string> searchHist;
        List<string> playHist;
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
