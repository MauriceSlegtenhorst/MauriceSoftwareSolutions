using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSS.Persistence.ObjectRelationalMapping.DatabaseConfigurations;

namespace ObjectRelationalMapping.UserAccount
{
    public class UserAccountConfiguration : AEntityTypeConfiguration<DomainUserAccount>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<DomainUserAccount> builder)
        {
            builder.Property(userAccount => userAccount.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(userAccount => userAccount.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(userAccount => userAccount.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(userAccount => userAccount.PasswordHash)
                .IsRequired();

            builder.Property(userAccount => userAccount.SessionTimeMinutes)
                .IsRequired();
        }
    }
}
