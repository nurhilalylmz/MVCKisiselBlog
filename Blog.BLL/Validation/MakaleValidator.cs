using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Validation
{
    public class MakaleValidator : AbstractValidator<Makale>
    {
        public MakaleValidator()
        {
            RuleFor(x => x.Baslik).NotEmpty().WithMessage("Başlık yazmalısınız!");
            RuleFor(x => x.Icerik).NotEmpty().WithMessage("İçerik yazmalısınız!");
            RuleFor(x => x.Baslik).MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olmalıdır.");
        }
    }
}
