using API.DTO.Contract;
using FluentValidation;

namespace API.Validator.Contract
{
    public class ProductForFileDTOValidator : AbstractValidator<ProductForFileDTO>
    {
        public ProductForFileDTOValidator()
        {
            RuleFor(x => x.Id)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.File)
                   .NotNull()
                   .NotEmpty();
        }
    }
}