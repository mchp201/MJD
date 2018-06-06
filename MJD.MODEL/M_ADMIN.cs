using System;

namespace MJD.MODEL
{
    public class M_ADMIN
    {
        public int Key { 
            get{ return ID; } 
        }
        public int ID { get; set; }
        public int RID { get; set; }
        public string Name { get; set; }
        public string TeleNum { get; set; }
        public Int64 CreateTime { get; set; }
        public string CreateIP { get; set; }
        public int Status { get; set; }

        public int pageSize { get; set; }
        public int currentPage { get; set; }
        public int total { get; set; }
        public int ErrCode  { get; set; }
        public string ErrMsg  { get; set; }
    }
}
