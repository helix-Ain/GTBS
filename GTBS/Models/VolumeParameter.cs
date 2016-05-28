using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTBS.Models
{
    public class VolumeParameter
    {
        public Guid[] Question_Id { get; set; }
        public string Paper_Name { get; set; }
        public string Paper_Author { get; set; }
        public string Paper_Grade { get; set; }
        public string Paper_Subject { get; set; }
        public string Paper_Kind { get; set; }
        public string Paper_Province { get; set; }
    }
}