using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cards.Models
{
    public class Card
    {
        public int CardId { get; set; }

        [Required(ErrorMessage ="Front is required.")]
        [MaxLength(100, ErrorMessage = "Front must not exceed 100 characters" )]
        public string Front { get; set; }

        [Required(ErrorMessage = "Back is required.")]
        [MaxLength(100, ErrorMessage = "Back must not exceed 100 characters")]
        public string Back { get; set; }

        [MaxLength(100, ErrorMessage = "Hint must not exceed 100 characters")]
        public string Hint { get; set; }

        public Set Set { get; set; }
        public int SetId { get; set; }       
    }
}