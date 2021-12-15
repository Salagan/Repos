using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using ZRdemoContracts.ModelsDTO;
using ZRWeb.HttpClients;

namespace ZRWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoachApi _coachApi;

        private readonly IStudentApi _studentApi;

        public AccountController()
        {
            this._coachApi = RestService.For<ICoachApi>("https://localhost:44301");
            this._studentApi = RestService.For<IStudentApi>("https://localhost:44301");
        }

        // GET: AccountController
        public ActionResult Login()
        {
            return this.View();
        }

        // POST: AccountController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginCoach(LoginModel model)
        {
            if (this.ModelState.IsValid)
            {
                var coach = await this._coachApi.FindCoachUserAsync(model.Email, model.Password);

                if (coach != null)
                {
                    await this.Authenticate(coach.Email, coach.Role);

                    return this.RedirectToAction("Index", "Home");
                }

                this.ModelState.AddModelError(string.Empty, "Wrong email or password");
            }

            return this.View(model);
        }

        public async Task<ActionResult> LoginStudent(LoginModel model)
        {
            if (this.ModelState.IsValid)
            {
                var student = await this._studentApi.FindStudentUserAsync(model.Email, model.Password);

                if (student != null)
                {
                    await this.Authenticate(student.Email, student.Role);

                    return this.RedirectToAction("Index", "Home");
                }

                this.ModelState.AddModelError(string.Empty, "Wrong email or password");
            }

            return this.View(model);
        }

        public ActionResult Register()
        {
            return this.View();
        }

        public async Task<ActionResult> RegisterStudent(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                var student = await this._studentApi.FindStudentUserAsync(model.Email, model.Password);

                if (student == null)
                {
                    await this._studentApi.AddStudent(new StudentDTO { Email = model.Email, Password = model.Password, Role = "user" });

                    await this.Authenticate(student.Email, student.Role);

                    return this.RedirectToAction("Index", "Home");
                }

                this.ModelState.AddModelError(string.Empty, "Wrong email or password");
            }

            return this.View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return this.RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(string email, string role)
        {
            // create claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
            };

            // create object ClaimsIdentity
            ClaimsIdentity id = new (claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            // install authetication cookies
            await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
