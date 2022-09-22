using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForQuizApp.Models;

namespace WebApiForQuizApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        db_QUIZEntities db = new db_QUIZEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Login");
        }

        public JsonResult LoginWithAjax(string username,string password)
        {
            tbl_User user = db.tbl_User.Where(x => x.userLoginName.ToLower().Equals(username.ToLower()) && x.userPassword.Equals(password)).SingleOrDefault();

            if(user == null)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["user"] = user;
                return Json("1", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Index()
        {
            if (Session["user"]==null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        // for testing

        //[HttpGet]
        //public ActionResult filterExam(int id)
        //{
        //    TBL_QUESTION ques = db.TBL_QUESTION.Where(x => x.Question_exam_id == id).SingleOrDefault();
            
        //    return View(ques);
        //}

        public ActionResult Exam()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public JsonResult GetExam()
        {
            db.Configuration.ProxyCreationEnabled = false;
            tbl_User user = (tbl_User)Session["user"];
            if (user != null)
            {
                try
                {
                   List<TBL_EXAM> exam = db.TBL_EXAM.Where(x => x.exam_CreatedBy == user.userid).ToList();
                    return Json(exam,JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {

                    return Json("0", JsonRequestBehavior.AllowGet);
                }

            }
            return Json("0", JsonRequestBehavior.AllowGet);

        }

      
        public JsonResult changeStatus(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                TBL_EXAM ex = db.TBL_EXAM.Where(x => x.exam_id == id).SingleOrDefault();
                ex.exam_Status = !ex.exam_Status;
                db.SaveChanges();

                return Json("Status Updated", JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                
            }


            return Json("Status failed to Update", JsonRequestBehavior.AllowGet);

        }

        
        public JsonResult AddEditExam(TBL_EXAM Data)
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                TBL_EXAM exam = null;
                if (Data.exam_id == 0)
                { 
                    tbl_User user = (tbl_User)Session["user"];
                    
                    exam = new TBL_EXAM();
                    exam.exam_Name = Data.exam_Name;
                    exam.exam_Status = true;
                    exam.exam_CreatedBy = Convert.ToInt32(user.userid);
                    exam.exam_AppearCode = Utility.RandomString(6); //System.Guid.NewGuid().ToString();
                    db.TBL_EXAM.Add(exam);
                    db.SaveChanges();
                    return Json("Exam Added Successfully", JsonRequestBehavior.AllowGet);

                }
                else
                {
                    exam = db.TBL_EXAM.Where(x=>x.exam_id==Data.exam_id).SingleOrDefault();
                    exam.exam_Name = Data.exam_Name;
                    
                    
                    db.SaveChanges();
                    return Json("Exam Updated Successfully", JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception)
            {


            }


            return Json("Status Failed to Perform Operation", JsonRequestBehavior.AllowGet);

        }

        public ActionResult Questions()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }


        public JsonResult AddQuestions (QuestionViewModel question)
            {
            bool success = true;
            string msg = "";

            TBL_QUESTION q = new TBL_QUESTION();
            try
            {
                
                q.Question_Option1 = question.option1;
                q.Question_Option2 = question.option2;
                q.Question_Option3 = question.option3;
                q.Question_Option4 = question.option4;
                q.Question_Text    = question.text;
                q.Question_type    = question.type;
                q.Question_Option5 = question.answer;
                q.Question_exam_id = question.examId;

                db.TBL_QUESTION.Add(q);
                db.SaveChanges();

                question.id = q.Question_id;
                msg = "Question Added Successfully";

            }
            catch (Exception)
            {
                success = false;
                msg = "failed to Add Data";
                
            }

            return Json(new { success = success, msg = msg,data= question }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetQuestions(int id)
        {
            bool success = true;
            string msg = "";

            List<QuestionViewModel> obj = new List<QuestionViewModel>();

            try
            {
             List<TBL_QUESTION> li = db.TBL_QUESTION.Where(x => x.Question_exam_id == id).ToList();

                foreach (var item in li)
                {
                    QuestionViewModel qvm = new QuestionViewModel();
                    qvm.id      = item.Question_id;
                    qvm.text    = item.Question_Text;
                    qvm.option1 = item.Question_Option1;
                    qvm.option2 = item.Question_Option2;
                    qvm.option3 = item.Question_Option3;
                    qvm.option4 = item.Question_Option4;
                    qvm.answer  = item.Question_Option5;
                    qvm.type    = (short) item.Question_type;

                    obj.Add(qvm);

                }


                msg = "Question Fetched Successfully";

            }
            catch (Exception)
            {
                success = false;
                msg = "failed to Add Data";

            }

            return Json(new { success = success, msg = msg , data = obj }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult user()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult reports()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}