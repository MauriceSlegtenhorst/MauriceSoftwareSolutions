using System;
using System.ComponentModel.DataAnnotations;

namespace MSS.CrossCuttingConcerns.Infrastructure.Validation
{
    public interface IEmailVerificationService
    {
        ValidationResult IsDomainValid(string email, ValidationContext validationContext);
    }
}
