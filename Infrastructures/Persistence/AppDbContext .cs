using App;
using App.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Persistence
{

    public class AppDbContext : IdentityDbContext<
            AppUser,
            AppRole,
            long,
            AppUserClaim,
            AppUserRole,
            AppUserLogin,
            AppRoleClaim,
            AppUserToken
        >,
        IAppContext
    {
        public const string Added = "Added";
        public const string Modified = "Modified";
        public const string Deleted = "Deleted";

        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;

        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService s, IDateTimeService d)
            : base(options)
        {
            _currentUserService = s;
            _dateTimeService = d;
        }

        //public AppDbContext()
        //{
        //    _currentUserService = new DummyUserService();
        //    _dateTimeService = new DummyDateTimeService();
        //}

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            BeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void BeforeSaving()
        {
            var userId = _currentUserService.GetCurrentUserId();
            foreach (var entry in ChangeTracker.Entries())
            {
                string? state;
                if (entry.Entity is ITrackable trackable)
                {
                    state = entry.State.ToString();
                    if (state == Added)
                    {
                        trackable.CreatedAt = trackable.UpdatedAt = _dateTimeService.Now();
                        if (trackable.CreatedBy == AppUser.Empty.Id)
                            trackable.CreatedBy = trackable.UpdatedBy = userId;
                    }
                    else
                    {
                        entry.Property(nameof(ITrackable.CreatedBy)).IsModified = false;
                        entry.Property(nameof(ITrackable.CreatedAt)).IsModified = false;
                        if (state == Modified)
                        {
                            trackable.UpdatedAt = _dateTimeService.Now();
                            if (trackable.UpdatedBy == AppUser.Empty.Id)
                                trackable.UpdatedBy = userId;
                        }
                    }
                }

                if (entry.Entity is ISoftDeletable)
                {
                    state = entry.State.ToString();
                    if (state == Deleted)
                    {
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[nameof(ISoftDeletable.DeletedAt)] = _dateTimeService.Now();
                        entry.CurrentValues[nameof(ISoftDeletable.DeletedBy)] = userId;
                    }
                }

                if (entry.Entity is IVersionable versionable)
                {
                    state = entry.State.ToString();
                    if (state == Added)
                        versionable.Version = 0;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AppUser>()
            //    .ToTable("app_users");
        }
    }
}
