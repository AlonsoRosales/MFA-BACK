using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.UseCases.Applications.Commands.CreateApplication
{
    public class CreateApplicationCommandValidator : AbstractValidator<CreateApplicationCommand>
    {
        public CreateApplicationCommandValidator()
        {
            RuleFor(n => n.createApplicationDTO.nombre)
                .NotNull().WithMessage("El nombre es requerido")
                .NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(s => s.createApplicationDTO.status)
                .NotNull().WithMessage("El status es requerido")
                .Must(s => s == '0' || s == '1').WithMessage("El status debe ser 0 o 1");
            RuleFor(i => i.createApplicationDTO.ipRanges)
                .NotNull().WithMessage("Los ipRanges son requeridos");
        }
    }
}
