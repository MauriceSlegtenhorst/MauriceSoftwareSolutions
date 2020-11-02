using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MSS.Presentation.Blazor.PWAClient.Components.Dialog
{
    public partial class DialogComponent : IDisposable
    {
        [Inject]
        private IDialogService _dialogService { get; set; }

        private RenderFragment content { get; set; }
        private string title { get; set; }

        private string dialogCSS { get; set; }

        protected override Task OnInitializedAsync()
        {
            _dialogService.OnOpen += Open;
            _dialogService.OnClose += Close;

            return base.OnInitializedAsync();
        }

        public void Dispose()
        {
            _dialogService.OnOpen -= Open;
            _dialogService.OnClose -= Close;
        }

        private async Task Open(string title, RenderFragment content)
        {
            await Task.Run(() => 
            {
                this.title = title;
                this.content = content;
                dialogCSS = "mss-modal-visible";

                StateHasChanged();
            });
        }

        private async Task Close()
        {
            await Task.Run(() => 
            {
                dialogCSS = null;
                content = null;
                title = null;

                StateHasChanged();
            });
        }
    }
}
