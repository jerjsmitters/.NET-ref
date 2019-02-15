using Cards.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cards.Data
{
    public class SetRepository
    {
        private Context _context = null;

        public SetRepository(Context context)
        {
            _context = context;
        }

   
        public IList<Set> GetAll()
        {
            return _context.Sets
                .OrderBy(s => s.Date)
                .Include(s => s.Cards)
                .ToList();
        }

        public Set Get(int? setId)
        {
            return _context.Sets
                .Include(s => s.Cards)
                .SingleOrDefault(s => s.SetId == setId);
        }

        public void Add(Set set)
        {
            _context.Sets.Add(set);
            _context.SaveChanges();
        }

        public void Edit(Set set) //from vm
        {
            var setEntry = _context.Entry(set);
            setEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int setId)
        {
            Set set = _context.Sets.Find(setId);
            _context.Sets.Remove(set);
            _context.SaveChanges();
        }

        public bool EntryOwnedByUser(int setId, string userId)
        {
            return _context.Sets
             .Where(s => s.SetId == setId && s.UserId == userId)
             .Count() == 1;
        }
    }
}