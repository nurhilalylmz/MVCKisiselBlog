using Blog.BLL.Services.Abstracts;
using Blog.Entity.Entities;
using Blog.Repository.Repository.Abstract;
using Blog.UI.Areas.Admin.Models;
using Blog.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.UI.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IEncryptor _encryptor;


        public AccountController(IUnitOfWork unitOfWork, IEncryptor encryptor) : base(unitOfWork)
        {
            _encryptor = encryptor;

        }

        // GET: Admin/Account
        public ActionResult Login()
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = _encryptor.Hash(model.Password);
                var kullanici = _unitOfWork.GetRepo<Kullanici>().Where(x => x.MailAdres == model.Email && x.Parola == model.Password).FirstOrDefault();


                if (kullanici != null)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.MailAdres, model.RememberMe);
                    _unitOfWork.Commit();
                    
                    return Redirect("/Admin/Home");
                }
                else
                {
                    ViewBag.FormResult = "Kullanıcı adı veya şifre hatalı";
                    return View();
                }
            }

            return View();
        }

     
        public RedirectResult LogOut()
        {
            FormsAuthentication.SignOut();

            return Redirect("/Admin/Account/Login");

        }
    }
}