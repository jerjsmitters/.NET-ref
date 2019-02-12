using Cards.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cards.Data
{
    public class CardRepository
    {
        Context _context;
        public CardRepository(Context context)
        {
            _context = context;
        }

        public IList<Card> GetAll()
        {
            return _context.Cards
                .OrderBy(c => c.CardId)
                .ToList();
            //                
        }

        public IList<Card> GetAllInSet(int setId)
        {
            return _context.Cards
                .Where(c => c.SetId == setId)
                .OrderBy(c => c.CardId)
                .ToList();
        }

        public Card Get(int setId, int cardId)
        {
            var set = _context.Sets.Include(s => s.Cards).SingleOrDefault(s => s.SetId == setId);
            return set.Cards.SingleOrDefault(c => c.CardId == cardId);
        }

        public void Add(Card card)
        {
            _context.Cards.Add(card);
            _context.SaveChanges();
        }

        public void Edit(Card card) 
        {
            var setEntry = _context.Entry(card);
            setEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int setId, int cardId)
        {
            Card card = _context.Cards.Find(cardId);
            _context.Cards.Remove(card);
            _context.SaveChanges();
        }
    }
}