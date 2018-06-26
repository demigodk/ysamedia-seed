using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using ysamedia.Entities;
using ysamedia.Models;

/// <summary>
/// @author         :   Bondo Kalombo
/// @date           :   20-06-2018
/// 
/// This class seeds the database with needed startup information.
/// </summary>
namespace ysamedia.Data
{
    public static class DbInitializer 
    {       
        // Creates an Admin role and one Admin user
        public static async Task InitializeAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            // create database schema if none exists
            context.Database.EnsureCreated();

            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Administrator", "Admin", "Member", "Guest" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create the default Admin account and apply the Admin role
            string firstName = "YSM";
            string surname = "Admin";
            string email = "ysmadmin@gmail.com";
            int genderId = 1;
            string password = "P0dC@5tYSM";
            int day = 10;
            int month = 10;
            int year = 2000;            
                                    
            var user = new ApplicationUser
            {
                FirstName = firstName,
                Surname = surname,
                DisplayName = firstName + " " + surname,
                UserName = email,
                Email = email,
                Approved = 1,
                GenderId = genderId,
                DateOfBirth = new DateTime(year, month, day, 0, 0, 0)
            };

            var result = await _userManager.CreateAsync(user, password);            
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(email), "Admin");
       
            using (var ysmcontext = new ysamediaDbContext(serviceProvider.GetRequiredService<DbContextOptions<ysamediaDbContext>>()))
            {

                if (!ysmcontext.TblQuestion.Any())
                {
                    /**************** Seed tblQuestion Table *******************/
                    ysmcontext.TblQuestion.AddRange(

                       new TblQuestion { QuestionId = 1, Question = "In which denomination or church do you belong to?" },
                       new TblQuestion { QuestionId = 2, Question = "What brought you here to Yahweh Shamma Assembly?" },
                       new TblQuestion { QuestionId = 3, Question = "Have you been baptized?" },
                       new TblQuestion { QuestionId = 4, Question = "When were you baptized?" },
                       new TblQuestion { QuestionId = 5, Question = "Would you please give some comment about the service that you have just attended?" },
                       new TblQuestion { QuestionId = 6, Question = "Would you like to follow some teachings and become a member at our community?" }
                    );

                    ysmcontext.SaveChanges();
                }

               if (!ysmcontext.TblTimeIn.Any())
                {
                    ysmcontext.TblTimeIn.AddRange(

                        new TblTimeIn { TimeId = 1, Category = "Before 08:00 AM", TimeCount = 0 },
                        new TblTimeIn { TimeId = 2, Category = "Before 08:15 AM", TimeCount = 0 },
                        new TblTimeIn { TimeId = 3, Category = "Before 08:30 AM", TimeCount = 0 },
                        new TblTimeIn { TimeId = 4, Category = "After 08:30  AM", TimeCount = 0},
                        new TblTimeIn { TimeId = 5, Category = "Absent", TimeCount = 0}
                    );

                    ysmcontext.SaveChanges();
               }

                if (!ysmcontext.TblGender.Any())
                {
                    /***************** Seed tblGender Table ********************/
                    ysmcontext.TblGender.AddRange(
                    new TblGender { GenderId = 1, Gname = "Male" },
                    new TblGender { GenderId = 2, Gname = "Female" });

                    ysmcontext.SaveChanges();

                }

                if (!ysmcontext.TblAgeGroup.Any())
                {
                    /***************** Seed tblAgeGroup Table ********************/
                    ysmcontext.TblAgeGroup.AddRange(
                        new TblAgeGroup { AgroupId = 1, AgeRange = "18-25" },
                        new TblAgeGroup { AgroupId = 2, AgeRange = "26-35" },
                        new TblAgeGroup { AgroupId = 3, AgeRange = "36-50" },
                        new TblAgeGroup { AgroupId = 4, AgeRange = "51-75" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblDepartment.Any())
                {
                    /***************** Seed tblDepartment Table ********************/
                    ysmcontext.TblDepartment.AddRange(
                        new TblDepartment { DepartmentId = 1, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Lights" },
                        new TblDepartment { DepartmentId = 2, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Camera" },
                        new TblDepartment { DepartmentId = 3, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Social Media" },
                        new TblDepartment { DepartmentId = 4, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "CD Production" },
                        new TblDepartment { DepartmentId = 5, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Switching" },
                        new TblDepartment { DepartmentId = 6, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Photography" },
                        new TblDepartment { DepartmentId = 7, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Design" },
                        new TblDepartment { DepartmentId = 8, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Book Shop" },
                        new TblDepartment { DepartmentId = 9, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Journalism" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblRelationshipStatus.Any())
                {
                    /***************** Seed tblRelationshipStatus Table ********************/
                    ysmcontext.TblRelationshipStatus.AddRange(
                    new TblRelationshipStatus { RelationshipId = 1, RelationshipCategory = "Single" },
                    new TblRelationshipStatus { RelationshipId = 2, RelationshipCategory = "Engaged" },
                    new TblRelationshipStatus { RelationshipId = 3, RelationshipCategory = "Married" },
                    new TblRelationshipStatus { RelationshipId = 4, RelationshipCategory = "Widow" },
                    new TblRelationshipStatus { RelationshipId = 5, RelationshipCategory = "Widower" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblTransportType.Any())
                {
                    /***************** Seed tblTransportType Table ********************/
                    ysmcontext.TblTransportType.AddRange(
                        new TblTransportType { TransportId = 1, TransportName = "Own Transport" },
                        new TblTransportType { TransportId = 2, TransportName = "Public Transport" },
                        new TblTransportType { TransportId = 3, TransportName = "Family Transport" },
                        new TblTransportType { TransportId = 4, TransportName = "Walking Distance" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblDriverLicence.Any())
                {
                    /***************** Seed tblDriverLicence Table ********************/
                    ysmcontext.TblDriverLicence.AddRange(
                        new TblDriverLicence { LicenceId = 1, LicenceCode = "A1" },
                        new TblDriverLicence { LicenceId = 2, LicenceCode = "A" },
                        new TblDriverLicence { LicenceId = 3, LicenceCode = "B" },
                        new TblDriverLicence { LicenceId = 4, LicenceCode = "EB" },
                        new TblDriverLicence { LicenceId = 5, LicenceCode = "C1" },
                        new TblDriverLicence { LicenceId = 6, LicenceCode = "C" },
                        new TblDriverLicence { LicenceId = 7, LicenceCode = "EC1" },
                        new TblDriverLicence { LicenceId = 8, LicenceCode = "EC" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblDependantCategory.Any())
                {
                    /***************** Seed tblDependantCategory Table ********************/
                    ysmcontext.TblDependantCategory.AddRange(
                        new TblDependantCategory { CategoryId = 1, CategoryName = "Pre-School", DependantId = null, CategoryCount = 0 },
                        new TblDependantCategory { CategoryId = 2, CategoryName = "Primary", DependantId = null, CategoryCount = 0 },
                        new TblDependantCategory { CategoryId = 3, CategoryName = "High School", DependantId = null, CategoryCount = 0 },
                        new TblDependantCategory { CategoryId = 4, CategoryName = "Tertiary", DependantId = null, CategoryCount = 0 });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblAttribute.Any())
                {
                    /***************** Seed tblAttribute Table ********************/
                    ysmcontext.TblAttribute.AddRange(
                        new TblAttribute { AttributeId = 1, AttributeName = "Outgoing (People Person)" },
                        new TblAttribute { AttributeId = 2, AttributeName = "Reserved (Shy)" },
                        new TblAttribute { AttributeId = 3, AttributeName = "Innovative" },
                        new TblAttribute { AttributeId = 4, AttributeName = "Confrontational" },
                        new TblAttribute { AttributeId = 5, AttributeName = "Assertive" },
                        new TblAttribute { AttributeId = 6, AttributeName = "Outspoken" },
                        new TblAttribute { AttributeId = 7, AttributeName = "Confident" },
                        new TblAttribute { AttributeId = 8, AttributeName = "Analytical" },
                        new TblAttribute { AttributeId = 9, AttributeName = "Creative" },
                        new TblAttribute { AttributeId = 10, AttributeName = "Persistent" },
                        new TblAttribute { AttributeId = 11, AttributeName = "Submissive" },
                        new TblAttribute { AttributeId = 12, AttributeName = "Considerate" },
                        new TblAttribute { AttributeId = 13, AttributeName = "Planner" },
                        new TblAttribute { AttributeId = 14, AttributeName = "Orderly" },
                        new TblAttribute { AttributeId = 15, AttributeName = "Daring" },
                        new TblAttribute { AttributeId = 16, AttributeName = "Cheerful" },
                        new TblAttribute { AttributeId = 17, AttributeName = "Demonstrative" },
                        new TblAttribute { AttributeId = 18, AttributeName = "Mediator" },
                        new TblAttribute { AttributeId = 19, AttributeName = "Thoughtful" },
                        new TblAttribute { AttributeId = 20, AttributeName = "Listener" },
                        new TblAttribute { AttributeId = 21, AttributeName = "Perfectionist" },
                        new TblAttribute { AttributeId = 22, AttributeName = "Playful" },
                        new TblAttribute { AttributeId = 23, AttributeName = "Patient" },
                        new TblAttribute { AttributeId = 24, AttributeName = "Spontaneous" },
                        new TblAttribute { AttributeId = 25, AttributeName = "Diplomatic" },
                        new TblAttribute { AttributeId = 26, AttributeName = "Independent" },
                        new TblAttribute { AttributeId = 27, AttributeName = "Decisive" },
                        new TblAttribute { AttributeId = 28, AttributeName = "Scheduled" },
                        new TblAttribute { AttributeId = 29, AttributeName = "Diplomatic" },
                        new TblAttribute { AttributeId = 30, AttributeName = "Mover" },
                        new TblAttribute { AttributeId = 31, AttributeName = "Leader" },
                        new TblAttribute { AttributeId = 32, AttributeName = "Analytical" },
                        new TblAttribute { AttributeId = 33, AttributeName = "Strong Willed" },
                        new TblAttribute { AttributeId = 34, AttributeName = "Convincing" },
                        new TblAttribute { AttributeId = 35, AttributeName = "Resourceful" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblScreeningQuestion.Any())
                {
                    /***************** Seed tblScreeningQuestion Table ********************/
                    ysmcontext.TblScreeningQuestion.AddRange(
                        new TblScreeningQuestion { QuestionId = 1, Question = "In your own words, what is the role of the church’s media department?" },
                        new TblScreeningQuestion { QuestionId = 2, Question = "What kind of influence do you think a media department has on the church?" },
                        new TblScreeningQuestion { QuestionId = 3, Question = "Are media members supposed to carry themselves in a specific manner?" },
                        new TblScreeningQuestion { QuestionId = 4, Question = "What is your understanding of being a servant of God?" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblNegativeAttribute.Any())
                {
                    /***************** Seed tblNegativeAttribute Table ********************/
                    ysmcontext.TblNegativeAttribute.AddRange(
                        new TblNegativeAttribute { AttributeId = 1, Attribute = "Arrogant" },
                        new TblNegativeAttribute { AttributeId = 2, Attribute = "Undisciplined" },
                        new TblNegativeAttribute { AttributeId = 3, Attribute = "Impatient" },
                        new TblNegativeAttribute { AttributeId = 4, Attribute = "Headstrong" },
                        new TblNegativeAttribute { AttributeId = 5, Attribute = "Angered easily" },
                        new TblNegativeAttribute { AttributeId = 6, Attribute = "Naive" },
                        new TblNegativeAttribute { AttributeId = 7, Attribute = "Worrier" },
                        new TblNegativeAttribute { AttributeId = 8, Attribute = "Too sensitive" },
                        new TblNegativeAttribute { AttributeId = 9, Attribute = "Doubtful" },
                        new TblNegativeAttribute { AttributeId = 10, Attribute = "Inconsistent" },
                        new TblNegativeAttribute { AttributeId = 11, Attribute = "Slow" },
                        new TblNegativeAttribute { AttributeId = 12, Attribute = "Sluggish" },
                        new TblNegativeAttribute { AttributeId = 13, Attribute = "Unsympathetic" },
                        new TblNegativeAttribute { AttributeId = 14, Attribute = "Pessimistic" },
                        new TblNegativeAttribute { AttributeId = 15, Attribute = "Withdrawn" },
                        new TblNegativeAttribute { AttributeId = 16, Attribute = "Disorganized" },
                        new TblNegativeAttribute { AttributeId = 17, Attribute = "Unpuntual" },
                        new TblNegativeAttribute { AttributeId = 18, Attribute = "Critical" },
                        new TblNegativeAttribute { AttributeId = 19, Attribute = "Competitive" },
                        new TblNegativeAttribute { AttributeId = 20, Attribute = "Indecisive" },
                        new TblNegativeAttribute { AttributeId = 21, Attribute = "Proud" },
                        new TblNegativeAttribute { AttributeId = 22, Attribute = "Argumentative" },
                        new TblNegativeAttribute { AttributeId = 23, Attribute = "Domineering" },
                        new TblNegativeAttribute { AttributeId = 24, Attribute = "Intolerant" },
                        new TblNegativeAttribute { AttributeId = 25, Attribute = "Show-off" },
                        new TblNegativeAttribute { AttributeId = 26, Attribute = "Lazy" },
                        new TblNegativeAttribute { AttributeId = 27, Attribute = "Reluctant" },
                        new TblNegativeAttribute { AttributeId = 28, Attribute = "Unforgiving" },
                        new TblNegativeAttribute { AttributeId = 29, Attribute = "Wants credit" },
                        new TblNegativeAttribute { AttributeId = 30, Attribute = "Indifferent" },
                        new TblNegativeAttribute { AttributeId = 31, Attribute = "Manipulative" },
                        new TblNegativeAttribute { AttributeId = 32, Attribute = "Procrastinator" },
                        new TblNegativeAttribute { AttributeId = 33, Attribute = "Too soft" },
                        new TblNegativeAttribute { AttributeId = 34, Attribute = "Judgemental" },
                        new TblNegativeAttribute { AttributeId = 35, Attribute = "Does not like authority" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TblRatingQuestion.Any())
                {
                    /***************** Seed tblRatingQuestion Table ********************/
                    ysmcontext.TblRatingQuestion.AddRange(
                        new TblRatingQuestion { QuestionId = 1, Question = "A group should always have shared vision and goals" },
                        new TblRatingQuestion { QuestionId = 2, Question = "Every members needs and wants should be met in the group" },
                        new TblRatingQuestion { QuestionId = 3, Question = "Everyone should be heard and every idea should be taken into consideration" },
                        new TblRatingQuestion { QuestionId = 4, Question = "Teams are best run when there is a culture of democracy" },
                        new TblRatingQuestion { QuestionId = 5, Question = "People should only be given tasks they want to do" },
                        new TblRatingQuestion { QuestionId = 6, Question = "Nothing should be done without go ahead from person in charge" },
                        new TblRatingQuestion { QuestionId = 7, Question = "Getting along with every team member is an absolute must" },
                        new TblRatingQuestion { QuestionId = 8, Question = "A member should always stand their ground and MUST be heard" },
                        new TblRatingQuestion { QuestionId = 9, Question = "Every problem/issue addressed in a team should be addressed" },
                        new TblRatingQuestion { QuestionId = 10, Question = "Every team member is a leader and should be an example" },
                        new TblRatingQuestion { QuestionId = 11, Question = "There should be zero tolerance of members who don’t pull their weight" },
                        new TblRatingQuestion { QuestionId = 12, Question = "Team building is crucial to running a successful department" },
                        new TblRatingQuestion { QuestionId = 13, Question = "Training and upscaling of skills should be number priority in a team" },
                        new TblRatingQuestion { QuestionId = 14, Question = "Successful team members have a responsibility towards those not doing so well" },
                        new TblRatingQuestion { QuestionId = 15, Question = "All members should suffer consequences of one members mistakes" },
                        new TblRatingQuestion { QuestionId = 16, Question = "A team is accountable to its leaders" });

                    ysmcontext.SaveChanges();
                }
            }
        }
    }
}
