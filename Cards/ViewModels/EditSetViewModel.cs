using Cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.ViewModels
{
    public class EditSetViewModel
    {
        public Set Set { get; set; } = new Set();

        public int Id
        {
            get { return Set.SetId; }
            set { Set.SetId = value; }
        }
    }
}