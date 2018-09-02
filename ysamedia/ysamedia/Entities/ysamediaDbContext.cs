using Microsoft.EntityFrameworkCore;
using ysamedia.Models.DepartmentViewModels;

namespace ysamedia.Entities
{
    public partial class ysamediaDbContext : DbContext
    {
        public ysamediaDbContext()
        {
        }

        public ysamediaDbContext(DbContextOptions<ysamediaDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<AgeGroup> AgeGroup { get; set; }
        public virtual DbSet<AttributeUserBridge> AttributeUserBridge { get; set; }
        public virtual DbSet<ChurchMember> ChurchMember { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DeptUserBrigdge> DeptUserBrigdge { get; set; }
        public virtual DbSet<DlicenceUserBridge> DlicenceUserBridge { get; set; }
        public virtual DbSet<DriverLicence> DriverLicence { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<NegativeAttribute> NegativeAttribute { get; set; }
        public virtual DbSet<NegAttributeUserBridge> NegAttributeUserBridge { get; set; }
        public virtual DbSet<NextOfKin> NextOfKin { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<PositiveAttribute> PositiveAttribute { get; set; }
        public virtual DbSet<RateAnswerUserBridge> RateAnswerUserBridge { get; set; }
        public virtual DbSet<RatingAnswer> RatingAnswer { get; set; }
        public virtual DbSet<RatingQuestion> RatingQuestion { get; set; }
        public virtual DbSet<RelationshipStatus> RelationshipStatus { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<ScreeningAnswer> ScreeningAnswer { get; set; }
        public virtual DbSet<ScreeningQuestion> ScreeningQuestion { get; set; }
        public virtual DbSet<ScreeningScripture> ScreeningScripture { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillCategory> SkillCategory { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<TimeIn> TimeIn { get; set; }
        public virtual DbSet<TransportType> TransportType { get; set; }
        public virtual DbSet<TransUserBridge> TransUserBridge { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<Vacancy> Vacancy { get; set; }
        public virtual DbSet<WorkPreference> WorkPreference { get; set; }

        // Unable to generate entity type for table 'dbo.UserRole'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UserToken'. Please see the warning messages.

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ysamedia;Integrated Security=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.Property(e => e.AchievementName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(450);

                entity.Property(e => e.Institution).HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Achievement)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAchievement_tblUser1");
            });

            modelBuilder.Entity<AgeGroup>(entity =>
            {
                entity.HasKey(e => e.AgroupId);

                entity.Property(e => e.AgroupId).HasColumnName("AGroupId");

                entity.Property(e => e.AgeRange)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<AttributeUserBridge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributeUserBridge)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAttributeUserBridge_tblAttribute");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AttributeUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAttributeUserBridge_tblUser");
            });

            modelBuilder.Entity<ChurchMember>(entity =>
            {
                entity.Property(e => e.AnswerToQ1).HasMaxLength(200);

                entity.Property(e => e.AnswerToQ2).HasMaxLength(200);

                entity.Property(e => e.AnswerToQ3).HasMaxLength(200);

                entity.Property(e => e.AnswerToQ4).HasMaxLength(200);

                entity.Property(e => e.AnswerToQ5).HasMaxLength(200);

                entity.Property(e => e.AnswerToQ6).HasMaxLength(200);

                entity.Property(e => e.CellPhone).HasMaxLength(15);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasMaxLength(50);

                entity.Property(e => e.DateRegistered).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone).HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasColumnType("nchar(10)");

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.WorkPhone).HasMaxLength(15);

                entity.HasOne(d => d.AgeGroup)
                    .WithMany(p => p.ChurchMember)
                    .HasForeignKey(d => d.AgeGroupId)
                    .HasConstraintName("FK_tblChurchMember_tblAgeGroup");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.ChurchMember)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblChurchMember_tblGender");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.ChurchMember)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChurchMember_Occupation");

                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.ChurchMember)
                    .HasForeignKey(d => d.RelationshipId)
                    .HasConstraintName("FK_tblChurchMember_tblRelationshipStatus");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentLead).HasMaxLength(50);

                entity.Property(e => e.DepartmentLeaderId).HasMaxLength(450);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Deputy).HasMaxLength(50);

                entity.Property(e => e.DeputyId).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentLeader)
                    .WithMany(p => p.DepartmentDepartmentLeader)
                    .HasForeignKey(d => d.DepartmentLeaderId)
                    .HasConstraintName("FK_tblDepartment_tblUser");

                entity.HasOne(d => d.DeputyNavigation)
                    .WithMany(p => p.DepartmentDeputyNavigation)
                    .HasForeignKey(d => d.DeputyId)
                    .HasConstraintName("FK_Department_Department");
            });

            modelBuilder.Entity<DeptUserBrigdge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptUserBrigdge)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDeptUserBrigdge_tblDepartment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DeptUserBrigdge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDeptUserBrigdge_tblUser");
            });

            modelBuilder.Entity<DlicenceUserBridge>(entity =>
            {
                entity.ToTable("DLicenceUserBridge");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Licence)
                    .WithMany(p => p.DlicenceUserBridge)
                    .HasForeignKey(d => d.LicenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDLicenceUserBridge_tblDriverLicence");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DlicenceUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDLicenceUserBridge_tblUser");
            });

            modelBuilder.Entity<DriverLicence>(entity =>
            {
                entity.HasKey(e => e.LicenceId);

                entity.Property(e => e.LicenceCode)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.EducationType)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.QualificationName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Education)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEducation_tblUser");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.JobTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Gname)
                    .IsRequired()
                    .HasColumnName("GName")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Language1)
                    .IsRequired()
                    .HasColumnName("Language")
                    .HasMaxLength(50);

                entity.Property(e => e.Proficiency).HasMaxLength(150);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Language)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLanguage_tblUser");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.TimeIn)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.TimeInId)
                    .HasConstraintName("FK_tblLog_tblTimeIn");
            });

            modelBuilder.Entity<NegativeAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeId);

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NegAttributeUserBridge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.NegAttributeUserBridge)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNegAttributeUserBridge_tblNegativeAttribute");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NegAttributeUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNegAttributeUserBridge_tblUser");
            });

            modelBuilder.Entity<NextOfKin>(entity =>
            {
                entity.HasKey(e => e.KinId);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.RelationshipType).HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.WorkNumber).HasMaxLength(15);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NextOfKin)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NextOfKin_User");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.Property(e => e.Occupation1)
                    .IsRequired()
                    .HasColumnName("Occupation")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Photo1).HasColumnName("Photo");

                entity.Property(e => e.PhotoName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPhoto_tblUser");
            });

            modelBuilder.Entity<PositiveAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeId);

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RateAnswerUserBridge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.RateAnswerUserBridge)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRateAnswerUserBridge_tblRatingAnswer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RateAnswerUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRateAnswerUserBridge_tblUser");
            });

            modelBuilder.Entity<RatingAnswer>(entity =>
            {
                entity.HasKey(e => e.AnswerId);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.RatingAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRatingAnswer_tblRatingQuestion");
            });

            modelBuilder.Entity<RatingQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<RelationshipStatus>(entity =>
            {
                entity.HasKey(e => e.RelationshipId);

                entity.Property(e => e.RelationshipCategory)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_tblRoleClaim_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaim)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tblRoleClaim_tblRole_RoleId");
            });

            modelBuilder.Entity<ScreeningAnswer>(entity =>
            {
                entity.HasKey(e => e.AnswerId);

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.ScreeningAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblScreeningAnswer_tblScreeningQuestion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ScreeningAnswer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblScreeningAnswer_tblUser");
            });

            modelBuilder.Entity<ScreeningQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ScreeningScripture>(entity =>
            {
                entity.HasKey(e => e.ScriptureId);

                entity.Property(e => e.Book).HasMaxLength(50);

                entity.Property(e => e.Chapter).HasMaxLength(50);

                entity.Property(e => e.EndVerse).HasColumnType("nchar(10)");

                entity.Property(e => e.StartVerse).HasColumnType("nchar(10)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ScreeningScripture)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblScreeningScripture_tblUser");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Proficiency).HasColumnType("nchar(20)");

                entity.Property(e => e.SkillDesc).HasMaxLength(256);

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.SkillCat)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.SkillCatId)
                    .HasConstraintName("FK_tblSkill_tblSkillCategory");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSkill_tblUser");
            });

            modelBuilder.Entity<SkillCategory>(entity =>
            {
                entity.HasKey(e => e.SkillCatId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Course).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.InstitutionName).HasMaxLength(256);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSubject_tblEducation");
            });

            modelBuilder.Entity<TimeIn>(entity =>
            {
                entity.HasKey(e => e.TimeId);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TransportType>(entity =>
            {
                entity.HasKey(e => e.TransportId);

                entity.Property(e => e.TransportName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TransUserBridge>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TransportId).ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Transport)
                    .WithMany(p => p.TransUserBridge)
                    .HasForeignKey(d => d.TransportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTransUserBridge_tblTransportType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TransUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTransUserBridge_tblUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateJoinedDept).HasColumnType("date");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.DisplayName).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhysicalAddress).HasMaxLength(450);

                entity.Property(e => e.PostalCode).HasColumnType("nchar(10)");

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_tblUser_tblGender");
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_tblUserClaim_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaim)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tblUserClaim_tblUser_UserId");
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.Property(e => e.UserLogId).ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_tblUserLogin_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tblUserLogin_tblUser_UserId");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.Property(e => e.DatePosted).HasColumnType("date");

                entity.Property(e => e.FilledBy).HasMaxLength(450);

                entity.Property(e => e.PostedBy).HasMaxLength(450);

                entity.Property(e => e.VacancyDescription).HasMaxLength(400);

                entity.Property(e => e.VacancyName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Vacancy)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblVacancy_tblDepartment");

                entity.HasOne(d => d.FilledByNavigation)
                    .WithMany(p => p.VacancyFilledByNavigation)
                    .HasForeignKey(d => d.FilledBy)
                    .HasConstraintName("FK_tblVacancy_filledBy_tblUser");

                entity.HasOne(d => d.PostedByNavigation)
                    .WithMany(p => p.VacancyPostedByNavigation)
                    .HasForeignKey(d => d.PostedBy)
                    .HasConstraintName("FK_tblVacancy_tblUser");
            });

            modelBuilder.Entity<WorkPreference>(entity =>
            {
                entity.HasKey(e => e.WorkPrefId);

                entity.Property(e => e.Availability)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.PrefDepartmentNavigation)
                    .WithMany(p => p.WorkPreference)
                    .HasForeignKey(d => d.PrefDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWorkPreference_tblDepartment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkPreference)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWorkPreference_tblUser");
            });
        }

        public DbSet<ysamedia.Models.DepartmentViewModels.DepartmentViewModel> DepartmentViewModel { get; set; }
    }
}
