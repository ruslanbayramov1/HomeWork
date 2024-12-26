using ApiNtierGenericRepository.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiNtierGenericRepository.DAL.Configurations;

internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.Group)
            .WithMany(x => x.Lessons)
            .HasForeignKey(x => x.GroupId);

        builder
            .HasOne(x => x.Room)
            .WithMany(x => x.Lessons)
            .HasForeignKey(x => x.RoomId);
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(64)
            .IsRequired();

        builder
            .Property(x => x.ScheduleAt)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder
            .Property(x => x.ScheduleEnd)
            .IsRequired();
    }
}
