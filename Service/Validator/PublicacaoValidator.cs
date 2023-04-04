using Domain.Entities;
using FluentValidation;

namespace Service.Validator
{
    public class PublicacaoValidator : AbstractValidator<Publicacao>
    {
        public PublicacaoValidator()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Por favor preencha a Descricao.")
                .NotNull().WithMessage("Por favor preencha a Descricao.");

            RuleFor(c => c.Area)
                .NotEmpty().WithMessage("Por favor preencha a Area.")
                .NotNull().WithMessage("Por favor preencha a Area.");

            RuleFor(c => c.DataPublicacao)
                .NotEmpty().WithMessage("Por favor preencha a DataPublicacao.")
                .NotNull().WithMessage("Por favor preencha a DataPublicacao.");

            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("Por favor preencha o Titulo.")
                .NotNull().WithMessage("Por favor preencha o Titulo.");

            RuleFor(c => c.Autor)
                .NotEmpty().WithMessage("Por favor preencha o Autor.")
                .NotNull().WithMessage("Por favor preencha o Autor.");
        }
    }
}