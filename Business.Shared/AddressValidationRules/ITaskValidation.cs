namespace Business.Shared.AddressValidationRules
{
    public interface ITaskValidation
    {
        ValidationReturn Execute(ClientModel clientModel);

    }
}
