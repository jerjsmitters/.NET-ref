using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.Models
{
    public class Set
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public List<Card> Cards { get; set; }
        //User
    }
}