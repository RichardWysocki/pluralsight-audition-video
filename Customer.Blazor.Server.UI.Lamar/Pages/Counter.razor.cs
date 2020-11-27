using Business.Shared.SiteCounterExample;
using Microsoft.AspNetCore.Components;

namespace Customer.Blazor.Server.UI.Lamar.Pages
{
    public partial class Counter
    {
        [Inject]
        public ISiteCounter SiteCounter { get; set; }

        private void IncrementCount()
        {
            SiteCounter.AddCounter();
        }
    }
}
