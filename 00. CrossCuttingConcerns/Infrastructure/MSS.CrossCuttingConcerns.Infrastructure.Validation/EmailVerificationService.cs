using CrossCuttingValidation = MSS.CrossCuttingConcerns.Infrastructure.ConstantData.Validation;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSS.CrossCuttingConcerns.Infrastructure.Validation
{
    public sealed class EmailVerificationService
    {
        private EmailVerificationService() { }

        public static ValidationResult IsDomainValid(string email, ValidationContext validationContext)
        {
            for (int i = 0; i < CrossCuttingValidation.VALID_EMAIL_DOMAINS.Length; i++)
            {
                if (email.ToString().Contains(CrossCuttingValidation.VALID_EMAIL_DOMAINS[i]))
                    return ValidationResult.Success;
            }

            return new ValidationResult("This email domain is not allowed. Please use a respectable domain", new List<string> { validationContext.MemberName });
        }
    }
}
