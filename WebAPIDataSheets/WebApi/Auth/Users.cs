using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Auth
{
    public class Users:Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        //public Users(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}

        public Users()
        {

        }
               
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public async Task<bool> ValidateLoginAsync(string username, string password)
        {
            var result = await SignInManager.PasswordSignInAsync(username, password, true, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return true;
                case SignInStatus.LockedOut:
                    return false;
                case SignInStatus.RequiresVerification:
                    return false;
                case SignInStatus.Failure:
                    return false;
                default:
                    return false;
            }
        }
    }
}