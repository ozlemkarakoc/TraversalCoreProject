﻿using DTOLayer.DTOs.AnnouncomentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDto>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyiniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen duyuru içeriği boş geçmeyiniz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
        }
    }
}
