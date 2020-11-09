using AggregateWithEFCore.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AggregateWithEFCore.Infrastructure
{
    public class UserAggregateRootEntityTypeConfiguration : IEntityTypeConfiguration<UserAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<UserAggregateRoot> builder)
        {
            // Configuration de la Value Object
            builder.OwnsOne(u => u.Address);

            // Configuration de la collection de Roles en Read Only
            var navigation = builder.Metadata.FindNavigation(nameof(UserAggregateRoot.Roles));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
