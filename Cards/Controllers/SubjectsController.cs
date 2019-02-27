using Cards.Data;
using Cards.Security;
using Cards.ViewModels;
using Microsoft.AspNet.Identity;
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
        private ApplicationUserManager _userManager;

        public SubjectsController(SubjectRepository subjectRepository, 
                                    Context context, 
                                    ApplicationUserManager userManager)
            : base(context)
        {
            _subjectRepository = subjectRepository;
            _userManager = userManager;
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
            //Populate sets with users to display
            foreach (var set in viewModel.Subject.Sets)
            {
                set.User = _userManager.FindById(set.UserId);
            }
            
            return View(viewModel);
        }
    }  
}