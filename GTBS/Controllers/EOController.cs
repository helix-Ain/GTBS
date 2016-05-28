using GTBS.Data;
using GTBS.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTBS.Controllers
{
    public class EOController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PrimaryTest()
        {
            ViewBag.Title = "小学试题";
            ViewBag.Subject = "语文";
            ViewBag.Topic = "全部";
            ViewBag.Grade = "一年级";
            return View("Test");
        }
        public ActionResult JuniorTest()
        {
            ViewBag.Title = "初中试题";
            ViewBag.Subject = "语文";
            ViewBag.Topic = "全部";
            ViewBag.Grade = "七年级";
            return View("Test");
        }
        public ActionResult HighTest()
        {
            ViewBag.Title = "高中试题";
            ViewBag.Subject = "语文";
            ViewBag.Topic = "全部";
            ViewBag.Grade = "十年级";
            return View("Test");
        }
        public ActionResult PrimaryExamPaper()
        {
            ViewBag.Title = "小学试卷";
            ViewBag.Subject = "语文";
            ViewBag.Grade = "全部";
            ViewBag.Year = "全部";
            ViewBag.Kind = "全部";
            ViewBag.Province = "全部";
            ViewBag.Years = DateTime.Now.Year;
            return View("Paper");
        }
        public ActionResult JuniorExamPaper()
        {
            ViewBag.Title = "初中试卷";
            ViewBag.Subject = "语文";
            ViewBag.Grade = "全部";
            ViewBag.Year = "全部";
            ViewBag.Kind = "全部";
            ViewBag.Province = "全部";
            ViewBag.Years = DateTime.Now.Year;
            return View("Paper");
        }
        public ActionResult HighExamPaper()
        {
            ViewBag.Title = "高中试卷";
            ViewBag.Subject = "语文";
            ViewBag.Grade = "全部";
            ViewBag.Year = "全部";
            ViewBag.Kind = "全部";
            ViewBag.Province = "全部";
            ViewBag.Years = DateTime.Now.Year;
            return View("Paper");
        }
        public ActionResult Navigation(CNavigation cn)
        {
            if (cn.Title.Substring(2, 2) == "试题")
            {
                ViewBag.Title = cn.Title;
                ViewBag.Subject = cn.Subject;
                ViewBag.Topic = string.IsNullOrEmpty(cn.Topic) ? "全部" : cn.Topic;
                if (cn.Title == "小学试题")
                {
                    ViewBag.Grade = string.IsNullOrEmpty(cn.Grade) ? "一年级" : cn.Grade;
                }
                else if (cn.Title == "初中试题")
                {
                    ViewBag.Grade = string.IsNullOrEmpty(cn.Grade) ? "七年级" : cn.Grade;
                }
                else
                {
                    ViewBag.Grade = string.IsNullOrEmpty(cn.Grade) ? "十年级" : cn.Grade;
                }
                ViewBag.Grade_Son = cn.Grade_Son;
                ViewBag.Grade_Grandson = cn.Grade_Grandson;
                return View("Test");
            }
            else
            {
                ViewBag.Title = cn.Title;
                ViewBag.Subject = cn.Subject;
                ViewBag.Grade = cn.Grade;
                ViewBag.Year = string.IsNullOrEmpty(cn.Year) ? "全部" : cn.Year;
                ViewBag.Kind = string.IsNullOrEmpty(cn.Kind) ? "全部" : cn.Kind;
                ViewBag.Province = string.IsNullOrEmpty(cn.Province) ? "全部" : cn.Province;
                ViewBag.Years = DateTime.Now.Year;
                return View("Paper");
            }
        }
        public ActionResult LoadTest(CLoadTest cl)
        {
            int level = 0;
            if (!string.IsNullOrEmpty(cl.Grade_Son)) level++;
            if (!string.IsNullOrEmpty(cl.Grade_Grandson)) level++;
            EODB eodb = new EODB();
            List<QuestionInfo> t = new List<QuestionInfo>(); ;
            if (cl.Topic != "全部")
            {
                switch (level)
                {
                    case 0:
                        t = (from i in eodb.questioninfo
                             where (i.Question_Subject == cl.Subject) && (i.Question_Topic == cl.Topic) && (i.Question_Grade == cl.Grade) && (i.Question_State == true)
                             select i).ToList<QuestionInfo>();
                        break;
                    case 1:
                        t = (from i in eodb.questioninfo
                             where (i.Question_Subject == cl.Subject) && (i.Question_Topic == cl.Topic) && (i.Question_Grade == cl.Grade) && (i.Question_Grade_Son == cl.Grade_Son) && (i.Question_State == true)
                             select i).ToList<QuestionInfo>();
                        break;
                    case 2:
                        t = (from i in eodb.questioninfo
                             where (i.Question_Subject == cl.Subject) && (i.Question_Topic == cl.Topic) && (i.Question_Grade == cl.Grade) && (i.Question_Grade_Son == cl.Grade_Son) && (i.Question_Grade_Grandson == cl.Grade_Grandson) && (i.Question_State == true)
                             select i).ToList<QuestionInfo>();
                        break;
                }
            }
            else
            {
                switch (level)
                {
                    case 0:
                        t = (from i in eodb.questioninfo
                             where (i.Question_Subject == cl.Subject) && (i.Question_Grade == cl.Grade) && (i.Question_State == true)
                             select i).ToList<QuestionInfo>();
                        break;
                    case 1:
                        t = (from i in eodb.questioninfo
                             where (i.Question_Subject == cl.Subject) && (i.Question_Grade == cl.Grade) && (i.Question_Grade_Son == cl.Grade_Son) && (i.Question_State == true)
                             select i).ToList<QuestionInfo>();
                        break;
                    case 2:
                        t = (from i in eodb.questioninfo
                             where (i.Question_Subject == cl.Subject) && (i.Question_Grade == cl.Grade) && (i.Question_Grade_Son == cl.Grade_Son) && (i.Question_Grade_Grandson == cl.Grade_Grandson) && (i.Question_State == true)
                             select i).ToList<QuestionInfo>();
                        break;
                }
            }
            return Json(t);
        }
        public ActionResult LoadPaper(CLoadPaper cl)
        {
            EODB eodb = new EODB();
            List<PaperInfo> paperinfo = new List<PaperInfo>();
            if (cl.Title == "小学试卷")
            {
                if (cl.Grade == "全部")
                {
                    paperinfo = (from i in eodb.paperinfo
                                 where (i.Paper_Grade == "一年级" || i.Paper_Grade == "二年级" || i.Paper_Grade == "三年级" || i.Paper_Grade == "四年级" || i.Paper_Grade == "五年级" || i.Paper_Grade == "六年级") &&
                                 (i.Paper_Year == ((cl.Year == "全部" ? i.Paper_Year : (cl.Year)))) &&
                                 (i.Paper_Kind == ((cl.Kind == "全部") ? i.Paper_Kind : cl.Kind)) &&
                                 (i.Paper_Province == ((cl.Province == "全部" ? i.Paper_Province : cl.Province))) &&
                                 (i.Paper_Subject == cl.Subject)
                                 select i).ToList<PaperInfo>();
                }
                else
                {
                    paperinfo = (from i in eodb.paperinfo
                                 where (i.Paper_Grade == cl.Grade) &&
                                 (i.Paper_Year == ((cl.Year == "全部" ? i.Paper_Year : (cl.Year)))) &&
                                 (i.Paper_Kind == ((cl.Kind == "全部") ? i.Paper_Kind : cl.Kind)) &&
                                 (i.Paper_Province == ((cl.Province == "全部" ? i.Paper_Province : cl.Province))) &&
                                 (i.Paper_Subject == cl.Subject)
                                 select i).ToList<PaperInfo>();

                }
            }
            else if (cl.Title == "初中试卷")
            {
                if (cl.Grade == "全部")
                {
                    paperinfo = (from i in eodb.paperinfo
                                 where (i.Paper_Grade == "七年级" || i.Paper_Grade == "八年级" || i.Paper_Grade == "九年级") &&
                                 (i.Paper_Year == ((cl.Year == "全部" ? i.Paper_Year : (cl.Year)))) &&
                                 (i.Paper_Kind == ((cl.Kind == "全部") ? i.Paper_Kind : cl.Kind)) &&
                                 (i.Paper_Province == ((cl.Province == "全部" ? i.Paper_Province : cl.Province))) &&
                                 (i.Paper_Subject == cl.Subject)
                                 select i).ToList<PaperInfo>();
                }
                else
                {
                    paperinfo = (from i in eodb.paperinfo
                                 where (i.Paper_Grade == cl.Grade) &&
                                 (i.Paper_Year == ((cl.Year == "全部" ? i.Paper_Year : (cl.Year)))) &&
                                 (i.Paper_Kind == ((cl.Kind == "全部") ? i.Paper_Kind : cl.Kind)) &&
                                 (i.Paper_Province == ((cl.Province == "全部" ? i.Paper_Province : cl.Province))) &&
                                 (i.Paper_Subject == cl.Subject)
                                 select i).ToList<PaperInfo>();

                }
            }
            else
            {
                if (cl.Grade == "全部")
                {
                    paperinfo = (from i in eodb.paperinfo
                                 where (i.Paper_Grade == "十年级" || i.Paper_Grade == "十一年级" || i.Paper_Grade == "十二年级") &&
                                 (i.Paper_Year == ((cl.Year == "全部" ? i.Paper_Year : (cl.Year)))) &&
                                 (i.Paper_Kind == ((cl.Kind == "全部") ? i.Paper_Kind : cl.Kind)) &&
                                 (i.Paper_Province == ((cl.Province == "全部" ? i.Paper_Province : cl.Province))) &&
                                 (i.Paper_Subject == cl.Subject)
                                 select i).ToList<PaperInfo>();
                }
                else
                {
                    paperinfo = (from i in eodb.paperinfo
                                 where (i.Paper_Grade == cl.Grade) &&
                                 (i.Paper_Year == ((cl.Year == "全部" ? i.Paper_Year : (cl.Year)))) &&
                                 (i.Paper_Kind == ((cl.Kind == "全部") ? i.Paper_Kind : cl.Kind)) &&
                                 (i.Paper_Province == ((cl.Province == "全部" ? i.Paper_Province : cl.Province))) &&
                                 (i.Paper_Subject == cl.Subject)
                                 select i).ToList<PaperInfo>();

                }

            }
            return Json(paperinfo);
        }
    }
    public class CNavigation
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public string Grade { get; set; }
        public string Grade_Son { get; set; }
        public string Grade_Grandson { get; set; }
        public string Year { get; set; }
        public string Kind { get; set; }
        public string Province { get; set; }

    }
    public class CLoadTest
    {
        public string Subject { get; set; }
        public string Topic { get; set; }
        public string Grade { get; set; }
        public string Grade_Son { get; set; }
        public string Grade_Grandson { get; set; }
        public string Period { get; set; }
    }
    public class CLoadPaper
    {
        public string Title { get; set; }
        public string Grade { get; set; }
        public string Year { get; set; }
        public string Kind { get; set; }
        public string Province { get; set; }
        public string Subject { get; set; }
    }

}
