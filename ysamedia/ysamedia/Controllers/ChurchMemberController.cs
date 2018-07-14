using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ysamedia.Classes.ChurchMemberHelper;
using ysamedia.Entities;
using ysamedia.Models.ChurchViewModels;

namespace ysamedia.Controllers
{
    [Authorize(Roles = "Administrator, Admin")]
    public class ChurchMemberController : Controller
    {
        private readonly ysamediaDbContext _context;       

        public ChurchMemberController(ysamediaDbContext context)
        {
            _context = context;           
        }

        public IList<TblChurchMember> Member { get; set; }

        public async Task ChurchMembers(string searchString)
        {
            var churchMembers = (from c in _context.ChurchMember
                                 select c);

            if (!String.IsNullOrEmpty(searchString))
            {
                churchMembers = churchMembers.Where(s => s.FirstName.Contains(searchString));
            }

            //TblChurchMember = await churchMembers.ToListAsync();
        }

        [HttpGet]
        public IActionResult MemberRegister()
        {          
            //___________________________ TblAgeGroup _____________________________
            List<AgeGroup> AgeList = new List<AgeGroup>();

            AgeList = (from a in _context.AgeGroup
                       select a).ToList();

            ViewBag.ListOfAgeGroups = AgeList;
            //_________________________ TblAgeGroup End ____________________________

            //____________________________TBLGender_________________________
            List<Gender> GenderList = new List<Gender>();

            GenderList = (from g in _context.Gender
                          select g).ToList();

            ViewBag.ListOfGenders = GenderList;
            //_____________________________ TBLGender End ______________________       
            
            //___________________________ TblRelationshipStatus _____________________________           
            List<RelationshipStatus> StatusList = new List<RelationshipStatus>();

            StatusList = (from s in _context.RelationshipStatus
                          select s).ToList();

            ViewBag.ListOfRelationships = StatusList;
            //_________________________ TblRelationshipStatus End ____________________________

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult MemberRegister(ChurchMemberViewModel model)
        {

            /******************* Code segment 1 - Insert In TblChurchMember ****************************/
            int maxMemberId = 1;
            
            if (_context.ChurchMember.Any())
            {
                maxMemberId = (_context.ChurchMember.Max(r => r.ChurchMemberId) + 1);
            }

            string dob;

            if (model.Year == 0)
            {
                dob = model.Day + "/" + model.Month;
            }
            else
            {
                dob = model.Day + "/" + model.Month + "/" + model.Year;
            }

            if (model.AGroupId == 0)
            {
                model.AGroupId = 5;             // N/A
            }

            if (model.RelationshipId == 0)
            {
                model.RelationshipId = 6;       // Unspecified
            }            

            if (model.OccupationId == 0)
            {
                model.OccupationId = 5;         // Other
            }

            model.DateRecorded = DateTime.Now;

            ChurchMember churchMember = new ChurchMember
            {
                    ChurchMemberId = maxMemberId,
                    FirstName = model.FirstName,                   
                    LastName = model.Surname,
                    DateOfBirth = dob,
                    CellPhone = model.CellNumber,
                    HomePhone = model.HomeNumber,
                    WorkPhone = model.WorkNumber,
                    Email = model.EmailAddress,
                    Street = model.Street,
                    City = model.City,
                    Province = model.Province,
                    PostalCode = model.PostalCode,
                    DateRegistered = model.DateRecorded,
                    AgeGroupId = model.AGroupId,
                    RelationshipId = model.RelationshipId,
                    GenderId = model.GenderId
            };
            _context.ChurchMember.Add(churchMember);
            _context.SaveChanges();


            /******************* Code Segment - Insert In tblDependant ********************************/

            int maxDependantId = 1;
           
            if (_context.Dependant.Any())
            {
                maxDependantId = (_context.Dependant.Max(d => d.DependantId) + 1);                
            }

            _context.Dependant.AddRange(
                new Dependant { DependantId = maxDependantId, ChurchMemberId = maxMemberId, NumDependant = Convert.ToInt32(model.NumPreschool), DependantCategoryId = 1 },
                new Dependant { DependantId = (maxDependantId + 1), ChurchMemberId = maxMemberId, NumDependant = Convert.ToInt32(model.NumPreschool), DependantCategoryId = 2 },
                new Dependant { DependantId = (maxDependantId + 2), ChurchMemberId = maxMemberId, NumDependant = Convert.ToInt32(model.NumPreschool), DependantCategoryId = 3 },
                new Dependant { DependantId = (maxDependantId + 3), ChurchMemberId = maxMemberId, NumDependant = Convert.ToInt32(model.NumPreschool), DependantCategoryId = 4 }
             );
            _context.SaveChanges();
                    
            /******************* Code segment 2 - Insert In TblChurchMemberOccupationBrigde **********/
            int maxID = 1;

            if (_context.ChurchMemberOccupationBridge.Any())
            {
                maxID = _context.ChurchMemberOccupationBridge.Max(c => c.Id);
            }

            ChurchMemberOccupationBridge churchMemberOccupationBridge = new ChurchMemberOccupationBridge
            {
                Id = ( maxID + 1),
                ChurchMemberId = maxMemberId,
                OccupationId = model.OccupationId
            };
            _context.ChurchMemberOccupationBridge.Add(churchMemberOccupationBridge);
            _context.SaveChanges();

            /******************* Code segment 2 - Insert In TblAnswer ********************************/
            int maxAnswerId = 1;
            
            if (_context.Answer.Any())
            {
                maxAnswerId = _context.Answer.Max(a => a.AnswerId);
            }

            Answer answer1 = new Answer
            {
                AnswerId = (maxAnswerId + 1),
                Answer1 = model.Question1,
                QuestionId = 1,
                ChurchMemberId = maxMemberId
            };
            _context.Answer.Add(answer1);
            _context.SaveChanges();

            Answer answer2 = new Answer
            {
                AnswerId = (maxAnswerId + 2),
                Answer1 = model.Question2,
                QuestionId = 2,
                ChurchMemberId = maxMemberId
            };
            _context.Answer.Add(answer2);
            _context.SaveChanges();

            Answer answer3 = new Answer
            {
                AnswerId = (maxAnswerId + 3),
                Answer1 = model.Question3,
                QuestionId = 3,
                ChurchMemberId = maxMemberId
            };
            _context.Answer.Add(answer3);
            _context.SaveChanges();

            Answer answer4 = new Answer
            {
                AnswerId = (maxAnswerId + 4),
                Answer1 = model.Question4,
                QuestionId = 4,
                ChurchMemberId = maxMemberId
            };
            _context.Answer.Add(answer4);
            _context.SaveChanges();

            Answer answer5 = new Answer
            {
                AnswerId = (maxAnswerId + 5),
                Answer1 = model.Question5,
                QuestionId = 5,
                ChurchMemberId = maxMemberId
            };
            _context.Answer.Add(answer5);
            _context.SaveChanges();

            Answer answer6 = new Answer
            {
                AnswerId = (maxAnswerId + 6),
                Answer1 = model.Question6,
                QuestionId = 6,
                ChurchMemberId = maxMemberId
            };
            _context.Answer.Add(answer6);
            _context.SaveChanges();



            MemberHelper memberHelper = new MemberHelper(_context);
            
            return RedirectToAction("ChurchMemberInfo", memberHelper.getViewModel(maxMemberId));            
        }

        public IActionResult ChurchMemberInfo(CompleteViewModel model)
        {            
            return View(model);
        }        
    }
}
