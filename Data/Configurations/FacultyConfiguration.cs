using TH_CNPMNC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TH_CNPMNC.Configurations{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("Faculty");
            builder.HasKey(b => b.id);
            builder.Property(b => b.id).UseIdentityColumn();
            builder.Property(b => b.faculty_name).HasMaxLength(200).IsRequired();
            
        }
    }
}
