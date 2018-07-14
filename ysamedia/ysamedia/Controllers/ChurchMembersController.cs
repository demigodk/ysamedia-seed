using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ysamedia.Entities;

namespace ysamedia.Controllers
{
    public class ChurchMembersController : Controller
    {
        private readonly ysamediaDbContext _context;

        public ChurchMembersController(ysamediaDbContext context)
        {
            _context = context;
        }

        // GET: ChurchMembers
        public async Task<IActionResult> Index(string searchBy, string search)
        {
            if (searchBy == "Gender")
            {
                int GenderId = 0;

                if (search.ToLower() == "male")
                {
                    GenderId = 1;
                } else if (search.ToLower() == "female")
                {
                    GenderId = 2;
                }
                else
                {
                    GenderId = 0;
                }
                
                var ysamediaDbContext = _context.ChurchMember.Where(x => x.GenderId == GenderId || search == null).Include(c => c.AgeGroup).Include(c => c.Gender).Include(c => c.Relationship);
                return View(await ysamediaDbContext.ToListAsync());
            }
            else
            {
                var ysamediaDbContext = _context.ChurchMember.Where(x => x.FirstName.StartsWith(search) || search == null).Include(c => c.AgeGroup).Include(c => c.Gender).Include(c => c.Relationship);
                return View(await ysamediaDbContext.ToListAsync());
            }
            
        }

        //public JsonResult GetMembers(string term)
        //{
        //    ysamediaDbContext db = new ysamediaDbContext();
        //    List<string> members = _context.ChurchMember.Where(x => x.FirstName.StartsWith(term))
        //    .Select(y => y.FirstName).ToList();

        //     return Json(members);            
        //}

        private JsonResult Json(List<string> ysamediaDbContext, object allowGet)
        {
            throw new NotImplementedException();
        }

        // GET: ChurchMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMember
                .Include(c => c.AgeGroup)
                .Include(c => c.Gender)
                .Include(c => c.Relationship)
                .SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            if (churchMember == null)
            {
                return NotFound();
            }

            return View(churchMember);
        }

        // GET: ChurchMembers/Create
        public IActionResult Create()
        {
            ViewData["AgeGroupId"] = new SelectList(_context.AgeGroup, "AgroupId", "AgeRange");
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname");
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory");
            return View();
        }

        // POST: ChurchMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChurchMemberId,FirstName,LastName,DateOfBirth,CellPhone,HomePhone,WorkPhone,Email,DateRegistered,AgeGroupId,RelationshipId,GenderId,Street,City,Province,PostalCode")] ChurchMember churchMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(churchMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeGroupId"] = new SelectList(_context.AgeGroup, "AgroupId", "AgeRange", churchMember.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname", churchMember.GenderId);
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory", churchMember.RelationshipId);
            return View(churchMember);
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
            ViewData["AgeGroupId"] = new SelectList(_context.AgeGroup, "AgroupId", "AgeRange", churchMember.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname", churchMember.GenderId);
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory", churchMember.RelationshipId);
            return View(churchMember);
        }

        // POST: ChurchMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChurchMemberId,FirstName,LastName,DateOfBirth,CellPhone,HomePhone,WorkPhone,Email,DateRegistered,AgeGroupId,RelationshipId,GenderId,Street,City,Province,PostalCode")] ChurchMember churchMember)
        {
            if (id != churchMember.ChurchMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
                .Include(c => c.Relationship)
                .SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            if (churchMember == null)
            {
                return NotFound();
            }

            return View(churchMember);
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
