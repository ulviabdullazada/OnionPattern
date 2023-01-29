using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheckpoint.Application.ViewModels;
using TheCheckpoint.Domain.Entities;

namespace TheCheckpoint.Application.Validators
{
    public class ProductCreateVMValidator:AbstractValidator<ProductCreateVM>
    {
        public ProductCreateVMValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Zəhmət olmasa xananı doldurun.")
                .MinimumLength(3)
                .MaximumLength(200)
                    .WithMessage("Məhsul adı 3-200 simvoldan ibarət olmalıdır");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Zəhmət olmasa xananı doldurun.")
                .Must(s => s >= 0)
                    .WithMessage("Qiymət 0dan böyük olmalıdır.");
            RuleFor(p => p.StockCount)
                .NotNull()
                    .WithMessage("Zəhmət olmasa xananı doldurun.")
                .Must(s => s >= 0)
                    .WithMessage("Stok sayı 0dan böyük olmalıdır.");
            RuleFor(p => p.Discount)
                .NotNull()
                    .WithMessage("Zəhmət olmasa xananı doldurun.")
                .Must(s => s >= 0 && s <= 100)
                    .WithMessage("Endirim faizi 0 ilə 100 arasında olmalıdır olmalıdır.");

        }
    }
}
