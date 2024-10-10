using IMS.Application.Interfaces;
using IMS.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static IMS.Application.Features.Account.AccountManagementModels;

namespace InventoryManagementSystem.Controllers.AccountEndponits
{
    public class AccountController : Controller
    {
        private readonly IAuthServices auth;

        public AccountController(IAuthServices auth)
        {
            this.auth = auth;
        }


        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterRequest registerVM)
        {


            if (ModelState.IsValid)
            {
                var result = await auth.RegisterAsync(registerVM);

                if (result.IsAuthenticed)
                    return RedirectToAction("Login");
                else
                    ModelState.AddModelError("", result.Message);
            }

            return View(registerVM);
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginRequest loginVM)
        {
            if (ModelState.IsValid)
            {
                var res = await auth.LoginAsync(loginVM);
                if (res.IsAuthenticed)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ModelState.AddModelError("", res.Message);

                }

            }
            return View(loginVM);
        }

        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("Login");
        //}
        //#region ForgetPassword
        //public async Task<IActionResult> ForgetPassword()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ForgetPassword(ForgetPasswordByEmailVM model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var user = await userManager.FindByEmailAsync(model.Email);


        //        if (user != null)
        //        {
        //            var token = await userManager.GeneratePasswordResetTokenAsync(user);

        //            var passwordResetLink = Url.Action("ResetPassword", "Account", new { model.Email, Token = token }, protocol: Request.Scheme);

        //            await mailingRep.SendingMail(model.Email, "Confirm Reset Password", $"Please reset your password by clicking here: {passwordResetLink}");

        //            return RedirectToAction("ConfirmSendMAil");
        //        }
        //    }

        //    return View(model);

        //}
        //// after send Mail Show already The Mail Was sent.
        //public IActionResult ConfirmSendMAil()
        //{

        //    return View();
        //}

        //public async Task<IActionResult> ResetPassword(string Email, string Token)
        //{
        //    if (Email == null || Token == null)
        //    {
        //        ModelState.AddModelError("", "Not Found the Email in Website");
        //    }

        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> ResetPassword(ResetPasswordVM reset)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByEmailAsync(reset.Email);

        //        if (user != null)
        //        {
        //            var result = await userManager.ResetPasswordAsync(user, reset.Token, reset.Password);

        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("ConfirmResetPassword");
        //            }

        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }

        //            return View(reset);
        //        }

        //        return RedirectToAction("ResetPassword");
        //    }

        //    return View(reset);
        //}
        //public IActionResult ConfirmResetPassword()
        //{

        //    return View();
        //}


        //#endregion


    }
}
