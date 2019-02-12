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

        public Subject Subject { get; set; } = new Subject();
        public List<Card> Cards { get; set; } = new List<Card>();
        public int CardCount
        {
            get
            {
                return Cards.Count;
            }
        }
        //User
    }
}