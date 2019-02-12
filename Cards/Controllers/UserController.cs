using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cards.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index() 
        {
            return View(); //Redirect to profile or sign in           
        }

        //Sign in [get]
        public ActionResult SignUp()
        {
            return View();
        }        
        
        //Sign in [post]
        public ActionResult SignUpPost()
        {
            return View();
        }

        [HttpPost, ActionName("SignIn")]
        public ActionResult SignIn()
        {
            return View();
        }

        //Signup
        public ActionResult SignInPost()
        {
            return View();
        }

        //Your profile
        public ActionResult ViewProfile(int id)
        {
            //List 
            return View();
        }

    }
}