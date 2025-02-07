using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

                // � ��������� �� ������� ���� ���� ������ ����� � ���� ��������� �������
            builder.Property(u => u.Email).IsRequired()
                .HasMaxLength(50);

        }
    }
}
