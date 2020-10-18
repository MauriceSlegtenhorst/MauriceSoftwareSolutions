using DomainUserAccount = MSS.Domain.Concrete.DatabaseModels.UserAccount;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ObjectRelationalMapping.UserAccount
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<DomainUserAccount>
    {
        public void Configure(EntityTypeBuilder<DomainUserAccount> builder)
        {
            builder.HasKey(userAccount => userAccount.Id);
            
            builder.Property(userAccount => userAccount.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(userAccount => userAccount.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(userAccount => userAccount.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(userAccount => userAccount.PasswordHash)
                .IsRequired();
        }
    }
}
