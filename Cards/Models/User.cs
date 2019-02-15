using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.Models
{
    public class User : IdentityUser
    {
        public List<Set> Sets = new List<Set>();
        //Favourite sets
    }
}