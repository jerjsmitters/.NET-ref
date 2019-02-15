using Cards.Data;
using Cards.Models;
using Cards.Security;
using Cards.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cards.Controllers
{
    public class UserController : BaseController
    {
        private readonly ApplicationUserManager _userManager = null;
        private readonly ApplicationSignInManager _signInManager = null;
        private readonly IAuthenticationManager _authenticationManager = null;

        public UserController(ApplicationUserManager userManager,
                            ApplicationSignInManager signInManager,
                            IAuthenticationManager authenticationManager,
                            Context context, SetRepository setRepository, 
                            CardRepository cardRepository, SubjectRepository subjectRepository) 
            : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
        }

        /// <summary>
        /// Returns either profile or sign-in
        /// </summary>
        public ActionResult Index() 
        {
            return View(); //Redirect to profile or sign in           
        }

        /// <summary>
        /// Page for registering 
        /// </summary>
        public ActionResult Register()
        {
            var viewModel = new RegisterViewModel();
            return View(viewModel);
        }

        /// <summary>
        /// POST of register form
        /// </summary>
        [HttpPost]
        [ActionName("Register")]
        public async Task<ActionResult> RegisterPost(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Sets");
                };

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View(viewModel);
        }

        
        public ActionResult SignIn()
        {
            var viewModel = new SignInViewModel();
            return View(viewModel);
        }

        [HttpPost, ActionName("SignIn")]
        public async Task<ActionResult> SignInPost(SignInViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(
                viewModel.UserName, viewModel.Password, viewModel.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Sets");
                case SignInStatus.Failure:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(viewModel);
                case SignInStatus.LockedOut:
                case SignInStatus.RequiresVerification:
                    throw new NotImplementedException("Identity feature not implemented.");
                default:
                    throw new Exception("Unexpected Microsoft.AspNet.Identity.Owin.SignInStatus enum value: " + result);
            }
        }

        [HttpPost]
        public ActionResult SignOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Sets");
        }

        //Your profile
        public ActionResult ViewProfile(int id)
        {
            //Username, sets, favourite sets
            return View();
        }
    }
}