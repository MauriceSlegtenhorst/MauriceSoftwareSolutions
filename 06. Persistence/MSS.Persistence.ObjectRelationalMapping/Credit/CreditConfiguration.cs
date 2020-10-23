using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSS.Persistence.ObjectRelationalMapping.DatabaseConfigurations;

namespace ObjectRelationalMapping.Credit
{
    public sealed class CreditConfiguration : AEntityTypeConfiguration<DomainCredit>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<DomainCredit> builder)
        {
            builder.HasOne(credit => credit.CreditCategory)
                .WithMany(creditCategory => creditCategory.Credits);

            builder.Property(credit => credit.Title)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(credit => credit.SubTitle)
                .HasMaxLength(80);

            builder.Property(credit => credit.HTMLGotFrom)
                .IsRequired();

            builder.Property(credit => credit.HTMLMadeBy)
                .IsRequired();
        }
    }
}
