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
            var viewModel = new IndexSetViewModel
            {
                Sets = SetRepository.GetAll()
            };
            return View(viewModel);
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

            SetRepository.Add(set);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets a set ~/sets/showset/1 
        /// </summary>
        public ActionResult ShowSet(int? setId)
        {
            var set = SetRepository.Get(setId);
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
            var set = SetRepository.Get(setId);
            return View(set);
        }

        [HttpPost]
        [ActionName("DeleteSet")]
        public ActionResult DeleteSetPost(int setId)
        {
            SetRepository.Delete(setId);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edit a set ~/sets/{setid}/edit
        /// </summary>
        public ActionResult EditSet(int? setId)
        {
            var set = SetRepository.Get(setId);
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
            if (ModelState.IsValid)
            {
                var set = viewModel.Set;
                SetRepository.Edit(set);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        } 


        /// <summary>
        /// Add card to set (get) ~/sets/addcard/{setId}
        /// </summary>
        public ActionResult AddCard(int setId)
        {
            var viewModel = new AddCardViewModel();
            viewModel.Card.SetId = setId;
            return View(viewModel);
        }


        /// <summary>
        /// Add card to set (post)
        /// </summary>
        [HttpPost]
        public ActionResult AddCard(AddCardViewModel viewModel)
        {
            var card = new Card();
            card = viewModel.Card;
            card.Set = SetRepository.Get(card.SetId);

            CardRepository.Add(card);
            return RedirectToAction("ShowSet", new { setId = card.SetId });
        }


        /// <summary>
        /// Edit card in set ~/sets/{setid}/{cardid}/edit
        /// </summary>
        public ActionResult EditCard(int setId, int cardId)
        {
            var viewModel = new EditCardViewModel()
            {
                Card = CardRepository.Get(setId, cardId)
            };
            return View(viewModel);
        }
       

        /// <summary>
        /// Edit card in set (post)
        /// </summary>
        [HttpPost]
        public ActionResult EditCard(EditCardViewModel viewModel)
        {
            var card = new Card();
            card = viewModel.Card;
            CardRepository.Add(card);
            return RedirectToAction("ShowSet", new { SetId = card.SetId });
        }

        /// <summary>
        /// Delete card in set ~/sets/{setid}/{cardid}/delete
        /// </summary>
        public ActionResult DeleteCard(int setId, int cardId)
        {
            var card = CardRepository.Get(setId, cardId);
            return View(card);
        }

        [HttpPost, ActionName("DeleteCard")]
        public ActionResult DeleteCardPost(int setId, int cardId)
        {
            CardRepository.Delete(setId, cardId);
            return RedirectToAction("ShowSet", new { SetId = setId });
        }
    }
}