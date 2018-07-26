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

        public IList<ChurchMember> Member { get; set; }

        public async Task ChurchMembers(string searchString)
        {
            var churchMembers = (from c in _context.ChurchMember
                                 select c);

            if (!String.IsNullOrEmpty(searchString))
            {
                churchMembers = churchMembers.Where(s => s.FirstName.Contains(searchString));
            }

            //ChurchMember = await churchMembers.ToListAsync();
        }

        [HttpGet]
        public IActionResult MemberRegister()
        {          
            //___________________________ AgeGroup _____________________________
            List<AgeGroup> AgeList = new List<AgeGroup>();

            AgeList = (from a in _context.AgeGroup
                       select a).ToList();

            ViewBag.ListOfAgeGroups = AgeList;
            //_________________________ AgeGroup End ____________________________

            //____________________________Gender_________________________
            List<Gender> GenderList = new List<Gender>();

            GenderList = (from g in _context.Gender
                          select g).ToList();

            ViewBag.ListOfGenders = GenderList;
            //_____________________________ Gender End ______________________       
            
            //___________________________ RelationshipStatus _____________________________           
            List<RelationshipStatus> StatusList = new List<RelationshipStatus>();

            StatusList = (from s in _context.RelationshipStatus
                          select s).ToList();

            ViewBag.ListOfRelationships = StatusList;
            //_________________________ RelationshipStatus End ____________________________

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult MemberRegister(ChurchMemberViewModel model)
        {

            /******************* Code segment 1 - Insert In ChurchMember ****************************/            
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
                    FirstName = model.FirstName,                   
                    LastName = model.Surname,
                    //DateOfBirth = dob,
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
                                           
            MemberHelper memberHelper = new MemberHelper(_context);

            //return RedirectToAction("ChurchMemberInfo", memberHelper.getViewModel(maxMemberId));            
            return View();
        }

        public IActionResult ChurchMemberInfo(int id)
        {
            MemberHelper memberHelper = new MemberHelper(_context);
            return View(memberHelper.getViewModel(id));
        }        
    }
}
