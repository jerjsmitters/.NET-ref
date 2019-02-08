using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.Models
{
    public class Set
    {
        public Set()
        {
            Date = DateTime.Now;
        }
        public int SetId { get; set; }
        public DateTime Date { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }



        //public List<Subject> Subjects { get; set; }
        //public List<Card> Cards { get; set; }
        //User
    }
}