using Cards.Data;
using Cards.Models;
using Cards.Security;
using Cards.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cards.Controllers
{
    public class SetsController : BaseController
    {
        private SetRepository _setRepository;
        private CardRepository _cardRepository;
        private SubjectRepository _subjectRepository;
        private readonly ApplicationUserManager _userManager = null;

        public SetsController(ApplicationUserManager userManager,
                            SetRepository setRepository, 
                            CardRepository cardRepository,
                            SubjectRepository subjectRepository,
                            Context context)
            :base(context)
        {
            _setRepository = setRepository;
            _cardRepository = cardRepository;
            _userManager = userManager;
            _subjectRepository = subjectRepository;
        }

        /// <summary>
        /// Gets list of all sets ~/sets/
        /// </summary>
        public ActionResult Index()
        {
            var viewModel = new IndexSetViewModel
            {
                Sets = _setRepository.GetAll()
            };
            return View(viewModel);
        }
        

        /// <summary>
        /// Add a set (get) ~/sets/add
        /// </summary> 
        public ActionResult AddSet()
        {
            //Check to see if user is logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }

            var viewModel = new AddSetViewModel();
            return View(viewModel);
        }
        
        

        /// <summary>
        /// Add a set (post)
        /// </summary> //-- 
        [HttpPost]
        public ActionResult AddSet(AddSetViewModel viewModel)
        {
            //Double check to see if a user is logged in
            if (!User.Identity.IsAuthenticated)
            {
               return RedirectToAction("SignIn", "User");
            }
            
            //Form validation
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            //Create set to upload to db
            var set = new Set();
            set = viewModel.Set;

            //Check to see if subject already exists
            var subject = (_subjectRepository.DoesSubjectExist(set.Subject.Name)) ? _subjectRepository.GetByName(set.Subject.Name) : set.Subject;
            set.Subject = subject;

            //Attach user to set
            var userId = User.Identity.GetUserId();
            set.UserId = userId;
            set.User = _userManager.FindById(userId);

            _setRepository.Add(set);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets a set ~/sets/showset/1 
        /// </summary>
        public ActionResult ShowSet(int? setId)
        {
            if (setId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var set = _setRepository.Get(setId);
            var viewModel = new ShowSetViewModel
            {
                Set = set
            };
            return View(viewModel);
        }


        /// <summary>
        /// Deletes a set ~/sets/setid/deleteset
        /// </summary> 
        public ActionResult DeleteSet(int? setId)
        {
            if (setId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Check to see if user is logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");               
            }

            //Check to see if user is the owner
            var set = _setRepository.Get(setId);
            var userId = User.Identity.GetUserId();
            if (set.UserId != userId)
            {
                return HttpNotFound();
            }

            ViewBag.Set = set;

            return View();
        }

        [HttpPost]
        [ActionName("DeleteSet")]
        public ActionResult DeleteSetPost(int setId)
        {
            //Double check to see if user is logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }

            //Double check to see if user is the owner
            var userId = User.Identity.GetUserId();
            if (!_setRepository.EntryOwnedByUser(setId, userId))
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            
            _setRepository.Delete(setId);
            return RedirectToAction("Index");
            
        }
        //To do: Only owner can delete set

        /// <summary>
        /// Edit a set ~/sets/{setid}/edit
        /// </summary>
        public ActionResult EditSet(int? setId)
        {
            if (setId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Check if user is signed in before editing
            if (!User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("SignIn", "User");
            }

            //Check if user is the owner before editing
            var userId = User.Identity.GetUserId();           
            var set = _setRepository.Get(setId);
            if(!_setRepository.EntryOwnedByUser(set.SetId, set.UserId)) 
            {
                return HttpNotFound();
            }

            var viewModel = new EditSetViewModel
            {
                Set = set
            };
            return View(viewModel);
        }

        /// <summary>
        /// Edit a set (post)
        /// </summary>
        [HttpPost]                          
        public ActionResult EditSet(EditSetViewModel viewModel)
        {
            //Double check to see if user is authenticated
            if (!User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("SignIn", "User");
            }

            //Create set to upload to db            
            var set = viewModel.Set;
            viewModel.Set.User = _userManager.FindById(set.UserId); 

            var userId = User.Identity.GetUserId();

            //Double check to see user is the owner before posting
            if (!_setRepository.EntryOwnedByUser(set.SetId, userId)) 
            {
                return HttpNotFound();
            }

            //Validate set
            if (!ModelState.IsValid)
            {             
                 return View(viewModel);
            }

            //Check to see if subject already exists
            var subject = (_subjectRepository.DoesSubjectExist(set.Subject.Name)) ? _subjectRepository.GetByName(set.Subject.Name) : set.Subject;
            set.Subject = subject;

            _setRepository.Edit(set);
            return RedirectToAction("Index");
        } 

        /// <summary>
        /// Add card to set (get) ~/sets/addcard/{setId}
        /// </summary>
        public ActionResult AddCard(int setId)
        {
            //Check to see if user is authenticated
            if (!User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("SignIn", "User");
            }

            //Check to see if user is set owner
            var userId = User.Identity.GetUserId();
            if(!_setRepository.EntryOwnedByUser(setId, userId))
            {
                return HttpNotFound();
            }

            var viewModel = new AddCardViewModel();
            viewModel.Card.SetId = setId;
            return View(viewModel);
        }
        //To do: Only owner can add card to set

        /// <summary>
        /// Add card to set (post)
        /// </summary>
        [HttpPost]
        public ActionResult AddCard(AddCardViewModel viewModel)
        {
            //Double check to see if user is logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }

            //Double check to see if user is set owner
            var userId = User.Identity.GetUserId();
            if (!_setRepository.EntryOwnedByUser(viewModel.Card.SetId, userId))
            {
                return HttpNotFound();
            }

            //Form validation
            if (ModelState.IsValid)
            {
                var card = new Card();
                card = viewModel.Card;
                card.Set = _setRepository.Get(card.SetId);
                _cardRepository.Add(card);
                return RedirectToAction("ShowSet", new { setId = card.SetId });
            }
            return View(viewModel);
        }

        /// <summary>
        /// Edit card in set ~/sets/{setid}/{cardid}/edit
        /// </summary>
        public ActionResult EditCard(int setId, int cardId)
        {
            //Check to see if user logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }

            //Check to see if user is set owner
            var userId = User.Identity.GetUserId();
            if (!_setRepository.EntryOwnedByUser(setId, userId))
            {
                return HttpNotFound();
            }

            var viewModel = new EditCardViewModel()
            {
                Card = _cardRepository.Get(setId, cardId)
            };
            return View(viewModel);
        }
        //To do: Only owner of set can edit card

        /// <summary>
        /// Edit card in set (post)
        /// </summary>
        [HttpPost]
        public ActionResult EditCard(EditCardViewModel viewModel)
        {
            //Double Check to see if user logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }

            //Double Check to see if user is set owner
            var userId = User.Identity.GetUserId();
            if (!_setRepository.EntryOwnedByUser(viewModel.Card.SetId, userId))
            {
                return HttpNotFound();
            }
           
            if (ModelState.IsValid)
            {
                var card = new Card();
                card = viewModel.Card;
                _cardRepository.Add(card);
                return RedirectToAction("ShowSet", new { SetId = card.SetId });
            }
            return View(viewModel);
        }

        /// <summary>
        /// Delete card in set ~/sets/{setid}/{cardid}/delete
        /// </summary>
        public ActionResult DeleteCard(int setId, int cardId)
        {
            //Check to see if user logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }

            //Check to see if user is set owner
            var userId = User.Identity.GetUserId();
            if (!_setRepository.EntryOwnedByUser(setId, userId))
            {
                return HttpNotFound();
            }

            var card = _cardRepository.Get(setId, cardId);
            return View(card);
        }


        [HttpPost, ActionName("DeleteCard")]
        public ActionResult DeleteCardPost(int setId, int cardId)
        {
            //Double check to see if user logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }

            //Double check to see if user is set owner
            var userId = User.Identity.GetUserId();
            if (!_setRepository.EntryOwnedByUser(setId, userId))
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                _cardRepository.Delete(setId, cardId);
                return RedirectToAction("ShowSet", new { SetId = setId });
            }
            return View("Error");
        }

    }
}