using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key]
        public int SetId { get; set; }
        public DateTime Date { get; private set; }
        
        [Required(ErrorMessage = "Set name is required.")]
        [MaxLength(80, ErrorMessage = "Set name must not exceed 80 characters")]
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

        public User User { get; set; }
        public string UserId { get; set; }
        //UsersFavourite
    }
}