using FluentValidation;

namespace FiapTechChallenge.API.Entity.Validators
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(x => x.NumeroConta).NotNull().NotEmpty().WithMessage("O número da conta é obrigatório");
            RuleFor(x => x.CPF)
                .NotNull()
                .NotEmpty()
                .WithMessage("O número da conta é obrigatório")
                .IsValidCPF()
                .WithMessage("O CPF informado não é válido");

            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O nome é obrigatório");
            RuleFor(x => x.NomeMae).NotNull().NotEmpty().WithMessage("O nome da mãe é obrigatório");
            RuleFor(x => x.Email).NotNull()
                .NotEmpty()
                .WithMessage("O número da conta é obrigatório")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("O e-mail informado não é válido");
            RuleFor(x => x.Renda)
                .NotNull()
                .NotEmpty()
                .WithMessage("A renda é obrigatório")
                .GreaterThan(0)
                .WithMessage("A renda precisa ser mair que zero");
            RuleFor(x => x.CEP).NotNull().NotEmpty().WithMessage("O CEP é obrigatório");
            RuleFor(x => x.Logradouro).NotNull().NotEmpty().WithMessage("O logradouro é obrigatório");
            RuleFor(x => x.Numero).NotNull().NotEmpty().WithMessage("O número é obrigatório");
            RuleFor(x => x.Bairro).NotNull().NotEmpty().WithMessage("O Bairro é obrigatório");
            RuleFor(x => x.Cidade).NotNull().NotEmpty().WithMessage("A Cidade é obrigatório");
            RuleFor(x => x.Estado).NotNull().NotEmpty().WithMessage("O Estado é obrigatório");            
        }
    }
}
