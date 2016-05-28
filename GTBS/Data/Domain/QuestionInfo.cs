using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GTBS.Data.Domain
{
    /// <summary>
    /// 题目信息表
    /// </summary>
    [Table("EO_QuestionInfo")]
    public class QuestionInfo
    {
        //题目Id
        [Key]
        public Guid Question_Id { get; set; }
        //题目所属科目Id
        public Guid? Question_Subject_Id { get; set; }
        public string Question_Subject { get; set; }
        public string Question_Author { get; set; }
        //题目题型
        public string Question_Topic { get; set; }
        public string Question_Title { get; set; }
        public string Question_Answer { get; set; }
        public string Question_Explain { get; set; }
        //出题时间
        public DateTime? Question_Time { get; set; }
        //题目点击量
        public long Question_Click { get; set; }
        public string Question_Grade { get; set; }
        public string Question_Grade_Son { get; set; }
        public string Question_Grade_Grandson { get; set; }
        //试题状态0是无效1是正常
        public bool Question_State { get; set; }
        

    }
}