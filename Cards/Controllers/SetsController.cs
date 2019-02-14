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
        private SetRepository _setRepository;
        private CardRepository _cardRepository;

        public SetsController(SetRepository setRepository, 
                            CardRepository cardRepository,
                            Context context)
            :base(context)
        {
            _setRepository = setRepository;
            _cardRepository = cardRepository;
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
            var viewModel = new AddSetViewModel();
            return View(viewModel);
        }
        //To do: Only logged in people can add
        //To do: Added set should be associated with user

        /// <summary>
        /// Add a set (post)
        /// </summary> //-- 
        [HttpPost]
        public ActionResult AddSet(AddSetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var set = new Set();
                set = viewModel.Set;
                _setRepository.Add(set);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        //To do: Only logged in people can add


        /// <summary>
        /// Gets a set ~/sets/showset/1 
        /// </summary>
        public ActionResult ShowSet(int? setId)
        {
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
            var set = _setRepository.Get(setId);
            return View(set);
        }
        //To do: Only user can delete set

        [HttpPost]
        [ActionName("DeleteSet")]
        public ActionResult DeleteSetPost(int setId)
        {
            if (ModelState.IsValid)
            {
               _setRepository.Delete(setId);
               return RedirectToAction("Index");
            }
            return View("Error");
        }
        //To do: Only owner can delete set

        /// <summary>
        /// Edit a set ~/sets/{setid}/edit
        /// </summary>
        public ActionResult EditSet(int? setId)
        {
            var set = _setRepository.Get(setId);
            var viewModel = new EditSetViewModel
            {
                Set = set
            };
            return View(viewModel);
        }
        //To do: Only owner can edit set

        /// <summary>
        /// Edit a set (post)
        /// </summary>
        [HttpPost]                          
        public ActionResult EditSet(EditSetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var set = viewModel.Set;
                _setRepository.Edit(set);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        } 
        //To do: Only owner can edit set

        /// <summary>
        /// Add card to set (get) ~/sets/addcard/{setId}
        /// </summary>
        public ActionResult AddCard(int setId)
        {
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
        //To do: Only owner can add card to set

        /// <summary>
        /// Edit card in set ~/sets/{setid}/{cardid}/edit
        /// </summary>
        public ActionResult EditCard(int setId, int cardId)
        {
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
            if (ModelState.IsValid)
            {
                var card = new Card();
                card = viewModel.Card;
                _cardRepository.Add(card);
                return RedirectToAction("ShowSet", new { SetId = card.SetId });
            }
            return View(viewModel);
        }
        //To do: Only owner of set can edit card

        /// <summary>
        /// Delete card in set ~/sets/{setid}/{cardid}/delete
        /// </summary>
        public ActionResult DeleteCard(int setId, int cardId)
        {
            var card = _cardRepository.Get(setId, cardId);
            return View(card);
        }
        //To do: Only owner of set can delete card

        [HttpPost, ActionName("DeleteCard")]
        public ActionResult DeleteCardPost(int setId, int cardId)
        {
            if (ModelState.IsValid)
            {
                _cardRepository.Delete(setId, cardId);
                return RedirectToAction("ShowSet", new { SetId = setId });
            }
            return View("Error");
        }
        //To do: Only owner of set can delete card
    }
}