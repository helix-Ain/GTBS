using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GTBS.Data.Domain
{
    /// <summary>
    /// 题目学科分类信息表
    /// </summary>
    [Table("EO_SubjectInfo")]
    public class SubjectInfo
    {
        //学科的Id主键
        [Key]
        public Guid Subject_Id { get; set; }
        //学科名字(英语,数学等)
        public string Subject_Name { get; set; }
        //学科状态0是无效1是正常
        public bool Subject_State { get; set; }
    }
}