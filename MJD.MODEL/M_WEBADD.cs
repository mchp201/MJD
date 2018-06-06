using System;

namespace MJD.MODEL
{
    public class M_WEBADD
    {
        public int Key { 
            get{ return ID; } 
        }
        public int ID { get; set; }
        public string UName { get; set; }
        public string UCardid { get; set; }
        public string UTelenum { get; set; }
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
