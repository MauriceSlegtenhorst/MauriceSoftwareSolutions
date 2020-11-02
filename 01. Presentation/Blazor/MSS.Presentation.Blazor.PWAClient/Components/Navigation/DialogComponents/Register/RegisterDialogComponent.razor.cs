
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using MSS.CrossCuttingConcerns.Infrastructure.Validation;

using System.Threading.Tasks;
using MSS.Presentation.Blazor.PWAClient.Components.Dialog;


namespace MSS.Presentation.Blazor.PWAClient.Components.Navigation.DialogComponents.Register
{
    public partial class RegisterDialogComponent
    {
        [Inject] public IEmailVerificationService EmailVerificationService { get; set; }
        [Inject] public IDialogService DialogService { get; set; }

        private EditContext editContext;
        private InputModel inputModel;
        private bool showPassword;
        private bool canSubmit;

        protected override Task OnInitializedAsync()
        {
            inputModel = new InputModel();
            editContext = new EditContext(inputModel);

            return base.OnInitializedAsync();
        }

        private async Task RequestRegisterAsync()
        {

        }
    }
}
