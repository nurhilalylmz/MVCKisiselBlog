using Blog.Repository.Repository.Abstract;
using Blog.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Areas.Admin.Controllers
{
   
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        // GET: Admin/Dashboard
        [OutputCache(Duration = 30)]
        public ActionResult Index()
        {
            //ViewBag.Kullanici = "Admin";
            return View();
        }
    }
}