using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MSS.Presentation.Blazor.PWAClient.Components.Dialog
{
    public class DialogService : IDialogService
    {
        public event Func<Task> OnClose;
        public event Func<string, RenderFragment, Task> OnOpen;

        public async Task Close()
        {
            await OnClose?.Invoke();
        }

        /// <exception cref="ArgumentException">Thrown if parameter "Type contentComponent" is not a Blazor component</exception>
        public async Task Open(string title, Type contentComponent)
        {
            if (typeof(ComponentBase).IsAssignableFrom(contentComponent) == false)
                throw new ArgumentException($"Parameter {nameof(contentComponent)} is not a Blazor component. Please provide a legitimate Blazor(.razor) component.");

            var dialogContent = new RenderFragment(renderTreeBuilder =>
            {
                renderTreeBuilder.OpenComponent(1, contentComponent);
                renderTreeBuilder.CloseComponent();
            });

            await OnOpen?.Invoke(title, dialogContent);
        }
    }
}
