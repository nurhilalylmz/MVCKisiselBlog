using Blog.BLL.Validation;
using Blog.Entity.Entities;
using Blog.Repository.Repository.Abstract;
using Blog.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Areas.Admin.Controllers
{
    public class MakaleController : BaseController
    {
        public MakaleController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        // GET: Admin/Makale
        public ActionResult List()
        {
            var model = _unitOfWork.GetRepo<Makale>().GetAll();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Add(Makale model)
        {
            var validator = new MakaleValidator().Validate(model);

            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Makale>().Add(model);
                bool IsSuccess = _unitOfWork.Commit();
                ViewBag.IsSuccess = IsSuccess;
                ViewBag.Message = IsSuccess ? "Başarılı" : "Tekrar Deneyiniz";
            }

            validator.Errors.ToList().ForEach(a =>
            {
                ModelState.AddModelError(a.PropertyName, a.ErrorMessage);
            });

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            _unitOfWork.GetRepo<Makale>().Delete(id);
            bool isSuccess = _unitOfWork.Commit();

            TempData["Message"] = isSuccess ? "Başarılı" : "Silme işlemini tekrar deneyiniz";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var model = _unitOfWork.GetRepo<Makale>().GetObject(x => x.MakaleId == id);
           
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit(Makale model)
        {
            var validator = new MakaleValidator().Validate(model);

            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Makale>().Update(model);
                bool IsSuccess = _unitOfWork.Commit();

                ViewBag.IsSuccess = IsSuccess;
                ViewBag.Message = IsSuccess ? "Güncelleme Başarılı" : "Tekrar Deneyiniz";
            }


            return RedirectToAction("List");

        }
    }
}