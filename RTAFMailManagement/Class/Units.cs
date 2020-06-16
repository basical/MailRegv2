using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Class
{
    public class Units
    {
        public long unit_id { get; set; }
        public long unit_Code { get; set; }
        public string unit_Name { get; set; }
        public string unit_FullName { get; set; }
        public long unit_SubCode { get; set; }
        public int unit_Sort { get; set; }
        public int unit_Level { get; set; }
        public string unit_OUName { get; set; }
        public string unit_GroupName { get; set; }
        public string unit_Remark { get; set; }
    }
}