using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public string Hint { get; set; }

        //public Set Set { get; set; }
    }
}