using DomainCreditCategory = MSS.Domain.Concrete.DatabaseModels.Credit.CreditCategory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ObjectRelationalMapping.Credit
{
    public sealed class CreditCategoryConfiguration : IEntityTypeConfiguration<DomainCreditCategory>
    {
        public void Configure(EntityTypeBuilder<DomainCreditCategory> builder)
        {
            builder.HasKey(creditCategory => creditCategory.Id);

            builder.HasMany(creditCategory => creditCategory.Credits)
                .WithOne(credit => credit.CreditCategory);

            builder.Property(creditCategory => creditCategory.CreationDateUTC)
                .ValueGeneratedOnAdd();

            builder.Property(creditCategory => creditCategory.ModificationDateUTC)
                .ValueGeneratedOnUpdate();

            builder.Property(creditCategory => creditCategory.Title)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(creditCategory => creditCategory.SubTitle)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
