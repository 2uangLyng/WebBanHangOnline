using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public class CommonAbstract
    {
        public string CreactedBy { get; set; }
        public DateTime CreactedDate { get; set; }
        public DateTime ModifiedrDate { get; set; }
        public string ModifierBy { get; set; }
    }
}