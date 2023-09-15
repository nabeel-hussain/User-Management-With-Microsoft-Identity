using UM.Domain.Entities;
using UM.Domain.Primitives;
using UM.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Principal;

namespace UM.Infrastructure.Database
{
    public class HMSDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        ILogger<HMSDbContext> _logger;
        IPrincipal _principal;
        public HMSDbContext(DbContextOptions options, ILogger<HMSDbContext> logger,  IPrincipal principal) : base(options)
        {
            _logger = logger;
            _principal = principal;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(HMSDbContext).Assembly);
            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<UserClaim>().ToTable("UserClaim");
            builder.Entity<UserLogin>().ToTable("UserLogin");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<RoleClaim>().ToTable("RoleClaim");
            builder.Entity<UserToken>().ToTable("UserToken");

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<IEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                var userId = _principal.UserId() ?? Guid.Empty;
                entry.Entity.ModificationDate = DateTime.Now;
                entry.Entity.ModifiedBy = userId.ToString();
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreationDate = DateTime.Now;
                    entry.Entity.CreatedBy = userId.ToString();
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
