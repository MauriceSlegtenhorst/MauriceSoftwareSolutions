using CrossCuttingValidation = MSS.CrossCuttingConcerns.Infrastructure.ConstantData.Validation;

using MSS.CrossCuttingConcerns.Infrastructure.Validation;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MSS.CrossCuttingConcerns.Concrete.Validation
{
    public sealed class EmailVerificationService : IEmailVerificationService
    {
        public ValidationResult IsDomainValid(string email, ValidationContext validationContext)
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
