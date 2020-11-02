using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MSS.Presentation.Blazor.PWAClient.Components.Dialog
{
    public interface IDialogService
    {
        event Func<Task> OnClose;
        event Func<string, RenderFragment, Task> OnOpen;

        Task Close();

        /// <exception cref="ArgumentException">Thrown if parameter "Type contentComponent" is not a Blazor component</exception>
        Task Open(string title, Type content);
    }
}
