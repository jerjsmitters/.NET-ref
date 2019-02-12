using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public IList<Set> Sets { get; set; } = new List<Set>();
        public int SetCount { get
            {
                return Sets.Count;
            }
        }
    }
}