using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Training.Data;
using Training.Data.Common;

namespace Training.Infra
{
    public class ApplicationDbContext : IdentityDbContext<UserData>
    {
        public ApplicationDbContext() : this(new DbContextOptionsBuilder<ApplicationDbContext>().Options) { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TrainingCourseData> TrainingCourses { get; set; }
        public DbSet<EnrollementData> Enrollements { get; set; }
        public DbSet<AreaData> Areas { get; set; }
        public DbSet<InstructorAssignementData> InstructorAssignements { get; set; }
        //public DbSet<UserData> Users { get; set; }  //endale arusaamiseks, kui oled andmetabelid ära genenud, siis võid m ära kusututada

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TrainingCourseData>().ToTable("TrainingCourse");
            builder.Entity<EnrollementData>().ToTable("Enrollement");
            builder.Entity<AreaData>().ToTable("Area");
            builder.Entity<InstructorAssignementData>().ToTable("InstructorAssignements");
           //builder.Entity<UserData>().ToTable("Users");


            builder.HasDefaultSchema("Identity");
            builder.Entity<UserData>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

        }
    }
}
