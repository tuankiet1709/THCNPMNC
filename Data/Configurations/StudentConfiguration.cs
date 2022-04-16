using TH_CNPMNC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TH_CNPMNC.Configurations{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(p => p.id);
            builder.Property(p=>p.id).UseIdentityColumn();
            builder.Property(p => p.first_name).HasMaxLength(200).IsRequired();
            builder.Property(p=>p.last_name).IsRequired();
            builder.Property(p=>p.email).IsRequired();
            builder.Property(p=>p.gender).IsRequired();
            builder.Property(b=> b.faculty_id).IsRequired();

            builder.HasOne(b=>b.Faculty).WithMany(b=>b.Students).HasForeignKey(x=>x.faculty_id);

        }
    }
}
