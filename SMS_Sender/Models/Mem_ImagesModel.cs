using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Mem_ImagesModel
    {
        public int ImgID { get; set; }
        public int MemId { get; set; }
        public string ImgName { get; set; }
        public int ImgStatusId { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool isDel { get; set; }
    }
}