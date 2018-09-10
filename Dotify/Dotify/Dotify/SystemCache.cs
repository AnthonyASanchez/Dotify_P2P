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
        [DataMember (Name = "loginStatus")]
        public bool isLoggedIn { get; set; }
    }
}
