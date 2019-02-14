using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime Date { get; private set; }
        
        [Required(ErrorMessage = "Set name is required.")]
        [MaxLength(50, ErrorMessage = "Set name must not exceed 50 characters")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Description must not exceed 250 characters.")]
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
        //To do: public User User { get; set; }
    }
}