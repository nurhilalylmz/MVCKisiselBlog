using Blog.DAL.EntityFrameWork.Context;
using Blog.Entity.Entities;
using Blog.Repository.Repository.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Validation
{
    public class KategoriValidator : AbstractValidator<Kategori>
    {
        private readonly IUnitOfWork _unitOfWork;
        public KategoriValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.KategoriAdi).NotEmpty().WithMessage("Kategori adı girmelisiniz!");
            RuleFor(x => x.KategoriAdi).Must(SameIsNotExist).WithMessage("Zaten aynı kategori adı mevcut!");
            RuleFor(x => x.KategoriAdi).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");
            RuleFor(x => x.Aciklama).MaximumLength(50).WithMessage("Açıklama alanı en fazla 50 karakter olabilir.");
        }
        public bool SameIsNotExist(string ad)
        {
            using (BlogDbContext context = new BlogDbContext())
            {
                return !context.Kategori.Any(x => x.KategoriAdi == ad);
            }
        }
    }





}
