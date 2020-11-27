using System.Text.RegularExpressions;

namespace Business.Shared.AddressValidationRules
{
    public class ZipCodeValidation : ITaskValidation
    {
        public ValidationReturn Execute(ClientModel clientModel)
        {
            var status = new ValidationReturn() { Valid = true };

            var pattern = @"\b\d{5}(?:-\d{4})?\b";
            var rgx = new Regex(pattern);
            if (!string.IsNullOrWhiteSpace(clientModel?.Zip) && rgx.IsMatch(clientModel.Zip))
            {
                return status;
            }
            status.Valid = false;
            status.ErrorMessage = "Zip Code must be Valid.";
            return status;
        }
    }
}
