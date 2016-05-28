using GTBS.Data;
using GTBS.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTBS.Controllers
{
    public class BGController : Controller
    {
        //
        // GET: /BG/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SetVolumeOnline(CLoadTest cl)
        {
            ViewBag.Period = string.IsNullOrEmpty(cl.Period) ? "小学试题" : cl.Period;
            ViewBag.Grade = string.IsNullOrEmpty(cl.Grade)?"一年级":cl.Grade;
            ViewBag.Grade_Son = string.IsNullOrEmpty(cl.Grade_Son)?"全部":cl.Grade_Son;
            ViewBag.Grade_Grandson = string.IsNullOrEmpty(cl.Grade_Grandson)?"全部":cl.Grade_Grandson;
            ViewBag.Subject = string.IsNullOrEmpty(cl.Subject)?"语文":cl.Subject;
            ViewBag.Topic = string.IsNullOrEmpty(cl.Topic)?"全部":cl.Topic;
            return View();
        }
        public ActionResult TestLibrary(CLoadTest cl)
        {
            ViewBag.Grade = string.IsNullOrEmpty(cl.Grade) ? "全部" : cl.Grade;
            ViewBag.Subject = string.IsNullOrEmpty(cl.Subject) ? "全部" : cl.Subject;
            ViewBag.Topic = string.IsNullOrEmpty(cl.Topic) ? "全部" : cl.Topic;
            return View();

        }
        public ActionResult PaperLibrary(CLoadPaper cl)
        {
            ViewBag.Grade = string.IsNullOrEmpty(cl.Grade) ? "全部" : cl.Grade;
            ViewBag.Subject = string.IsNullOrEmpty(cl.Subject) ? "全部" : cl.Subject;
            ViewBag.Year = string.IsNullOrEmpty(cl.Year) ? "全部" : cl.Year;
            ViewBag.Kind = string.IsNullOrEmpty(cl.Kind) ? "全部" : cl.Kind;
            ViewBag.Years = DateTime.Now.Year;
            return View();

        }
        public ActionResult Extension(CExtension ce)
        {
            ViewBag.Type = string.IsNullOrEmpty(ce.Type) ? "新建试题" : ce.Type;
            ViewBag.Tip = ce.Tip;
            ViewBag.Years = DateTime.Now.Year;
            ViewBag.Period = ce.Period;
            ViewBag.Subject = ce.Subject;
            ViewBag.Topic = ce.Topic;
            ViewBag.Grade = ce.Grade;
            ViewBag.Grade_Son = ce.Grade_Son;
            ViewBag.Grade_Grandson = ce.Grade_Grandson;
            return View();
        }
        //新建试题
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewTest(CNewTest cn)
        {

            EODB eodb = new EODB();
            QuestionInfo qi = new QuestionInfo
            {
                Question_Id = Guid.NewGuid(),
                Question_Subject = cn.Subject,
                Question_Topic = cn.Topic,
                Question_Title = cn.Title,
                Question_Answer = cn.Answer,
                Question_Explain = cn.Explain,
                Question_Grade = cn.Grade,
                Question_Grade_Son = cn.Grade_Son,
                Question_Grade_Grandson = cn.Grade_Grandson,
                Question_State = true,
                Question_Click = 0,
                Question_Time = DateTime.Now
            };
            eodb.questioninfo.Add(qi);
            eodb.SaveChanges();
            return Content("success");
        }
        public ActionResult UpLoad()
        {
            try
            {
                HttpPostedFileBase file = Request.Files["File"];
                Guid Paper_Id = Guid.NewGuid();
                PaperInfo paperinfo = new PaperInfo
                {
                    Paper_Id = Paper_Id,
                    Paper_Subject = Request["Subject_upload"],
                    Paper_Grade = Request["Grade_upload"],
                    Paper_Kind = Request["Kind"],
                    Paper_Province = Request["Province"],
                    Paper_Year = Request["Year"],
                    Paper_Author = Request["Author"],
                    Paper_Time = DateTime.Now,
                    Paper_Download = 0,
                    Paper_State = true,
                    Paper_Name = file.FileName,
                    Paper_Path = "/medium/paper/" + Paper_Id.ToString() + ".docx"
                };
                file.SaveAs(Server.MapPath("~/medium/paper/" + Paper_Id.ToString() + ".docx"));
                EODB eodb = new EODB();
                eodb.paperinfo.Add(paperinfo);
                eodb.SaveChanges();
                return RedirectToAction("Extension", new { Type = "上传试卷", Tip = "success" });

            }
            catch
            {
                return RedirectToAction("Extension", new { Type = "新建试题", Tip = "error" });
            }


        }

        public ActionResult LoadTest(CLoadTest cl)
        {
            EODB eodb = new EODB();
            List<QuestionInfo> questioninfo = new List<QuestionInfo>();
            questioninfo = (from i in eodb.questioninfo
                            where (i.Question_Grade == ((cl.Grade == "全部") ? i.Question_Grade : cl.Grade)) && (i.Question_Subject == ((cl.Subject == "全部") ? i.Question_Subject : cl.Subject)) && (i.Question_Topic == ((cl.Topic == "全部") ? i.Question_Topic : cl.Topic))
                            select i).ToList<QuestionInfo>();
            return Json(questioninfo);

        }
        public ActionResult LoadTest_SetVolume(CLoadTest cl)
        {
            EODB eodb = new EODB();
            List<QuestionInfo> questioninfo = new List<QuestionInfo>();
            questioninfo = (from i in eodb.questioninfo
                            where (i.Question_Grade == ((cl.Grade == "全部") ? i.Question_Grade : cl.Grade)) &&(i.Question_Grade_Son==((cl.Grade_Son=="全部")?i.Question_Grade_Son:cl.Grade_Son))&&(i.Question_Grade_Grandson==((cl.Grade_Grandson=="全部")?i.Question_Grade_Grandson:cl.Grade_Grandson))&& (i.Question_Subject == ((cl.Subject == "全部") ? i.Question_Subject : cl.Subject)) && (i.Question_Topic == ((cl.Topic == "全部") ? i.Question_Topic : cl.Topic))
                            select i).ToList<QuestionInfo>();
            return Json(questioninfo);
        }
        public ActionResult LoadPaper(CLoadPaper cl)
        {
            EODB eodb = new EODB();
            List<PaperInfo> paperinfo = new List<PaperInfo>();
            paperinfo = (from i in eodb.paperinfo
                         where (i.Paper_Grade == ((cl.Grade == "全部") ? i.Paper_Grade : cl.Grade)) && (i.Paper_Subject == ((cl.Subject == "全部") ? i.Paper_Subject : cl.Subject)) && (i.Paper_Year == ((cl.Year == "全部") ? i.Paper_Year : cl.Year)) && (i.Paper_Kind == ((cl.Kind == "全部") ? i.Paper_Kind : cl.Kind))
                         select i).ToList<PaperInfo>();
            return Json(paperinfo);

        }

        //增加组卷试题,同时返回组卷试题数目
        public ActionResult AddVolume(Guid? Question_Id)
        {
            HttpCookie cookie = Request.Cookies["Volume"];
            if (cookie != null)
            {
                if (Question_Id != null)
                {
                    cookie.Values.Add(Question_Id.ToString(),Question_Id.ToString());
                    Response.AppendCookie(cookie);
                    return Content(cookie.Values.Count.ToString());
                }
                else
                {
                    Response.AppendCookie(cookie);
                    return Content(cookie.Values.Count.ToString());
                }
            }
            else
            {
                HttpCookie newCookie = new HttpCookie("Volume");
                if (Question_Id != null)
                {
                    newCookie.Values.Add(Question_Id.ToString(),Question_Id.ToString());
                    Response.AppendCookie(newCookie);
                    return Content(newCookie.Values.Count.ToString());
                }
                else
                {
                    return Content("0");
                }
            }
        }
        public ActionResult Clear()
        {
            HttpCookie cookie = Request.Cookies["Volume"];
            if (cookie != null)
            {
                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cookie.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在
                Response.AppendCookie(cookie);
                return Content("success");            }
            else {
                return Content("failure");
            }
            
        }
        public ActionResult deleteTest(Guid Question_Id)
        {
            try
            {
                EODB eodb = new EODB();
                QuestionInfo questioninfo = eodb.questioninfo.Find(Question_Id);
                eodb.questioninfo.Remove(questioninfo);
                eodb.SaveChanges();
                return Content("success");
            }
            catch {
                return Content("error");
            }
        }
        public ActionResult deletePaper(Guid Paper_Id)
        {
            try
            {
                EODB eodb = new EODB();
                PaperInfo paperinfo = eodb.paperinfo.Find(Paper_Id);
                eodb.paperinfo.Remove(paperinfo);
                eodb.SaveChanges();
                return Content("success");
            }
            catch {
                return Content("error");
            }
        }

    }
    public class CExtension
    {
        public string Type { get; set; }
        public string Tip { get; set; }
        //以下试题用
        public string Period { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public string Grade { get; set; }
        public string Grade_Son { get; set; }
        public string Grade_Grandson { get; set; }
        public CExtension()
        {
            Tip = "default";
            Period = "小学试题";
            Subject = "语文";
            Topic = "单选题";
        }

    }
    public class CNewTest
    {
        public string Subject { get; set; }
        public string Topic { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
        public string Explain { get; set; }
        public string Grade { get; set; }
        public string Grade_Son { get; set; }
        public string Grade_Grandson { get; set; }
    }

}
