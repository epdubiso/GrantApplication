using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssist2017MVC.Models
{
    public class GrantApplication1
    {
        public string GrantApplicationKey { set; get; }
        public string personKey { set; get; }
        public string GrantApplicationDate { set; get; } 
        public string GrantTypeKey { set; get; }
        public string GrantApplicationRequestAmount { set; get; }
        public string GrantApllicationReasons { set; get; }
        public string GrantApllicationStatusKey { set; get; }
        public string GrantApplicationAllocationAmount { set; get; }

    }
}