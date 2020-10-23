using DomainCreditCategory = MSS.Domain.Concrete.DatabaseEntities.Credit.CreditCategory;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSS.Persistence.ObjectRelationalMapping.DatabaseConfigurations;

namespace ObjectRelationalMapping.Credit
{
    public sealed class CreditCategoryConfiguration : AEntityTypeConfiguration<DomainCreditCategory>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<DomainCreditCategory> builder)
        {
            builder.HasMany(creditCategory => creditCategory.Credits)
               .WithOne(credit => credit.CreditCategory);

            builder.Property(creditCategory => creditCategory.Title)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(creditCategory => creditCategory.SubTitle)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
