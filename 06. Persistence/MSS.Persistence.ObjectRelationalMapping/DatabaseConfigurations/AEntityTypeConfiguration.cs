using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSS.Domain.Common.Interfaces;

namespace MSS.Persistence.ObjectRelationalMapping.DatabaseConfigurations
{
    public abstract class AEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.CreationDateUTC)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(entity => entity.ModificationDateUTC)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            ConfigureOtherProperties(builder);
        }

        protected abstract void ConfigureOtherProperties(EntityTypeBuilder<TEntity> builder);
    }
}
