namespace MasterDataServices.Models.User
{
    public class UsertypeUserValidator : AbstractValidator<UsertypeUser>
    {
        public UsertypeUserValidator()
        {
            RuleFor(x => x.user_id)
                .GreaterThan(0).WithMessage("User ID must be greater than zero.")
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.user_type_id)
                .GreaterThan(0).WithMessage("User Type ID must be greater than zero.")
                .NotEmpty().WithMessage("User Type ID is required.");

            RuleFor(x => x.maker_id)
                .GreaterThan(0).WithMessage("Maker ID must be greater than zero.")
                .NotEmpty().WithMessage("Maker ID is required.");

            RuleFor(x => x.make_time)
                .NotEmpty().WithMessage("Make time is required.");

            RuleFor(x => x.last_modified_by)
                .GreaterThan(0).WithMessage("Last modified by must be greater than zero.")
                .NotEmpty().WithMessage("Last modified by is required.");

            RuleFor(x => x.last_modified_date)
                .NotEmpty().WithMessage("Last modified date is required.");
        }
    }
}
