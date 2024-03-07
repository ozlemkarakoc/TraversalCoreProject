using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUdValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUdValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu Alanına En Az 5 Karakter Giriniz.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu Alanına En Fazla 100 Karakter Giriniz.");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Mail Alanına En Az 5 Karakter Giriniz.");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Mail Alanına En Fazla 100 Karakter Giriniz.");
        }
    }
}
