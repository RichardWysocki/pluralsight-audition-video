namespace Business.Shared.AddressValidationRules
{
    public class NameValidation : ITaskValidation
    {
        public ValidationReturn Execute(ClientModel clientModel)
        {
            var status = new ValidationReturn() { Valid = true };

            if (string.IsNullOrWhiteSpace(clientModel?.Name))
            {
                status.Valid = false;
                status.ErrorMessage = "Client Name must contain a valid value";
            }
            return status;
        }

    }
}
