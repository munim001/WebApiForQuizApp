using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiForQuizApp.Models;

namespace WebApiForQuizApp.Controllers
{
    public enum QuestionType
    {
        MultpleChoice,SingleChoice
    }

    public class QuestionController : ApiController
    {
        List<QuestionViewModel> li = new List<QuestionViewModel>();

        List<TBL_QUESTION> question = null;

        db_QUIZEntities db = new db_QUIZEntities();

        public QuestionController()
        {
                   
        }


        [HttpGet]
        public HttpResponseMessage Get(long id)
        {
           question = db.TBL_QUESTION.Where(x => x.Question_exam_id == id).ToList();
            foreach (var item in question)
            {
                QuestionViewModel qvm = new QuestionViewModel();
                qvm.id = item.Question_id;
                qvm.text = item.Question_Text;
                qvm.option1 = item.Question_Option1;
                qvm.option2 = item.Question_Option2;
                qvm.option3 = item.Question_Option3;
                qvm.option4 = item.Question_Option4;

                li.Add(qvm);

            }
            
            return Request.CreateResponse(HttpStatusCode.OK, li);
        }

        [HttpPost]
        public HttpResponseMessage Post(List<Answers> answers)
        {
            int score = 0;
            foreach (var item in answers)
            {
               string ans = db.TBL_QUESTION.Where(x => x.Question_id == item.id).SingleOrDefault().Question_Option5;
                if (ans.ToLower().Equals(item.answer.ToLower()))
                {
                    score++;
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, score);
        }


        [HttpGet]
        public HttpResponseMessage GetAll(long id)
        {
            question = db.TBL_QUESTION.Where(x => x.Question_exam_id == id).ToList();
            foreach (var item in question)
            {
                QuestionViewModel qvm = new QuestionViewModel();
                qvm.id      = item.Question_id;
                qvm.text    = item.Question_Text;
                qvm.option1 = item.Question_Option1;
                qvm.option2 = item.Question_Option2;
                qvm.option3 = item.Question_Option3;
                qvm.option4 = item.Question_Option4;
                qvm.answer  = item.Question_Option5;

                li.Add(qvm);

            }

            return Request.CreateResponse(HttpStatusCode.OK, li);
        }

    }
}
