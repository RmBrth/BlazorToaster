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

        [Parameter] public ToastContainerPosition Position { get; set; }

        private readonly List<Toast> toasts = new();
        private string position;

        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;

            switch (Position)
            {
                case ToastContainerPosition.TopLeft:
                    position = "custom-toast-container-top custom-toast-container-left";
                    break;
                case ToastContainerPosition.TopRight:
                    position = "custom-toast-container-top custom-toast-container-right";
                    break;
                case ToastContainerPosition.BottomLeft:
                    position = "custom-toast-container-bottom custom-toast-container-left";
                    break;
                case ToastContainerPosition.BottomCenter:
                    position = "custom-toast-container-bottom custom-toast-container-center";
                    break;
                case ToastContainerPosition.BottomRight:
                    position = "custom-toast-container-bottom custom-toast-container-right";
                    break;
                default:
                    position = "custom-toast-container-top custom-toast-container-center";
                    break;
            }
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

    public enum ToastContainerPosition
    {
        TopLeft,
        TopCenter,
        TopRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }
}
