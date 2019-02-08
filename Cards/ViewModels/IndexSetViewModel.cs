using Cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.ViewModels
{
    public class IndexSetViewModel
    {
        public IList<Set> Sets;
        public int SetCount { get
            {
                return Sets.Count;
            }
        }

    }
}