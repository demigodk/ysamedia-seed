using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ysamedia.Entities;
using ysamedia.Models.ChurchMembersViewModels;

namespace ysamedia.Controllers
{
    [Authorize(Roles = "Administrator, Admin")]
    public class ChurchMembersController : Controller
    {
        private readonly ysamediaDbContext _context;

        public ChurchMembersController(ysamediaDbContext context)
        {
            _context = context;
        }

        [HttpGet]// GET: ChurchMembers
        public async Task<IActionResult> Index()
        {
            var ysamediaDbContext = _context.ChurchMember.Include(c => c.AgeGroup).Include(c => c.Gender).Include(c => c.Occupation).Include(c => c.Relationship);           
            return View(await ysamediaDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMember
                .Include(c => c.AgeGroup)
                .Include(c => c.Gender)
                .Include(c => c.Occupation)
                .Include(c => c.Relationship)
                .SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            if (churchMember == null)
            {
                return NotFound();
            }
            
            ChurchMembersViewModel viewModel = new ChurchMembersViewModel
            {
                ChurchMemberId = churchMember.ChurchMemberId,
                FirstName = churchMember.FirstName,
                LastName = churchMember.LastName,
                DateOfBirth = churchMember.DateOfBirth,
                Month = churchMember.Month,
                Year = churchMember.Year,
                Day = churchMember.Day,
                CellPhone = churchMember.CellPhone,
                HomePhone = churchMember.HomePhone,
                WorkPhone = churchMember.WorkPhone,
                Email = churchMember.Email,
                DateRegistered = churchMember.DateRegistered,
                AgeGroupId = churchMember.AgeGroupId,
                RelationshipId = churchMember.RelationshipId,
                GenderId = churchMember.GenderId,
                Street = churchMember.Street,
                City = churchMember.City,
                Province = churchMember.Province,
                PostalCode = churchMember.PostalCode,
                OccupationId = churchMember.OccupationId,
                NumDepInPreSchool = churchMember.NumDepInPreSchool,
                NumDepInPrimary = churchMember.NumDepInPrimary,
                NumDepInHighSchool = churchMember.NumDepInHighSchool,
                NumDepInTertiary = churchMember.NumDepInTertiary,
                AnswerToQ1 = churchMember.AnswerToQ1,
                AnswerToQ2 = churchMember.AnswerToQ2,
                AnswerToQ3 = churchMember.AnswerToQ3,
                AnswerToQ4 = churchMember.AnswerToQ4,
                AnswerToQ5 = churchMember.AnswerToQ5,
                AnswerToQ6 = churchMember.AnswerToQ6,
            };

            return View(viewModel);
        }

        // GET: ChurchMembers/Create
        public IActionResult Create()
        {
            ViewData["AgeGroupId"] = new SelectList(_context.AgeGroup, "AgroupId", "AgeRange");
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname");
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "OccupationId", "Occupation1");
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory");
            return View();
        }

        // POST: ChurchMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChurchMemberId,FirstName,LastName,DateOfBirth,Day,Month,Year,CellPhone,HomePhone,WorkPhone,Email,DateRegistered,AgeGroupId,RelationshipId,GenderId,Street,City,Province,PostalCode,OccupationId,NumDepInPreSchool,NumDepInPrimary,NumDepInHighSchool,NumDepInTertiary,AnswerToQ1,AnswerToQ2,AnswerToQ3,AnswerToQ4,AnswerToQ5,AnswerToQ6")] ChurchMembersViewModel viewModel)
        {           
            if (ModelState.IsValid)
            {               
                if (viewModel.Year == 0)
                {
                    viewModel.DateOfBirth = viewModel.Day + "/" + viewModel.Month;                   
                }
                else
                {
                    viewModel.DateOfBirth = viewModel.Day + "/" + viewModel.Month + "/" + viewModel.Year;                    
                }
                                                                                                                        
                viewModel.DateRegistered = DateTime.Now;


                ChurchMember churchMember = new ChurchMember
                {
                    ChurchMemberId = viewModel.ChurchMemberId,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    DateOfBirth = viewModel.DateOfBirth,
                    Month = viewModel.Month,
                    Year = viewModel.Year,
                    Day = viewModel.Day,
                    CellPhone = viewModel.CellPhone,
                    HomePhone = viewModel.HomePhone,
                    WorkPhone = viewModel.WorkPhone,
                    Email = viewModel.Email,
                    DateRegistered = viewModel.DateRegistered,
                    AgeGroupId = viewModel.AgeGroupId,
                    RelationshipId = viewModel.RelationshipId,
                    GenderId = viewModel.GenderId,
                    Street = viewModel.Street,
                    City = viewModel.City,
                    Province = viewModel.Province,
                    PostalCode = viewModel.PostalCode,
                    OccupationId = viewModel.OccupationId,
                    NumDepInPreSchool = viewModel.NumDepInPreSchool,
                    NumDepInPrimary = viewModel.NumDepInPrimary,
                    NumDepInHighSchool = viewModel.NumDepInHighSchool,
                    NumDepInTertiary = viewModel.NumDepInTertiary,
                    AnswerToQ1 = viewModel.AnswerToQ1,
                    AnswerToQ2 = viewModel.AnswerToQ2,
                    AnswerToQ3 = viewModel.AnswerToQ3,
                    AnswerToQ4 = viewModel.AnswerToQ4,
                    AnswerToQ5 = viewModel.AnswerToQ5,
                    AnswerToQ6 = viewModel.AnswerToQ6,                   
                };

                _context.Add(churchMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeGroupId"] = new SelectList(_context.AgeGroup, "AgroupId", "AgeRange", viewModel.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname", viewModel.GenderId);
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "OccupationId", "Occupation1", viewModel.OccupationId);
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory", viewModel.RelationshipId);
            return View(viewModel);
        }

        // GET: ChurchMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMember.SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            if (churchMember == null)
            {
                return NotFound();
            }

            ChurchMembersViewModel viewModel = new ChurchMembersViewModel
            {
                ChurchMemberId = churchMember.ChurchMemberId,
                FirstName = churchMember.FirstName,
                LastName = churchMember.LastName,
                DateOfBirth = churchMember.DateOfBirth,
                Month = churchMember.Month,
                Year = churchMember.Year,
                Day = churchMember.Day,
                CellPhone = churchMember.CellPhone,
                HomePhone = churchMember.HomePhone,
                WorkPhone = churchMember.WorkPhone,
                Email = churchMember.Email,
                DateRegistered = churchMember.DateRegistered,
                AgeGroupId = churchMember.AgeGroupId,
                RelationshipId = churchMember.RelationshipId,
                GenderId = churchMember.GenderId,
                Street = churchMember.Street,
                City = churchMember.City,
                Province = churchMember.Province,
                PostalCode = churchMember.PostalCode,
                OccupationId = churchMember.OccupationId,
                NumDepInPreSchool = churchMember.NumDepInPreSchool,
                NumDepInPrimary = churchMember.NumDepInPrimary,
                NumDepInHighSchool = churchMember.NumDepInHighSchool,
                NumDepInTertiary = churchMember.NumDepInTertiary,
                AnswerToQ1 = churchMember.AnswerToQ1,
                AnswerToQ2 = churchMember.AnswerToQ2,
                AnswerToQ3 = churchMember.AnswerToQ3,
                AnswerToQ4 = churchMember.AnswerToQ4,
                AnswerToQ5 = churchMember.AnswerToQ5,
                AnswerToQ6 = churchMember.AnswerToQ6,
            };

            ViewData["AgeGroupId"] = new SelectList(_context.AgeGroup, "AgroupId", "AgeRange", churchMember.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname", churchMember.GenderId);
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "OccupationId", "Occupation1", churchMember.OccupationId);
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory", churchMember.RelationshipId);
            return View(viewModel);
        }

        // POST: ChurchMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChurchMemberId,FirstName,LastName,DateOfBirth,Month,Day,Year,CellPhone,HomePhone,WorkPhone,Email,DateRegistered,AgeGroupId,RelationshipId,GenderId,Street,City,Province,PostalCode,OccupationId,NumDepInPreSchool,NumDepInPrimary,NumDepInHighSchool,NumDepInTertiary,AnswerToQ1,AnswerToQ2,AnswerToQ3,AnswerToQ4,AnswerToQ5,AnswerToQ6")] ChurchMember churchMember)
        {
            if (id != churchMember.ChurchMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (churchMember.Year == 0)
                {
                    churchMember.DateOfBirth = churchMember.Day + "/" + churchMember.Month;
                }
                else
                {
                    churchMember.DateOfBirth = churchMember.Day + "/" + churchMember.Month + "/" + churchMember.Year;
                }

                try
                {
                    _context.Update(churchMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChurchMemberExists(churchMember.ChurchMemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeGroupId"] = new SelectList(_context.AgeGroup, "AgroupId", "AgeRange", churchMember.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname", churchMember.GenderId);
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "OccupationId", "Occupation1", churchMember.OccupationId);
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory", churchMember.RelationshipId);
            return View(churchMember);
        }

        // GET: ChurchMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMember
                .Include(c => c.AgeGroup)
                .Include(c => c.Gender)
                .Include(c => c.Occupation)
                .Include(c => c.Relationship)
                .SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            if (churchMember == null)
            {
                return NotFound();
            }

            ChurchMembersViewModel viewModel = new ChurchMembersViewModel
            {
                ChurchMemberId = churchMember.ChurchMemberId,
                FirstName = churchMember.FirstName,
                LastName = churchMember.LastName,
                DateOfBirth = churchMember.DateOfBirth,
                Month = churchMember.Month,
                Year = churchMember.Year,
                Day = churchMember.Day,
                CellPhone = churchMember.CellPhone,
                HomePhone = churchMember.HomePhone,
                WorkPhone = churchMember.WorkPhone,
                Email = churchMember.Email,
                DateRegistered = churchMember.DateRegistered,
                AgeGroupId = churchMember.AgeGroupId,
                RelationshipId = churchMember.RelationshipId,
                GenderId = churchMember.GenderId,
                Street = churchMember.Street,
                City = churchMember.City,
                Province = churchMember.Province,
                PostalCode = churchMember.PostalCode,
                OccupationId = churchMember.OccupationId,
                NumDepInPreSchool = churchMember.NumDepInPreSchool,
                NumDepInPrimary = churchMember.NumDepInPrimary,
                NumDepInHighSchool = churchMember.NumDepInHighSchool,
                NumDepInTertiary = churchMember.NumDepInTertiary,
                AnswerToQ1 = churchMember.AnswerToQ1,
                AnswerToQ2 = churchMember.AnswerToQ2,
                AnswerToQ3 = churchMember.AnswerToQ3,
                AnswerToQ4 = churchMember.AnswerToQ4,
                AnswerToQ5 = churchMember.AnswerToQ5,
                AnswerToQ6 = churchMember.AnswerToQ6,
            };

            return View(viewModel);
        }

        // POST: ChurchMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var churchMember = await _context.ChurchMember.SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            _context.ChurchMember.Remove(churchMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChurchMemberExists(int id)
        {
            return _context.ChurchMember.Any(e => e.ChurchMemberId == id);
        }
    }
}
