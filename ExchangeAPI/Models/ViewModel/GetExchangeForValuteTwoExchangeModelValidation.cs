using FluentValidation;

namespace ExchangeAPI.Models.ViewModel
{
    public class GetExchangeForValuteTwoExchangeModelValidation : AbstractValidator<GetExchangeForValuteTwoExchangeModel>
    {
        public GetExchangeForValuteTwoExchangeModelValidation()
        {
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0).WithMessage("Amount must be greater than 0");
            RuleFor(x => x.CurrencyTwo).IsInEnum().WithMessage("Unsupported Currency");
            RuleFor(x => x.CurrencyOne).IsInEnum().WithMessage("Unsupported Currency");
        }
    }
}
