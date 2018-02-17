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
    public class KullaniciValidator : AbstractValidator<Kullanici>
    {
       
        public KullaniciValidator()
        {
            
            RuleFor(x => x.Adi).NotEmpty().WithMessage("Adınızı girmek zorundasınız!");
            RuleFor(x => x.Soyadi).NotEmpty().WithMessage("Soyadınızı girmek zorundasınız!");
            RuleFor(x => x.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı adını oluşturmak zorundasınız!");
            RuleFor(x => x.Parola).NotEmpty().WithMessage("Parola oluşturmak zorundasınız!");
            RuleFor(x => x.MailAdres).NotEmpty().WithMessage("Mail adresinizi girmek zorundasınız!");
            RuleFor(x => x.Adi).MaximumLength(50).WithMessage("Adınız en fazla 50 karakter olabilir");
            RuleFor(x => x.Soyadi).MaximumLength(50).WithMessage("Soyadınız en fazla 50 karakter olabilir");
            RuleFor(x => x.KullaniciAdi).MaximumLength(50).WithMessage(" Kullanıcı adınız en fazla 50 karakter olabilir");
            RuleFor(x => x.KullaniciAdi).Must(SameIsNotExist).WithMessage("Aynı kullanıcı adı var!");
            RuleFor(x => x.Parola).MaximumLength(50).WithMessage("Parola en fazla 50 karakter olabilir");
            RuleFor(x => x.MailAdres).MaximumLength(50).WithMessage("Mail adresiniz en fazla 50 karakter olabilir");
            RuleFor(x => x.Aciklama).MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir");
        }
        public bool SameIsNotExist(string ad)
        {
            using (BlogDbContext context = new BlogDbContext())
            {
                return !context.Kullanici.Any(x => x.KullaniciAdi == ad);
            }
        }
    }
}