using Cards.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cards.Data
{
    public class SubjectRepository
    {
        Context _context;

        public SubjectRepository(Context context)
        {
            _context = context;
        }

        //Add - when first set with subject is added
        //Remove - when no sets remain
        //No edit

        //Get all
        public IList<Subject> GetAll()
        {
            return _context.Subjects
                .OrderBy(s => s.Name)
                .Include(s => s.Sets)
                .ToList();
        }
        //Get 

        public Subject Get(int? subjectId)
        {
            return _context.Subjects
                .Include(s => s.Sets)
                .SingleOrDefault(s => s.SubjectId == subjectId);
        }

    }

}