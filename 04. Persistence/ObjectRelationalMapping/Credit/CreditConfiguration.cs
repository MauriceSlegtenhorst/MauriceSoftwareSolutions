using DomainCredit = MSS.Domain.Concrete.DatabaseModels.Credit.Credit;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ObjectRelationalMapping.Credit
{
    public sealed class CreditConfiguration : IEntityTypeConfiguration<DomainCredit>
    {
        public void Configure(EntityTypeBuilder<DomainCredit> builder)
        {
            builder.HasKey(credit => credit.Id);

            builder.HasOne(credit => credit.CreditCategory)
                .WithMany(creditCategory => creditCategory.Credits);
            
            builder.Property(credit => credit.CreationDateUTC)
                .ValueGeneratedOnAdd();
            
            builder.Property(credit => credit.ModificationDateUTC)
                .ValueGeneratedOnUpdate();

            builder.Property(credit => credit.Title)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(credit => credit.GotFrom)
                .IsRequired();

            builder.Property(credit => credit.MadeBy)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
