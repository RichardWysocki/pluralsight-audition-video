namespace Business.Shared.AddressValidationRules
{
    public class AddressValidation : ITaskValidation
    {
        public ValidationReturn Execute(ClientModel clientModel)
        {
            var status = new ValidationReturn() { Valid = true };

            if (string.IsNullOrWhiteSpace(clientModel.Address1) || string.IsNullOrWhiteSpace(clientModel.City) || string.IsNullOrWhiteSpace(clientModel.State) || string.IsNullOrWhiteSpace(clientModel.Zip) )
            {
                status.Valid = false;
                status.ErrorMessage = "Client Address must be valid.";
            }
            return status;
        }

    }
}
