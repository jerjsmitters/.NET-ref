using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cards.Models;

namespace Cards.ViewModels
{
    public class IndexSubjectViewModel
    {
        public IList<Subject> Subjects { get; set; }
    }
}