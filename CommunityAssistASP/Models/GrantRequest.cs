using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Model for making a grant request

namespace CommunityAssistASP.Models
{
    public class GrantRequest
    {
        public int GrantApplicationKey { get; set; }
        public int PersonKey { get; set; }
        public DateTime GrantApplicationDate { get; set; }
        public int GrantTypeKey { get; set; }
        public decimal GrantApplicationRequestAmount { get; set; }
        public string GrantApplicationReason { get; set; }
        public int GrantApplicationStatusKey { get; set; }
    }
}