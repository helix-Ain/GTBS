using GTBS.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GTBS.Data
{
    public class EODB : DbContext
    {
        public DbSet<SubjectInfo> subjectinfo { get; set; }
        public DbSet<QuestionInfo> questioninfo { get; set; }
        public DbSet<PaperInfo> paperinfo { get; set; }
        public EODB()
            : base("connstr")
        { }
    }
}