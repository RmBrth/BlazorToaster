using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using Toaster.Services;

namespace Toaster.Shared
{
    public partial class ToastContainer
    {
        [Inject] ToastService ToastService { get; set; }

        private readonly List<Toast> toasts = new();

        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;
        }

        public void RemoveToast(Guid Id)
        {
            InvokeAsync(() =>
            {
                var toast = toasts.SingleOrDefault(x => x.Id == Id);
                if (toast != null)
                {
                    toasts.Remove(toast);
                    StateHasChanged();
                }
            });
        }

        private void ShowToast(string message, ToastLevel level)
        {
            var toast = new Toast()
            {
                // TODO: Fix warning BL0005
                Id = Guid.NewGuid(),
                Message = message,
                Level = level
            };
            toasts.Add(toast);
            StateHasChanged();
        }
    }
}
