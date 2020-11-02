
using Microsoft.AspNetCore.Components;
using MSS.Presentation.Blazor.PWAClient.Components.Dialog;
using MSS.Presentation.Blazor.PWAClient.Components.Navigation.DialogComponents;
using System;
using System.Threading.Tasks;

namespace MSS.Presentation.Blazor.PWAClient.Components.Navigation
{
    public partial class NavigationBarComponent
    {
        private const string LoginTitle = "MSS Portal";
        private const string RegisterTitle = "MSS Registration";

        [Inject]
        private IDialogService _dialogService { get; set; }
        

        private async Task ShowDialog<TDialogComponent>(string title) where TDialogComponent : ComponentBase
        {
            await _dialogService.Open(title, typeof(TDialogComponent));
        }
    }
}
