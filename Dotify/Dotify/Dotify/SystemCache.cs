using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Dotify
{
    /// <summary>
    /// System level information class
    /// </summary>
    [DataContract]
    class SystemCache
    {
        public static int LOGGED_IN
        {
            get { return 300; }
        }
        public static int LOGGED_OUT
        {
            get { return 500; }
        }

        [DataMember (Name = "loginStatus")]
        public int isLoggedIn { get; set; }
    }
}
