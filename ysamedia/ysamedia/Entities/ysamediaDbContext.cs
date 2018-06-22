using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<TblAchievement> TblAchievement { get; set; }
        public virtual DbSet<TblAgeGroup> TblAgeGroup { get; set; }
        public virtual DbSet<TblAnswer> TblAnswer { get; set; }
        public virtual DbSet<TblAttribute> TblAttribute { get; set; }
        public virtual DbSet<TblAttributeUserBridge> TblAttributeUserBridge { get; set; }
        public virtual DbSet<TblChurchMember> TblChurchMember { get; set; }
        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblDependant> TblDependant { get; set; }
        public virtual DbSet<TblDependantCategory> TblDependantCategory { get; set; }
        public virtual DbSet<TblDeptUserBrigdge> TblDeptUserBrigdge { get; set; }
        public virtual DbSet<TblDlicenceUserBridge> TblDlicenceUserBridge { get; set; }
        public virtual DbSet<TblDriverLicence> TblDriverLicence { get; set; }
        public virtual DbSet<TblEducation> TblEducation { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblGender> TblGender { get; set; }
        public virtual DbSet<TblLanguage> TblLanguage { get; set; }
        public virtual DbSet<TblLog> TblLog { get; set; }
        public virtual DbSet<TblNegativeAttribute> TblNegativeAttribute { get; set; }
        public virtual DbSet<TblNegAttributeUserBridge> TblNegAttributeUserBridge { get; set; }
        public virtual DbSet<TblOccupation> TblOccupation { get; set; }
        public virtual DbSet<TblPhoto> TblPhoto { get; set; }
        public virtual DbSet<TblQuestion> TblQuestion { get; set; }
        public virtual DbSet<TblRateAnswerUserBridge> TblRateAnswerUserBridge { get; set; }
        public virtual DbSet<TblRatingAnswer> TblRatingAnswer { get; set; }
        public virtual DbSet<TblRatingQuestion> TblRatingQuestion { get; set; }
        public virtual DbSet<TblRelationshipStatus> TblRelationshipStatus { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblRoleClaim> TblRoleClaim { get; set; }
        public virtual DbSet<TblScreeningAnswer> TblScreeningAnswer { get; set; }
        public virtual DbSet<TblScreeningQuestion> TblScreeningQuestion { get; set; }
        public virtual DbSet<TblScreeningScripture> TblScreeningScripture { get; set; }
        public virtual DbSet<TblSkill> TblSkill { get; set; }
        public virtual DbSet<TblSkillCategory> TblSkillCategory { get; set; }
        public virtual DbSet<TblStudent> TblStudent { get; set; }
        public virtual DbSet<TblSubject> TblSubject { get; set; }
        public virtual DbSet<TblTimeIn> TblTimeIn { get; set; }
        public virtual DbSet<TblTransportType> TblTransportType { get; set; }
        public virtual DbSet<TblTransUserBridge> TblTransUserBridge { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserClaim> TblUserClaim { get; set; }
        public virtual DbSet<TblUserLogin> TblUserLogin { get; set; }
        public virtual DbSet<TblVacancy> TblVacancy { get; set; }
        public virtual DbSet<TblWorkPreference> TblWorkPreference { get; set; }

        // Unable to generate entity type for table 'dbo.tblUserRole'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblUserToken'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ysamedia;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAchievement>(entity =>
            {
                entity.HasKey(e => e.AchievementId);

                entity.ToTable("tblAchievement");

                entity.Property(e => e.AchievementId).ValueGeneratedNever();

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
                    .WithMany(p => p.TblAchievement)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAchievement_tblUser1");
            });

            modelBuilder.Entity<TblAgeGroup>(entity =>
            {
                entity.HasKey(e => e.AgroupId);

                entity.ToTable("tblAgeGroup");

                entity.Property(e => e.AgroupId)
                    .HasColumnName("AGroupId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgeRange)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<TblAnswer>(entity =>
            {
                entity.HasKey(e => e.AnswerId);

                entity.ToTable("tblAnswer");

                entity.Property(e => e.AnswerId).ValueGeneratedNever();

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.ChurchMember)
                    .WithMany(p => p.TblAnswer)
                    .HasForeignKey(d => d.ChurchMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAnswer_tblChurchMember");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TblAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAnswer_tblQuestion");
            });

            modelBuilder.Entity<TblAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeId);

                entity.ToTable("tblAttribute");

                entity.Property(e => e.AttributeId).ValueGeneratedNever();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblAttributeUserBridge>(entity =>
            {
                entity.ToTable("tblAttributeUserBridge");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.TblAttributeUserBridge)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAttributeUserBridge_tblAttribute");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblAttributeUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAttributeUserBridge_tblUser");
            });

            modelBuilder.Entity<TblChurchMember>(entity =>
            {
                entity.HasKey(e => e.ChurchMemberId);

                entity.ToTable("tblChurchMember");

                entity.Property(e => e.ChurchMemberId).ValueGeneratedNever();

                entity.Property(e => e.CellPhone).HasMaxLength(15);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateRegistered).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone).HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.PhysicalAddress).HasMaxLength(250);

                entity.Property(e => e.WorkPhone).HasMaxLength(15);

                entity.HasOne(d => d.AgeGroup)
                    .WithMany(p => p.TblChurchMember)
                    .HasForeignKey(d => d.AgeGroupId)
                    .HasConstraintName("FK_tblChurchMember_tblAgeGroup");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.TblChurchMember)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblChurchMember_tblGender");

                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.TblChurchMember)
                    .HasForeignKey(d => d.RelationshipId)
                    .HasConstraintName("FK_tblChurchMember_tblRelationshipStatus");
            });

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("tblDepartment");

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DepartmentLeaderId).HasMaxLength(450);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.DepartmentLeader)
                    .WithMany(p => p.TblDepartment)
                    .HasForeignKey(d => d.DepartmentLeaderId)
                    .HasConstraintName("FK_tblDepartment_tblUser");
            });

            modelBuilder.Entity<TblDependant>(entity =>
            {
                entity.HasKey(e => e.DependantId);

                entity.ToTable("tblDependant");

                entity.Property(e => e.DependantId).ValueGeneratedNever();

                entity.HasOne(d => d.ChurchMember)
                    .WithMany(p => p.TblDependant)
                    .HasForeignKey(d => d.ChurchMemberId)
                    .HasConstraintName("FK_tblDependant_tblChurchMember");
            });

            modelBuilder.Entity<TblDependantCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tblDependantCategory");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Dependant)
                    .WithMany(p => p.TblDependantCategory)
                    .HasForeignKey(d => d.DependantId)
                    .HasConstraintName("FK_tblDependantCategory_tblDependantCategory");
            });

            modelBuilder.Entity<TblDeptUserBrigdge>(entity =>
            {
                entity.ToTable("tblDeptUserBrigdge");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblDeptUserBrigdge)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDeptUserBrigdge_tblDepartment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblDeptUserBrigdge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDeptUserBrigdge_tblUser");
            });

            modelBuilder.Entity<TblDlicenceUserBridge>(entity =>
            {
                entity.ToTable("tblDLicenceUserBridge");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Licence)
                    .WithMany(p => p.TblDlicenceUserBridge)
                    .HasForeignKey(d => d.LicenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDLicenceUserBridge_tblDriverLicence");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblDlicenceUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDLicenceUserBridge_tblUser");
            });

            modelBuilder.Entity<TblDriverLicence>(entity =>
            {
                entity.HasKey(e => e.LicenceId);

                entity.ToTable("tblDriverLicence");

                entity.Property(e => e.LicenceId).ValueGeneratedNever();

                entity.Property(e => e.LicenceCode)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<TblEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId);

                entity.ToTable("tblEducation");

                entity.Property(e => e.EducationId).ValueGeneratedNever();

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
                    .WithMany(p => p.TblEducation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEducation_tblUser");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tblEmployee");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployee_tblOccupation");
            });

            modelBuilder.Entity<TblGender>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.ToTable("tblGender");

                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.Gname)
                    .IsRequired()
                    .HasColumnName("GName")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<TblLanguage>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.ToTable("tblLanguage");

                entity.Property(e => e.LanguageId).ValueGeneratedNever();

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Proficiency).HasMaxLength(150);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblLanguage)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLanguage_tblUser");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("tblLog");

                entity.Property(e => e.LogId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Month).HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Year).HasMaxLength(50);

                entity.HasOne(d => d.TimeIn)
                    .WithMany(p => p.TblLog)
                    .HasForeignKey(d => d.TimeInId)
                    .HasConstraintName("FK_tblLog_tblTimeIn");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLog_tblUser");
            });

            modelBuilder.Entity<TblNegativeAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeId);

                entity.ToTable("tblNegativeAttribute");

                entity.Property(e => e.AttributeId).ValueGeneratedNever();

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblNegAttributeUserBridge>(entity =>
            {
                entity.ToTable("tblNegAttributeUserBridge");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.TblNegAttributeUserBridge)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNegAttributeUserBridge_tblNegativeAttribute");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblNegAttributeUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNegAttributeUserBridge_tblUser");
            });

            modelBuilder.Entity<TblOccupation>(entity =>
            {
                entity.HasKey(e => e.OccupationId);

                entity.ToTable("tblOccupation");

                entity.Property(e => e.OccupationId).ValueGeneratedNever();

                entity.HasOne(d => d.ChurchMember)
                    .WithMany(p => p.TblOccupation)
                    .HasForeignKey(d => d.ChurchMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOccupation_tblChurchMember");
            });

            modelBuilder.Entity<TblPhoto>(entity =>
            {
                entity.HasKey(e => e.PhotoId);

                entity.ToTable("tblPhoto");

                entity.Property(e => e.PhotoId).ValueGeneratedNever();

                entity.Property(e => e.Photo).IsRequired();

                entity.Property(e => e.PhotoName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPhoto)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPhoto_tblUser");
            });

            modelBuilder.Entity<TblQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("tblQuestion");

                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(700);
            });

            modelBuilder.Entity<TblRateAnswerUserBridge>(entity =>
            {
                entity.ToTable("tblRateAnswerUserBridge");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.TblRateAnswerUserBridge)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRateAnswerUserBridge_tblRatingAnswer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblRateAnswerUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRateAnswerUserBridge_tblUser");
            });

            modelBuilder.Entity<TblRatingAnswer>(entity =>
            {
                entity.HasKey(e => e.AnswerId);

                entity.ToTable("tblRatingAnswer");

                entity.Property(e => e.AnswerId).ValueGeneratedNever();

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TblRatingAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRatingAnswer_tblRatingQuestion");
            });

            modelBuilder.Entity<TblRatingQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("tblRatingQuestion");

                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblRelationshipStatus>(entity =>
            {
                entity.HasKey(e => e.RelationshipId);

                entity.ToTable("tblRelationshipStatus");

                entity.Property(e => e.RelationshipId).ValueGeneratedNever();

                entity.Property(e => e.RelationshipCategory)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("tblRole");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<TblRoleClaim>(entity =>
            {
                entity.ToTable("tblRoleClaim");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblRoleClaim)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<TblScreeningAnswer>(entity =>
            {
                entity.HasKey(e => e.AnswerId);

                entity.ToTable("tblScreeningAnswer");

                entity.Property(e => e.AnswerId).ValueGeneratedNever();

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TblScreeningAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblScreeningAnswer_tblScreeningQuestion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblScreeningAnswer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblScreeningAnswer_tblUser");
            });

            modelBuilder.Entity<TblScreeningQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("tblScreeningQuestion");

                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TblScreeningScripture>(entity =>
            {
                entity.HasKey(e => e.ScriptureId);

                entity.ToTable("tblScreeningScripture");

                entity.Property(e => e.ScriptureId).ValueGeneratedNever();

                entity.Property(e => e.Book).HasMaxLength(50);

                entity.Property(e => e.Chapter).HasMaxLength(50);

                entity.Property(e => e.EndVerse).HasColumnType("nchar(10)");

                entity.Property(e => e.StartVerse).HasColumnType("nchar(10)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblScreeningScripture)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblScreeningScripture_tblUser");
            });

            modelBuilder.Entity<TblSkill>(entity =>
            {
                entity.HasKey(e => e.SkillId);

                entity.ToTable("tblSkill");

                entity.Property(e => e.SkillId).ValueGeneratedNever();

                entity.Property(e => e.Proficiency).HasColumnType("nchar(20)");

                entity.Property(e => e.SkillDesc).HasMaxLength(256);

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.SkillCat)
                    .WithMany(p => p.TblSkill)
                    .HasForeignKey(d => d.SkillCatId)
                    .HasConstraintName("FK_tblSkill_tblSkillCategory");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblSkill)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSkill_tblUser");
            });

            modelBuilder.Entity<TblSkillCategory>(entity =>
            {
                entity.HasKey(e => e.SkillCatId);

                entity.ToTable("tblSkillCategory");

                entity.Property(e => e.SkillCatId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("tblStudent");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Course).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.InstitutionName).HasMaxLength(256);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.TblStudent)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStudent_tblOccupation");
            });

            modelBuilder.Entity<TblSubject>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("tblSubject");

                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.TblSubject)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSubject_tblEducation");
            });

            modelBuilder.Entity<TblTimeIn>(entity =>
            {
                entity.HasKey(e => e.TimeId);

                entity.ToTable("tblTimeIn");

                entity.Property(e => e.TimeId).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblTransportType>(entity =>
            {
                entity.HasKey(e => e.TransportId);

                entity.ToTable("tblTransportType");

                entity.Property(e => e.TransportId).ValueGeneratedNever();

                entity.Property(e => e.TransportName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TblTransUserBridge>(entity =>
            {
                entity.ToTable("tblTransUserBridge");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Transport)
                    .WithMany(p => p.TblTransUserBridge)
                    .HasForeignKey(d => d.TransportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTransUserBridge_tblTransportType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblTransUserBridge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTransUserBridge_tblUser");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUser");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.UserId).ValueGeneratedNever();

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

                entity.Property(e => e.Surname).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_tblUser_tblGender");
            });

            modelBuilder.Entity<TblUserClaim>(entity =>
            {
                entity.ToTable("tblUserClaim");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserClaim)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TblUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("tblUserLogin");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserLogin)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TblVacancy>(entity =>
            {
                entity.HasKey(e => e.VacancyId);

                entity.ToTable("tblVacancy");

                entity.Property(e => e.VacancyId).ValueGeneratedNever();

                entity.Property(e => e.DatePosted).HasColumnType("date");

                entity.Property(e => e.FilledBy).HasMaxLength(450);

                entity.Property(e => e.PostedBy).HasMaxLength(450);

                entity.Property(e => e.VacancyDescription).HasMaxLength(400);

                entity.Property(e => e.VacancyName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblVacancy)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblVacancy_tblDepartment");

                entity.HasOne(d => d.FilledByNavigation)
                    .WithMany(p => p.TblVacancyFilledByNavigation)
                    .HasForeignKey(d => d.FilledBy)
                    .HasConstraintName("FK_tblVacancy_filledBy_tblUser");

                entity.HasOne(d => d.PostedByNavigation)
                    .WithMany(p => p.TblVacancyPostedByNavigation)
                    .HasForeignKey(d => d.PostedBy)
                    .HasConstraintName("FK_tblVacancy_tblUser");
            });

            modelBuilder.Entity<TblWorkPreference>(entity =>
            {
                entity.HasKey(e => e.WorkPrefId);

                entity.ToTable("tblWorkPreference");

                entity.Property(e => e.WorkPrefId).ValueGeneratedNever();

                entity.Property(e => e.Availability)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.PrefDepartmentNavigation)
                    .WithMany(p => p.TblWorkPreference)
                    .HasForeignKey(d => d.PrefDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWorkPreference_tblDepartment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblWorkPreference)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWorkPreference_tblUser");
            });
        }
    }
}
