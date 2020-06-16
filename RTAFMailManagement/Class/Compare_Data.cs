using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Class
{
    public class Compare_Data
    {
        public RTAF_DATA sevice_data { get; set; } //ข้อมูลจาก webservice
        public RTAF_DATA db_data { get; set; } //ข้อมูลจาก database
        
    }
}