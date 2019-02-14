using Cards.Data;
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
        private SubjectRepository _subjectRepository;

        public SubjectsController(SubjectRepository subjectRepository, Context context)
            : base(context)
        {
            _subjectRepository = subjectRepository;
        }
        /// <summary>
        /// List all subjects
        /// </summary>
        public ActionResult Index()
        {
            var viewModel = new IndexSubjectViewModel()
            {
                Subjects = _subjectRepository.GetAll()
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
                Subject = _subjectRepository.Get(subjectId)
            };

            return View(viewModel);
        }
    }  
}