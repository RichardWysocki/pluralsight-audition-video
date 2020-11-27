using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Shared.AddressValidationRules;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Customer.Blazor.Server.UI.Lamar.Pages
{
    public partial class ClientInformation
    {

        [Inject]
        public IEnumerable<ITaskValidation> TaskRuns { get; set; }

        public ClientModel clientModel { get; set; } = new ClientModel() { Name = "", Address1 = "", City = "", State = "", Zip = "" };

        public string message { get; set; }

        private string messageStyles { get; set; } = "visibility:hidden";

        protected override void OnInitialized()
        {

        }

        async Task HandleValidSubmitAsync(EditContext editContext)
        {
            var response = await AnyErrors(editContext);

            message = response;
        }

        private async Task<string> AnyErrors(EditContext editContext)
        {
            var clientmodel = (ClientModel)editContext.Model;
            var responseList = new List<ValidationReturn>();
            var taskList = new List<Task<ValidationReturn>>();
            foreach (var item in TaskRuns)
            {
                taskList.Add(Task.Run(() => item.Execute(clientmodel)));
            }

            ValidationReturn[] validationReturn = await Task.WhenAll(taskList.ToArray()).ConfigureAwait(false);

            var tasks = validationReturn.ToList<ValidationReturn>();

            bool isAddressGood = true;
            messageStyles = "color:green";
            var ErrorMessages = "";
            foreach (var x1 in tasks)
            {
                if (x1.Valid == false)
                { 
                    isAddressGood = false;
                    messageStyles = "color:red";
                    ErrorMessages += x1.ErrorMessage + "<br>";
                }
            }
            return isAddressGood ? "Customer Saved Successfully" :  ErrorMessages;
        }
    }
}
