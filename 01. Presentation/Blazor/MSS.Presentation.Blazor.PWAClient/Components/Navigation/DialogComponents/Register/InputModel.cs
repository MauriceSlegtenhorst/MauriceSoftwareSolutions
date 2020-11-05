using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using MSS.CrossCuttingConcerns.Infrastructure.Validation;

namespace MSS.Presentation.Blazor.PWAClient.Components.Navigation.DialogComponents.Register
{
    public class InputModel
    {
        [Required(ErrorMessage = "Email is required")]
        [CustomValidation(
            validatorType: typeof(EmailVerificationService),
            method: nameof(EmailVerificationService.IsDomainValid))]
        [EmailAddress(ErrorMessage = "This email does not meet the requirements")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(
            pattern: Validation.VALID_PASSWORD_PATTERN,
            ErrorMessage = Validation.PASSWORD_ERROR_MESSAGE)]
        public string Password { get; set; }

        //[Compare(nameof(Password), ErrorMessage = "The two password fields must correspond")]
        [JsonIgnore]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(
            pattern: Validation.VALID_PASSWORD_PATTERN,
            ErrorMessage = Validation.PASSWORD_ERROR_MESSAGE)]
        [CompareProperty(nameof(Password), ErrorMessage = "The two password fields must correspond")]
        public string PasswordTwo { get; set; }
    }
}
