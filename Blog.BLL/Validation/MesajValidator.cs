using Blog.Entity.Entities;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Validation
{
    public class MesajValidator : AbstractValidator<Mesaj>
    {
        public MesajValidator()
        {
            RuleFor(x => x.MesajMail).NotEmpty().WithMessage("Mail adresi girmelisiniz!");
            RuleFor(x => x.MesajKonu).NotEmpty().WithMessage("Konunuzu ya da adınızı girmelisiniz!");
            RuleFor(x => x.MesajIcerik).NotEmpty().WithMessage("Mesajınızı girmelisiniz!");
        }
    }
}