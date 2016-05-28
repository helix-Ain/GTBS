using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GTBS.Data.Domain
{
    /// <summary>
    /// 试卷信息表
    /// </summary>
    [Table("EO_PaperInfo")]
    public class PaperInfo
    {
        [Key]
        public Guid Paper_Id { get; set; }
        public Guid? Paper_Subject_Id { get; set; }
        public string Paper_Subject { get; set; }
        public string Paper_Author { get; set; }
        public string Paper_Grade { get; set; }
        public string Paper_Kind { get; set; }
        public string Paper_Province { get; set; }
        public DateTime? Paper_Time { get; set; }
        public string Paper_Name { get; set; }
        public string Paper_Path { get; set; }
        //试卷下载量
        public long Paper_Download { get; set; }
        //试卷状态0为无效1为正常
        public bool Paper_State { get; set; }
        //试卷所属年份
        public string Paper_Year { get; set; }
    }
}