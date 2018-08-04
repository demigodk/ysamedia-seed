using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class User
    {
        public User()
        {
            Achievement = new HashSet<Achievement>();
            AttributeUserBridge = new HashSet<AttributeUserBridge>();
            DepartmentDepartmentLeader = new HashSet<Department>();
            DepartmentDeputyNavigation = new HashSet<Department>();
            DeptUserBrigdge = new HashSet<DeptUserBrigdge>();
            DlicenceUserBridge = new HashSet<DlicenceUserBridge>();
            Education = new HashSet<Education>();
            Language = new HashSet<Language>();
            NegAttributeUserBridge = new HashSet<NegAttributeUserBridge>();
            NextOfKin = new HashSet<NextOfKin>();
            Photo = new HashSet<Photo>();
            RateAnswerUserBridge = new HashSet<RateAnswerUserBridge>();
            ScreeningAnswer = new HashSet<ScreeningAnswer>();
            ScreeningScripture = new HashSet<ScreeningScripture>();
            Skill = new HashSet<Skill>();
            TransUserBridge = new HashSet<TransUserBridge>();
            UserClaim = new HashSet<UserClaim>();
            UserLogin = new HashSet<UserLogin>();
            VacancyFilledByNavigation = new HashSet<Vacancy>();
            VacancyPostedByNavigation = new HashSet<Vacancy>();
            WorkPreference = new HashSet<WorkPreference>();
        }

        public string UserId { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public string Discriminator { get; set; }
        public string DisplayName { get; set; }
        public DateTime? DateJoinedDept { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public int? GenderId { get; set; }
        public int Approved { get; set; }
        public bool? DriverLicence { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

        public Gender Gender { get; set; }
        public ICollection<Achievement> Achievement { get; set; }
        public ICollection<AttributeUserBridge> AttributeUserBridge { get; set; }
        public ICollection<Department> DepartmentDepartmentLeader { get; set; }
        public ICollection<Department> DepartmentDeputyNavigation { get; set; }
        public ICollection<DeptUserBrigdge> DeptUserBrigdge { get; set; }
        public ICollection<DlicenceUserBridge> DlicenceUserBridge { get; set; }
        public ICollection<Education> Education { get; set; }
        public ICollection<Language> Language { get; set; }
        public ICollection<NegAttributeUserBridge> NegAttributeUserBridge { get; set; }
        public ICollection<NextOfKin> NextOfKin { get; set; }
        public ICollection<Photo> Photo { get; set; }
        public ICollection<RateAnswerUserBridge> RateAnswerUserBridge { get; set; }
        public ICollection<ScreeningAnswer> ScreeningAnswer { get; set; }
        public ICollection<ScreeningScripture> ScreeningScripture { get; set; }
        public ICollection<Skill> Skill { get; set; }
        public ICollection<TransUserBridge> TransUserBridge { get; set; }
        public ICollection<UserClaim> UserClaim { get; set; }
        public ICollection<UserLogin> UserLogin { get; set; }
        public ICollection<Vacancy> VacancyFilledByNavigation { get; set; }
        public ICollection<Vacancy> VacancyPostedByNavigation { get; set; }
        public ICollection<WorkPreference> WorkPreference { get; set; }
    }
}
