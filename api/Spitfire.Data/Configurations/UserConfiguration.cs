namespace Spitfire.Data.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Domain;

    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(p => p.Username)
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_UserName") { IsUnique = true }));

            Property(p => p.Timestamp)
                .IsRowVersion();
        }
    }
}
