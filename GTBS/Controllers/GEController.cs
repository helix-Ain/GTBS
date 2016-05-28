using GTBS.Data;
using GTBS.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Words;
using System.Web;
using System.Web.Mvc;
using GTBS.Models;

namespace GTBS.Controllers
{
    public class GEController : Controller
    {
        //
        // GET: /GE/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Explain(Guid Question_Id)
        {
            EODB eodb = new EODB();
            QuestionInfo qi = eodb.questioninfo.Find(Question_Id);
            if (qi.Question_Title.Length > 20)
            {
                ViewBag.Title = qi.Question_Title.Substring(0, 20).Replace("<p>",string.Empty).Replace("</p>",string.Empty);
            }
            else {
                ViewBag.Title = qi.Question_Title.Replace("<p>",string.Empty).Replace("</p>",string.Empty);
            }
            ViewBag.QuestionInfo = qi;
            qi.Question_Click++;
            eodb.SaveChanges();
            PaperInfo Related = eodb.paperinfo.Where(i => i.Paper_Grade == qi.Question_Grade && i.Paper_Subject == qi.Question_Subject).FirstOrDefault();
            if (Related == null)
            {
                ViewBag.Related = new PaperInfo
                {
                    Paper_Id = Guid.NewGuid(),
                    Paper_Name = "无",
                    Paper_Path = "#"
                };
            }
            else
            {
                ViewBag.Related = Related;
            }
            return View();
        }
        public ActionResult AddDownloadNum(Guid Paper_Id)
        {
            EODB eodb = new EODB();
            PaperInfo paperinfo = eodb.paperinfo.Find(Paper_Id);
            paperinfo.Paper_Download++;
            eodb.SaveChanges();
            return new EmptyResult();
        }
        public ActionResult PopularDownload()
        {
            EODB eodb = new EODB();
            List<PaperInfo> t = (from i in eodb.paperinfo
                                 orderby i.Paper_Download descending
                                 select i).ToList<PaperInfo>();
            List<PaperInfo> paperinfo = new List<PaperInfo>();
            if (t.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    paperinfo.Add(t[i]);
                }
            }
            else
            {
                for (int i = 0; i < t.Count; i++)
                {
                    paperinfo.Add(t[i]);
                }
            }
            return Json(paperinfo);

        }
        public ActionResult LatestPaper()
        {
            EODB eodb = new EODB();
            List<PaperInfo> t = (from i in eodb.paperinfo
                                 orderby i.Paper_Time descending
                                 select i).ToList<PaperInfo>();
            List<PaperInfo> paperinfo = new List<PaperInfo>();
            if (t.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    paperinfo.Add(t[i]);
                }
            }
            else
            {
                for (int i = 0; i < t.Count; i++)
                {
                    paperinfo.Add(t[i]);
                }
            }
            return Json(paperinfo);
        }
        public ActionResult Preview(Guid Paper_Id)
        {
            string path = Server.MapPath("~/medium/paper/" + Paper_Id.ToString() + ".docx");
            Document doc = new Document(path);
            doc.Save(Server.MapPath("~/medium/preview/" + Paper_Id.ToString() + ".html"), SaveFormat.HtmlFixed);
            return Content("/medium/preview/" + Paper_Id.ToString() + ".html");
        }
        public ActionResult TestSearch(CSearch cs)
        {
            ViewBag.Title = "搜索试题:" + cs.Key;
            ViewBag.Type = cs.Type;
            ViewBag.Key = cs.Key;
            ViewBag.Grade = string.IsNullOrEmpty(cs.Grade) ? "全部" : cs.Grade;
            ViewBag.Subject = string.IsNullOrEmpty(cs.Subject) ? "全部" : cs.Subject;
            ViewBag.Topic = string.IsNullOrEmpty(cs.Topic) ? "全部" : cs.Topic;
            return View();
        }
        public ActionResult PaperSearch(CSearch cs)
        {
            ViewBag.Title = "搜索试卷:" + cs.Key;
            ViewBag.Type = cs.Type;
            ViewBag.Key = cs.Key;
            ViewBag.Grade = string.IsNullOrEmpty(cs.Grade) ? "全部" : cs.Grade;
            ViewBag.Year = string.IsNullOrEmpty(cs.Year) ? "全部" : cs.Year;
            ViewBag.Kind = string.IsNullOrEmpty(cs.Kind) ? "全部" : cs.Kind;
            ViewBag.Province = string.IsNullOrEmpty(cs.Province) ? "全部" : cs.Province;
            ViewBag.Subject = string.IsNullOrEmpty(cs.Subject) ? "全部" : cs.Subject;
            ViewBag.Years = DateTime.Now.Year;
            return View();
        }
        public ActionResult Search(CSearch cs)
        {
            EODB eodb = new EODB();
            if (cs.Type == "试题")
            {
                List<QuestionInfo> questioninfo = new List<QuestionInfo>();
                questioninfo = (from i in eodb.questioninfo
                                where (i.Question_Title.Contains(cs.Key)) && (i.Question_Grade == ((cs.Grade == "全部") ? i.Question_Grade : cs.Grade)) && (i.Question_Subject == ((cs.Subject == "全部") ? i.Question_Subject : cs.Subject)) && (i.Question_Topic == ((cs.Topic == "全部") ? i.Question_Topic : cs.Topic))
                                select i).ToList<QuestionInfo>();
                return Json(questioninfo);
            }
            else
            {
                List<PaperInfo> paperinfo = new List<PaperInfo>();
                paperinfo = (from i in eodb.paperinfo
                             where (i.Paper_Grade == ((cs.Grade == "全部") ? i.Paper_Grade : cs.Grade)) && (i.Paper_Year == ((cs.Year == "全部") ? i.Paper_Year : cs.Year)) && (i.Paper_Kind == ((cs.Kind == "全部") ? i.Paper_Kind : cs.Kind)) && (i.Paper_Province == ((cs.Province == "全部") ? i.Paper_Province : cs.Province)) && (i.Paper_Subject == ((cs.Subject == "全部") ? i.Paper_Subject : cs.Subject)) && (i.Paper_Name.Contains(cs.Key))
                             select i).ToList<PaperInfo>();
                return Json(paperinfo);
            }
        }
        public ActionResult StatisticsPaperNumber(string Title)
        {
            EODB eodb = new EODB();
            List<int> Num = new List<int>();
            if (Title == "小学试卷")
            {
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "一年级") || (i.Paper_Grade == "二年级") || (i.Paper_Grade == "三年级") || (i.Paper_Grade == "四年级") || (i.Paper_Grade == "五年级") || (i.Paper_Grade == "六年级")) && (i.Paper_Subject == "语文")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "一年级") || (i.Paper_Grade == "二年级") || (i.Paper_Grade == "三年级") || (i.Paper_Grade == "四年级") || (i.Paper_Grade == "五年级") || (i.Paper_Grade == "六年级")) && (i.Paper_Subject == "数学")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "一年级") || (i.Paper_Grade == "二年级") || (i.Paper_Grade == "三年级") || (i.Paper_Grade == "四年级") || (i.Paper_Grade == "五年级") || (i.Paper_Grade == "六年级")) && (i.Paper_Subject == "英语")));
            }
            else if (Title == "初中试卷")
            {
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "语文")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "数学")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "英语")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "物理")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "化学")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "历史")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "政治思品")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "地理")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "七年级") || (i.Paper_Grade == "八年级") || (i.Paper_Grade == "九年级")) && (i.Paper_Subject == "生物")));

            }
            else if (Title == "高中试卷")
            {
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "语文")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "数学")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "英语")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "物理")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "化学")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "历史")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "政治思品")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "地理")));
                Num.Add(eodb.paperinfo.Count(i => ((i.Paper_Grade == "十年级") || (i.Paper_Grade == "十一年级") || (i.Paper_Grade == "十二年级")) && (i.Paper_Subject == "生物")));
            }
            else
            {
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "语文"));
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "数学"));
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "英语"));
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "物理"));
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "化学"));
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "历史"));
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "政治思品"));
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "地理"));
                Num.Add(eodb.paperinfo.Count(i => i.Paper_Subject == "生物"));
            }
            return Json(Num);
        }
        public ActionResult StatisticsPaperAllNumber()
        {
            EODB eodb = new EODB();
            long Num = eodb.paperinfo.Count();
            return Content(Num.ToString());
        }

        public ActionResult Download(Guid Question_Id)
        {
            EODB eodb = new EODB();
            QuestionInfo qi = eodb.questioninfo.Where(i => i.Question_Id == Question_Id).FirstOrDefault();
            Document docx = new Document(Server.MapPath("~/medium/template/template.docx"));
            DocumentBuilder docxdb = new DocumentBuilder(docx);
            docxdb.InsertHtml("<span style='font-size:small;'>" + (string.IsNullOrEmpty(qi.Question_Title)?string.Empty:qi.Question_Title.Replace("src=\"","src=\"http://localhost")) + "<br/><br/>" + (string.IsNullOrEmpty(qi.Question_Answer)?string.Empty:qi.Question_Answer.Replace("src=\"", "src=\"http://localhost")) + "<br/><br/>" + (string.IsNullOrEmpty(qi.Question_Explain)?string.Empty:qi.Question_Explain.Replace("src=\"", "src=\"http://localhost")) + "</span>");
            docx.Save(Server.MapPath("~/medium/test/" + qi.Question_Id.ToString() + ".docx"), SaveFormat.Docx);
            return Content("/medium/test/" + qi.Question_Id.ToString() + ".docx");

        }
        public ActionResult DownloadPaper(Guid Paper_Id)
        {
            EODB eodb = new EODB();
            PaperInfo paper = eodb.paperinfo.Find(Paper_Id);
            return Content(paper.Paper_Path);
        }
        /// <summary>
        /// 试卷详情
        /// </summary>
        /// <returns></returns>
        public ActionResult PaperDetails()
        {
            return View();
        }
        public ActionResult LoadTestByCookie()
        {
            HttpCookie cookie = Request.Cookies["Volume"];
            List<QuestionInfo> questioninfo = new List<QuestionInfo>();
            EODB eodb = new EODB();
            for(int i=0;i<cookie.Values.Count;i++)
            {
                Guid guid = new Guid(cookie.Values.Keys[i]);
                QuestionInfo qi = eodb.questioninfo.Find(guid);
                questioninfo.Add(qi);
            }
            Response.AppendCookie(cookie);
            return Json(questioninfo); 

        }
        public ActionResult RemoveTestCookie(Guid Question_Id)
        {
            string result = string.Empty;
            try
            {
                HttpCookie cookie = Request.Cookies["Volume"];
                cookie.Values.Remove(Question_Id.ToString());
                Response.AppendCookie(cookie);
                result = "success";
            }
            catch {
                result = "error";
            }
            return Content(result);
        }
        public ActionResult TestDetailed(Guid Question_Id)
        {
            EODB eodb = new EODB();
            QuestionInfo questioninfo = eodb.questioninfo.Find(Question_Id);
            return Json(questioninfo);
        }
        public ActionResult GeneratingPaper(VolumeParameter vp)
        {
            Document docx = new Document(Server.MapPath("~/medium/template/template.docx"));
            DocumentBuilder docxdb = new DocumentBuilder(docx);
            EODB eodb = new EODB();
            QuestionInfo qi = new QuestionInfo();
            int Num=0;
            foreach (Guid i in vp.Question_Id)
            {
                Num++;
                qi = eodb.questioninfo.Find(i);
                docxdb.InsertHtml("<span style='font-size:small;'>" +"<label>"+Num.ToString()+"、&nbsp;</label>"+ (string.IsNullOrEmpty(qi.Question_Title)?string.Empty : qi.Question_Title.Replace("src=\"", "src=\"http://localhost") + "<br/><br/></span>"));
            }
            Guid guid = Guid.NewGuid();
            docx.Save(Server.MapPath("~/medium/paper/" + guid.ToString() + ".docx"));
            PaperInfo paperinfo = new PaperInfo
            {
                Paper_Id=guid,
                Paper_Name=vp.Paper_Name,
                Paper_Author=vp.Paper_Author,
                Paper_Grade=vp.Paper_Grade,
                Paper_Subject=vp.Paper_Subject,
                Paper_Kind=vp.Paper_Kind,
                Paper_Province=vp.Paper_Province,
                Paper_State=true,
                Paper_Time=DateTime.Now,
                Paper_Download=0,
                Paper_Path= "/medium/paper/" + guid.ToString() + ".docx"
            };
            eodb.paperinfo.Add(paperinfo);
            eodb.SaveChanges();
            return Content(guid.ToString());
        }
    }
    public class CSearch
    {
        public string Type { get; set; }
        public string Key { get; set; }
        public string Grade { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public string Year { get; set; }
        public string Kind { get; set; }
        public string Province { get; set; }
    }
}
