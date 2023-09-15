using UM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Infrastructure.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder
                .HasKey(x => new { x.RoleId, x.UserId });

            builder
                .HasOne(x => x.User)
                .WithMany(user => user.UserRoles)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Role)
                .WithMany(role => role.UserRoles)
                .HasForeignKey(x => x.RoleId);

            builder.ToTable("UserRole");
        }
    }
}
