using Learning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data.Mappers
{
    class UserMapper: EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            this.ToTable("Users");

            this.HasKey(u => u.Id);
            this.Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(u => u.Id).IsRequired();

            this.Property(u => u.Username).IsRequired();
            this.Property(u => u.Username).HasMaxLength(50);
            this.Property(u => u.Username).IsUnicode(false);
            this.Property(u => u.Username).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));

            this.Property(u => u.Password).IsRequired();

            this.Property(u => u.Email).IsRequired();
            this.Property(u => u.Email).HasMaxLength(80);
            this.Property(u => u.Email).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));

            this.Property(u => u.FirstName).IsRequired();
            this.Property(u => u.FirstName).HasMaxLength(50);

            this.Property(u => u.MiddleName).IsOptional();
            this.Property(u => u.MiddleName).HasMaxLength(50);

            this.Property(u => u.LastName).IsRequired();
            this.Property(u => u.LastName).HasMaxLength(50);

            this.Property(u => u.DateOfBirth).IsRequired();

            this.Property(u => u.Address).IsOptional();

            this.Property(u => u.ImageUrl).IsOptional();
        }
    }
}
