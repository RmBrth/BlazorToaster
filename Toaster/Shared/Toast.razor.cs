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

        public void Close()
        {
            Container.RemoveToast(Id);
        }
    }
}
