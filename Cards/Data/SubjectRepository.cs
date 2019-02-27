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

        public void Add(Subject subject)
        {
             _context.Subjects.Add(subject);
        }

        public bool HasSubjChanged(Set set1, Set set2)
        {
            return set1.Subject.Name != set2.Subject.Name;
        }

        public bool DoesSubjectExist(string name)
        {
            var result = _context.Subjects
                .SingleOrDefault(s => s.Name == name);
            return result != null;
        }

        public Subject GetByName(string name)
        {
            return _context.Subjects
                .SingleOrDefault(s => s.Name == name);
        }
    }

}