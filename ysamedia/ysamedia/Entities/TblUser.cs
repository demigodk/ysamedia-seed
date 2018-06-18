using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblAchievement = new HashSet<TblAchievement>();
            TblAttributeUserBridge = new HashSet<TblAttributeUserBridge>();
            TblDepartment = new HashSet<TblDepartment>();
            TblDeptUserBrigdge = new HashSet<TblDeptUserBrigdge>();
            TblDlicenceUserBridge = new HashSet<TblDlicenceUserBridge>();
            TblEducation = new HashSet<TblEducation>();
            TblLanguage = new HashSet<TblLanguage>();
            TblLog = new HashSet<TblLog>();
            TblNegAttributeUserBridge = new HashSet<TblNegAttributeUserBridge>();
            TblPhoto = new HashSet<TblPhoto>();
            TblRateAnswerUserBridge = new HashSet<TblRateAnswerUserBridge>();
            TblScreeningAnswer = new HashSet<TblScreeningAnswer>();
            TblScreeningScripture = new HashSet<TblScreeningScripture>();
            TblSkill = new HashSet<TblSkill>();
            TblTransUserBridge = new HashSet<TblTransUserBridge>();
            TblUserClaim = new HashSet<TblUserClaim>();
            TblUserLogin = new HashSet<TblUserLogin>();
            TblVacancyFilledByNavigation = new HashSet<TblVacancy>();
            TblVacancyPostedByNavigation = new HashSet<TblVacancy>();
            TblWorkPreference = new HashSet<TblWorkPreference>();
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

        public TblGender Gender { get; set; }
        public ICollection<TblAchievement> TblAchievement { get; set; }
        public ICollection<TblAttributeUserBridge> TblAttributeUserBridge { get; set; }
        public ICollection<TblDepartment> TblDepartment { get; set; }
        public ICollection<TblDeptUserBrigdge> TblDeptUserBrigdge { get; set; }
        public ICollection<TblDlicenceUserBridge> TblDlicenceUserBridge { get; set; }
        public ICollection<TblEducation> TblEducation { get; set; }
        public ICollection<TblLanguage> TblLanguage { get; set; }
        public ICollection<TblLog> TblLog { get; set; }
        public ICollection<TblNegAttributeUserBridge> TblNegAttributeUserBridge { get; set; }
        public ICollection<TblPhoto> TblPhoto { get; set; }
        public ICollection<TblRateAnswerUserBridge> TblRateAnswerUserBridge { get; set; }
        public ICollection<TblScreeningAnswer> TblScreeningAnswer { get; set; }
        public ICollection<TblScreeningScripture> TblScreeningScripture { get; set; }
        public ICollection<TblSkill> TblSkill { get; set; }
        public ICollection<TblTransUserBridge> TblTransUserBridge { get; set; }
        public ICollection<TblUserClaim> TblUserClaim { get; set; }
        public ICollection<TblUserLogin> TblUserLogin { get; set; }
        public ICollection<TblVacancy> TblVacancyFilledByNavigation { get; set; }
        public ICollection<TblVacancy> TblVacancyPostedByNavigation { get; set; }
        public ICollection<TblWorkPreference> TblWorkPreference { get; set; }
    }
}
