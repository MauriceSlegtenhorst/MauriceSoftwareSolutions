
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using System.Threading.Tasks;
using MSS.Presentation.Blazor.PWAClient.Components.Dialog;
using System;
using System.Linq;

namespace MSS.Presentation.Blazor.PWAClient.Components.Navigation.DialogComponents.Register
{
    public partial class RegisterDialogComponent : IDisposable
    {
        [Inject] public IDialogService DialogService { get; set; }

        private InputModel inputModel { get; set; }

        private EditContext editContext { get; set; }
        
        private bool showPassword;
        private bool canSubmit;
        private string emailIconCSS;
        private string emailCSS;
        private string passwordOneIconCSS;
        private string passwordOneCSS;
        private string passwordTwoIconCSS;
        private string passwordTwoCSS;

        protected override Task OnInitializedAsync()
        {
            inputModel = new InputModel();
            editContext = new EditContext(inputModel);

            editContext.OnValidationStateChanged += OnValidationStateChanged;

            return base.OnInitializedAsync();
        }

        public void Dispose()
        {
            editContext.OnValidationStateChanged -= OnValidationStateChanged;
        }

        private void OnValidationStateChanged(object sender, ValidationStateChangedEventArgs e)
        {
            canSubmit = editContext.GetValidationMessages().Any() == false;

            FieldIdentifier emailField = editContext.Field(nameof(inputModel.Email));
            if (editContext.GetValidationMessages(emailField).Any())
            {
                emailIconCSS = "ms-Icon ms-Icon--CriticalErrorSolid mss-text-box-icon-invalid";
                emailCSS = "mss-text-box-invalid";
            }
            else
            {
                emailIconCSS = null;
                emailCSS = null;
            }

            FieldIdentifier passwordOneField = editContext.Field(nameof(inputModel.Password));
            if (editContext.GetValidationMessages(passwordOneField).Any())
            {
                passwordOneIconCSS = "ms-Icon ms-Icon--CriticalErrorSolid mss-text-box-icon-invalid";
                passwordOneCSS = "mss-text-box-invalid";
            }
            else
            {
                passwordOneIconCSS = null;
                passwordOneCSS = null;
            }

            FieldIdentifier passwordTwoField = editContext.Field(nameof(inputModel.PasswordTwo));
            if (editContext.GetValidationMessages(passwordTwoField).Any())
            {
                passwordTwoIconCSS = "ms-Icon ms-Icon--CriticalErrorSolid mss-text-box-icon-invalid";
                passwordTwoCSS = "mss-text-box-invalid";
            }
            else
            {
                passwordTwoIconCSS = null;
                passwordTwoCSS = null;
            }
            
        }

        private async Task RequestRegisterAsync()
        {

        }
    }
}
