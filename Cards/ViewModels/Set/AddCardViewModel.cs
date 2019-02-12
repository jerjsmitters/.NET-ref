using Cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.ViewModels
{
    public class AddCardViewModel
    {
        public Card Card { get; set; } = new Card();
    }
}