# GTBS

###概述

GTBS是一个在线试题管理系统，覆盖小学，初中和高中的所有年级，科目，上下册和单元章节分类等，提供了在线试题搜索，试卷试题下载等功能，同时提供了在线组卷功能，组卷人能以购物车的方式帅选题目生成试卷并
下载

### 目录结构
    ├── Content                    #前端资源目录
    ├── App_Start                  #放置配置文件代码
    │       ├── FilterConfig.cs       #注册外部/全局过滤器，这些过滤器可以被应用到每个Action和Controller中去
    │       ├── RouteConfig.cs        #配置MVC应用程序的系统路由路径
    │       └── WebApiConfig.cs       #配置api路由信息
    │ 
    ├── Controllers                #控制器文件夹
    │       ├── EOController.cs
    │       ├── BGController.cs
    │       └── GEController.cs
    │
    ├── Views                      #视图文件夹 
    │       ├── EO
    │       ├── BG
    │       ├── BG
    │       └── Shared       #布局视图文件夹
    │   
    ├── Models               #视图模型文件夹
    │ 
    │ 
    ├── Data                  #ORM文件夹
    │       ├── Domain        #映射域                  
    │       └── EODB.cs       #对象关系映射文件
    │   
    ├── web.config            #web配置文件
    │ 
    └──Global.asax      #全局文件 
    
    
    
    
### ORM

Entity框架的全称是ADO.NET Entity Framework，是微软开发的基于ADO.NET的ORM（Object/ Relational Mapping）框架。该框架的主要特点： 

支持多种数据库（Microsoft SQL Server、Oracle和DB2等）；
强劲的映射引擎，能很好地支持存储过程；
提供Visual Studio集成工具，进行可视化操作；
能够与ASP.NET、WPF、WCF、WCF Data Services进行很好的集成。



###Aspose.Words for .NET

```C#
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
```

