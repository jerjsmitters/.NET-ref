using Cards.Data;
using Cards.Models;
using Cards.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cards.Controllers
{
    public class SetsController : BaseController
    {        
        /// <summary>
        /// Gets list of all sets ~/sets/
        /// </summary>
        public ActionResult Index()
        {
            ViewBag.Sets = Repository.GetAll();
            return View();
        }
        

        /// <summary>
        /// Add a set (get) ~/sets/add
        /// </summary> 
        public ActionResult AddSet()
        {
            var viewModel = new AddSetViewModel();
            return View(viewModel);
        }
        

        /// <summary>
        /// Add a set (post)
        /// </summary> //-- 
        [HttpPost]
        public ActionResult AddSet(AddSetViewModel viewModel)
        {
            var set = new Set();
            set = viewModel.Set;

            Repository.Add(set);

            return View(viewModel);
        }

        /// <summary>
        /// Gets a set ~/sets/showset/1 
        /// </summary>
        public ActionResult ShowSet(int? setId)
        {
            var set = Repository.Get(setId);
            return View();
        }

        /// <summary>
        /// Deletes a set ~/sets/setid/deleteset
        /// </summary> 
        public ActionResult DeleteSet(int? setId)
        {
            var set = Repository.Get(setId);
            return View(set);
        }

        [HttpPost]
        [ActionName("DeleteSet")]
        public ActionResult DeleteSetPost(int setId)
        {
            Repository.Delete(setId);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edit a set ~/sets/{setid}/edit
        /// </summary>
        public ActionResult EditSet(int? setId)
        {
            var set = Repository.Get(setId);
            var viewModel = new EditSetViewModel();
            viewModel.Set = set;
            return View(viewModel);
        }
        

        /// <summary>
        /// Edit a set (post)
        /// </summary>
        [HttpPost]
        public ActionResult EditSet(EditSetViewModel viewModel, int setId)
        {
            if (ModelState.IsValid)
            {
                var set = viewModel.Set;
                set.SetId = setId;
                Repository.Edit(set);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


        /// <summary>
        /// Add card to set (get) ~/sets/{setId}/add
        /// </summary>
        public ActionResult AddCard(int setId)
        {
            var modelView = new Card()
            {

            };

            return View(modelView);
        }


        /// <summary>
        /// Add card to set (post)
        /// </summary>
        [HttpPost]
        public ActionResult AddCard(Card viewModel)
        {
            return View();
        }


        /// <summary>
        /// Edit card in set ~/sets/{setid}/{cardid}/edit
        /// </summary>
        public ActionResult EditCard(int setId, int cardId)
        {
            var viewModel = new Card()
            {

            };
            return View();
        }
       

        /// <summary>
        /// Edit card in set (post)
        /// </summary>
        [HttpPost]
        public ActionResult EditCard() //addcardviewmodel
        {
            return View();
        }

        /// <summary>
        /// Delete card in set ~/sets/{setid}/{cardid}/delete
        /// </summary>
        public ActionResult DeleteCard(int setId, int cardId)
        {
            return View();
        }
        
    }
}