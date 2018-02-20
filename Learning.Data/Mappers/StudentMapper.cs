using Learning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data.Mappers
{
    class StudentMapper: EntityTypeConfiguration<Student>
    {
        public StudentMapper()
        {
            this.ToTable("Students");

            this.HasKey(s => s.Id);
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.Id).IsRequired();

            this.Property(s => s.UserName).IsRequired();
            this.Property(s => s.UserName).HasMaxLength(50);
            this.Property(s => s.UserName).IsUnicode(false);

            this.Property(s => s.Email).IsRequired();
            this.Property(s => s.Email).HasMaxLength(255);
            this.Property(s => s.Email).IsUnicode(false);

            this.Property(s => s.FirstName).IsRequired();
            this.Property(s => s.FirstName).HasMaxLength(255);

            this.Property(s => s.LastName).IsRequired();
            this.Property(s => s.LastName).HasMaxLength(255);

            this.Property(s => s.Address).IsOptional();
            this.Property(s => s.Address).HasMaxLength(1000);

            this.Property(s => s.DateOfBirth).IsRequired();
            this.Property(s => s.DateOfBirth).HasColumnType("smalldatetime");
        }
    }
}
