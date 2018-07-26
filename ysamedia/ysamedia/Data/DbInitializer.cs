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
                if (!ysmcontext.Occupation.Any())
                {
                    /*************** Seed Occupation Table *******************/
                    ysmcontext.Occupation.AddRange(

                    new Occupation { OccupationId = 1, Occupation1 = "Student" },
                    new Occupation { OccupationId = 2, Occupation1 = "Internship" },
                    new Occupation { OccupationId = 3, Occupation1 = "Employed" },
                    new Occupation { OccupationId = 4, Occupation1 = "Self-Employed" },                   
                    new Occupation { OccupationId = 5, Occupation1 = "Other" }

                    );
                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TimeIn.Any())
                {
                    ysmcontext.TimeIn.AddRange(

                        new TimeIn { TimeId = 1, Category = "Before 08:00 AM", TimeCount = 0 },
                        new TimeIn { TimeId = 2, Category = "Before 08:15 AM", TimeCount = 0 },
                        new TimeIn { TimeId = 3, Category = "Before 08:30 AM", TimeCount = 0 },
                        new TimeIn { TimeId = 4, Category = "After 08:30  AM", TimeCount = 0},
                        new TimeIn { TimeId = 5, Category = "Absent", TimeCount = 0}
                    );

                    ysmcontext.SaveChanges();
               }

                if (!ysmcontext.Gender.Any())
                {
                    /***************** Seed Gender Table ********************/
                    ysmcontext.Gender.AddRange(
                    new Gender { GenderId = 1, Gname = "Male" },
                    new Gender { GenderId = 2, Gname = "Female" });

                    ysmcontext.SaveChanges();

                }

                if (!ysmcontext.AgeGroup.Any())
                {
                    /***************** Seed AgeGroup Table ********************/
                    ysmcontext.AgeGroup.AddRange(
                        new AgeGroup { AgroupId = 1, AgeRange = "18-25" },
                        new AgeGroup { AgroupId = 2, AgeRange = "26-35" },
                        new AgeGroup { AgroupId = 3, AgeRange = "36-50" },
                        new AgeGroup { AgroupId = 4, AgeRange = "51-75" },
                        new AgeGroup { AgroupId = 5, AgeRange = "N/A" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.Department.Any())
                {
                    /***************** Seed Department Table ********************/
                    ysmcontext.Department.AddRange(
                        new Department { DepartmentId = 1, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Lights" },
                        new Department { DepartmentId = 2, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Camera" },
                        new Department { DepartmentId = 3, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Social Media" },
                        new Department { DepartmentId = 4, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "CD Production" },
                        new Department { DepartmentId = 5, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Switching" },
                        new Department { DepartmentId = 6, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Photography" },
                        new Department { DepartmentId = 7, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Design" },
                        new Department { DepartmentId = 8, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Book Shop" },
                        new Department { DepartmentId = 9, DepartmentLeaderId = null, NumMembers = 0, DepartmentName = "Journalism" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.RelationshipStatus.Any())
                {
                    /***************** Seed RelationshipStatus Table ********************/
                    ysmcontext.RelationshipStatus.AddRange(
                    new RelationshipStatus { RelationshipId = 1, RelationshipCategory = "Single" },
                    new RelationshipStatus { RelationshipId = 2, RelationshipCategory = "Engaged" },
                    new RelationshipStatus { RelationshipId = 3, RelationshipCategory = "Married" },
                    new RelationshipStatus { RelationshipId = 4, RelationshipCategory = "Widow" },
                    new RelationshipStatus { RelationshipId = 5, RelationshipCategory = "Widower" },
                    new RelationshipStatus { RelationshipId = 6, RelationshipCategory = "Unspecified" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.TransportType.Any())
                {
                    /***************** Seed TransportType Table ********************/
                    ysmcontext.TransportType.AddRange(
                        new TransportType { TransportId = 1, TransportName = "Own Transport" },
                        new TransportType { TransportId = 2, TransportName = "Public Transport" },
                        new TransportType { TransportId = 3, TransportName = "Family Transport" },
                        new TransportType { TransportId = 4, TransportName = "Walking Distance" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.DriverLicence.Any())
                {
                    /***************** Seed DriverLicence Table ********************/
                    ysmcontext.DriverLicence.AddRange(
                        new DriverLicence { LicenceId = 1, LicenceCode = "A1" },
                        new DriverLicence { LicenceId = 2, LicenceCode = "A" },
                        new DriverLicence { LicenceId = 3, LicenceCode = "B" },
                        new DriverLicence { LicenceId = 4, LicenceCode = "EB" },
                        new DriverLicence { LicenceId = 5, LicenceCode = "C1" },
                        new DriverLicence { LicenceId = 6, LicenceCode = "C" },
                        new DriverLicence { LicenceId = 7, LicenceCode = "EC1" },
                        new DriverLicence { LicenceId = 8, LicenceCode = "EC" });

                    ysmcontext.SaveChanges();
                }                

                if (!ysmcontext.PositiveAttribute.Any())
                {
                    /***************** Seed Attribute Table ********************/
                    ysmcontext.PositiveAttribute.AddRange(
                        new PositiveAttribute { AttributeId = 1, AttributeName = "Outgoing (People Person)" },
                        new PositiveAttribute { AttributeId = 2, AttributeName = "Reserved (Shy)" },
                        new PositiveAttribute { AttributeId = 3, AttributeName = "Innovative" },
                        new PositiveAttribute { AttributeId = 4, AttributeName = "Confrontational" },
                        new PositiveAttribute { AttributeId = 5, AttributeName = "Assertive" },
                        new PositiveAttribute { AttributeId = 6, AttributeName = "Outspoken" },
                        new PositiveAttribute { AttributeId = 7, AttributeName = "Confident" },
                        new PositiveAttribute { AttributeId = 8, AttributeName = "Analytical" },
                        new PositiveAttribute { AttributeId = 9, AttributeName = "Creative" },
                        new PositiveAttribute { AttributeId = 10, AttributeName = "Persistent" },
                        new PositiveAttribute { AttributeId = 11, AttributeName = "Submissive" },
                        new PositiveAttribute { AttributeId = 12, AttributeName = "Considerate" },
                        new PositiveAttribute { AttributeId = 13, AttributeName = "Planner" },
                        new PositiveAttribute { AttributeId = 14, AttributeName = "Orderly" },
                        new PositiveAttribute { AttributeId = 15, AttributeName = "Daring" },
                        new PositiveAttribute { AttributeId = 16, AttributeName = "Cheerful" },
                        new PositiveAttribute { AttributeId = 17, AttributeName = "Demonstrative" },
                        new PositiveAttribute { AttributeId = 18, AttributeName = "Mediator" },
                        new PositiveAttribute { AttributeId = 19, AttributeName = "Thoughtful" },
                        new PositiveAttribute { AttributeId = 20, AttributeName = "Listener" },
                        new PositiveAttribute { AttributeId = 21, AttributeName = "Perfectionist" },
                        new PositiveAttribute { AttributeId = 22, AttributeName = "Playful" },
                        new PositiveAttribute { AttributeId = 23, AttributeName = "Patient" },
                        new PositiveAttribute { AttributeId = 24, AttributeName = "Spontaneous" },
                        new PositiveAttribute { AttributeId = 25, AttributeName = "Diplomatic" },
                        new PositiveAttribute { AttributeId = 26, AttributeName = "Independent" },
                        new PositiveAttribute { AttributeId = 27, AttributeName = "Decisive" },
                        new PositiveAttribute { AttributeId = 28, AttributeName = "Scheduled" },
                        new PositiveAttribute { AttributeId = 29, AttributeName = "Diplomatic" },
                        new PositiveAttribute { AttributeId = 30, AttributeName = "Mover" },
                        new PositiveAttribute { AttributeId = 31, AttributeName = "Leader" },
                        new PositiveAttribute { AttributeId = 32, AttributeName = "Analytical" },
                        new PositiveAttribute { AttributeId = 33, AttributeName = "Strong Willed" },
                        new PositiveAttribute { AttributeId = 34, AttributeName = "Convincing" },
                        new PositiveAttribute { AttributeId = 35, AttributeName = "Resourceful" }
                        );

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.ScreeningQuestion.Any())
                {
                    /***************** Seed ScreeningQuestion Table ********************/
                    ysmcontext.ScreeningQuestion.AddRange(
                        new ScreeningQuestion { QuestionId = 1, Question = "In your own words, what is the role of the church’s media department?" },
                        new ScreeningQuestion { QuestionId = 2, Question = "What kind of influence do you think a media department has on the church?" },
                        new ScreeningQuestion { QuestionId = 3, Question = "Are media members supposed to carry themselves in a specific manner?" },
                        new ScreeningQuestion { QuestionId = 4, Question = "What is your understanding of being a servant of God?" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.NegativeAttribute.Any())
                {
                    /***************** Seed NegativeAttribute Table ********************/
                    ysmcontext.NegativeAttribute.AddRange(
                        new NegativeAttribute { AttributeId = 1, Attribute = "Arrogant" },
                        new NegativeAttribute { AttributeId = 2, Attribute = "Undisciplined" },
                        new NegativeAttribute { AttributeId = 3, Attribute = "Impatient" },
                        new NegativeAttribute { AttributeId = 4, Attribute = "Headstrong" },
                        new NegativeAttribute { AttributeId = 5, Attribute = "Angered easily" },
                        new NegativeAttribute { AttributeId = 6, Attribute = "Naive" },
                        new NegativeAttribute { AttributeId = 7, Attribute = "Worrier" },
                        new NegativeAttribute { AttributeId = 8, Attribute = "Too sensitive" },
                        new NegativeAttribute { AttributeId = 9, Attribute = "Doubtful" },
                        new NegativeAttribute { AttributeId = 10, Attribute = "Inconsistent" },
                        new NegativeAttribute { AttributeId = 11, Attribute = "Slow" },
                        new NegativeAttribute { AttributeId = 12, Attribute = "Sluggish" },
                        new NegativeAttribute { AttributeId = 13, Attribute = "Unsympathetic" },
                        new NegativeAttribute { AttributeId = 14, Attribute = "Pessimistic" },
                        new NegativeAttribute { AttributeId = 15, Attribute = "Withdrawn" },
                        new NegativeAttribute { AttributeId = 16, Attribute = "Disorganized" },
                        new NegativeAttribute { AttributeId = 17, Attribute = "Unpuntual" },
                        new NegativeAttribute { AttributeId = 18, Attribute = "Critical" },
                        new NegativeAttribute { AttributeId = 19, Attribute = "Competitive" },
                        new NegativeAttribute { AttributeId = 20, Attribute = "Indecisive" },
                        new NegativeAttribute { AttributeId = 21, Attribute = "Proud" },
                        new NegativeAttribute { AttributeId = 22, Attribute = "Argumentative" },
                        new NegativeAttribute { AttributeId = 23, Attribute = "Domineering" },
                        new NegativeAttribute { AttributeId = 24, Attribute = "Intolerant" },
                        new NegativeAttribute { AttributeId = 25, Attribute = "Show-off" },
                        new NegativeAttribute { AttributeId = 26, Attribute = "Lazy" },
                        new NegativeAttribute { AttributeId = 27, Attribute = "Reluctant" },
                        new NegativeAttribute { AttributeId = 28, Attribute = "Unforgiving" },
                        new NegativeAttribute { AttributeId = 29, Attribute = "Wants credit" },
                        new NegativeAttribute { AttributeId = 30, Attribute = "Indifferent" },
                        new NegativeAttribute { AttributeId = 31, Attribute = "Manipulative" },
                        new NegativeAttribute { AttributeId = 32, Attribute = "Procrastinator" },
                        new NegativeAttribute { AttributeId = 33, Attribute = "Too soft" },
                        new NegativeAttribute { AttributeId = 34, Attribute = "Judgemental" },
                        new NegativeAttribute { AttributeId = 35, Attribute = "Does not like authority" });

                    ysmcontext.SaveChanges();
                }

                if (!ysmcontext.RatingQuestion.Any())
                {
                    /***************** Seed RatingQuestion Table ********************/
                    ysmcontext.RatingQuestion.AddRange(
                        new RatingQuestion { QuestionId = 1, Question = "A group should always have shared vision and goals" },
                        new RatingQuestion { QuestionId = 2, Question = "Every members needs and wants should be met in the group" },
                        new RatingQuestion { QuestionId = 3, Question = "Everyone should be heard and every idea should be taken into consideration" },
                        new RatingQuestion { QuestionId = 4, Question = "Teams are best run when there is a culture of democracy" },
                        new RatingQuestion { QuestionId = 5, Question = "People should only be given tasks they want to do" },
                        new RatingQuestion { QuestionId = 6, Question = "Nothing should be done without go ahead from person in charge" },
                        new RatingQuestion { QuestionId = 7, Question = "Getting along with every team member is an absolute must" },
                        new RatingQuestion { QuestionId = 8, Question = "A member should always stand their ground and MUST be heard" },
                        new RatingQuestion { QuestionId = 9, Question = "Every problem/issue addressed in a team should be addressed" },
                        new RatingQuestion { QuestionId = 10, Question = "Every team member is a leader and should be an example" },
                        new RatingQuestion { QuestionId = 11, Question = "There should be zero tolerance of members who don’t pull their weight" },
                        new RatingQuestion { QuestionId = 12, Question = "Team building is crucial to running a successful department" },
                        new RatingQuestion { QuestionId = 13, Question = "Training and upscaling of skills should be number priority in a team" },
                        new RatingQuestion { QuestionId = 14, Question = "Successful team members have a responsibility towards those not doing so well" },
                        new RatingQuestion { QuestionId = 15, Question = "All members should suffer consequences of one members mistakes" },
                        new RatingQuestion { QuestionId = 16, Question = "A team is accountable to its leaders" });

                    ysmcontext.SaveChanges();
                }               
            }
        }
    }
}
