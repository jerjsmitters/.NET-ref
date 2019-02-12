using Cards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cards.Controllers
{
    public class SubjectsController : BaseController
    {
        /// <summary>
        /// List all subjects
        /// </summary>
        public ActionResult Index()
        {
            var viewModel = new IndexSubjectViewModel()
            {
                Subjects = SubjectRepository.GetAll()
            };

            return View(viewModel);
        }

        /// <summary>
        /// //Select a subject and view sets
        /// </summary>
        public ActionResult ShowSubject(int? subjectId)
        {
            var viewModel = new ShowSubjectViewModel()
            {
                Subject = SubjectRepository.Get(subjectId)
            };

            return View(viewModel);
        }
    }  
}