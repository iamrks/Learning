using Learning.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Learning.Data.Mappers
{
    class SessionMapper: EntityTypeConfiguration<Session>
    {
        public SessionMapper()
        {
            this.ToTable("Sessions");

            this.Property(s => s.Id).IsRequired();
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(s => s.Token).IsRequired();

            this.Property(s => s.UserId).IsRequired();

            this.Property(s => s.LoginTime).IsRequired();
        }
    }
}
