using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cards.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Set must be linked to a subject.")]
        [MaxLength(30, ErrorMessage = "Subject name can't exceed 30 characters.")]
        [DisplayName("Subject")]
        public string Name { get; set; }

        public IList<Set> Sets { get; set; } = new List<Set>();
        public int SetCount { get
            {
                return Sets.Count;
            }
        }
    }
}