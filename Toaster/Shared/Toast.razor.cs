using Microsoft.AspNetCore.Components;
using System;
using Toaster.Services;

namespace Toaster.Shared
{
    public partial class Toast
    {
        [CascadingParameter] private ToastContainer Container { get; set; }
        [Parameter] public Guid Id { get; set; }
        [Parameter] public string Message { get; set; }
        [Parameter] public ToastLevel Level { get; set; }

        private string background;
        private string icon;
        private string title;

        protected override void OnInitialized()
        {
            switch (Level)
            {
                case ToastLevel.Info:
                    background = "bg-info";
                    icon = "bi-info-circle";
                    title = "Info";
                    break;
                case ToastLevel.Success:
                    background = "bg-success";
                    icon = "bi-check-circle";
                    title = "Success";
                    break;
                case ToastLevel.Warning:
                    background = "bg-warning";
                    icon = "bi-exclamation-circle";
                    title = "Warning";
                    break;
                default:
                    background = "bg-danger";
                    icon = "bi-x-circle";
                    title = "Error";
                    break;
            }
        }

        public void Close()
        {
            Container.RemoveToast(Id);
        }
    }
}
