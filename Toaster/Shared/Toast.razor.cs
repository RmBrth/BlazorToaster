using Microsoft.AspNetCore.Components;
using Toaster.Services;

namespace Toaster.Shared
{
    public partial class Toast
    {
        [Inject] ToastService ToastService { get; set; }

        private bool displayed;
        private string message;

        protected override void OnInitialized()
        {
            ToastService.OnShow += Show;
        }

        public void Show(string message)
        {
            this.message = message;
            displayed = true;
            StateHasChanged();
        }

        public void Close()
        {
            displayed = false;
            StateHasChanged();
        }
    }
}
