using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ysamedia.Entities;

namespace ysamedia.Controllers
{
    public class TblChurchMembersController : Controller
    {
        private readonly ysamediaDbContext _context;

        public TblChurchMembersController(ysamediaDbContext context)
        {
            _context = context;
        }

        // GET: TblChurchMembers
        public async Task<IActionResult> Index()
        {
            var ysamediaDbContext = _context.TblChurchMember.Include(t => t.AgeGroup).Include(t => t.Gender).Include(t => t.Relationship);
            return View(await ysamediaDbContext.ToListAsync());
        }

        // GET: TblChurchMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChurchMember = await _context.TblChurchMember
                .Include(t => t.AgeGroup)
                .Include(t => t.Gender)
                .Include(t => t.Relationship)
                .SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            if (tblChurchMember == null)
            {
                return NotFound();
            }

            return View(tblChurchMember);
        }

        // GET: TblChurchMembers/Create
        public IActionResult Create()
        {
            ViewData["AgeGroupId"] = new SelectList(_context.TblAgeGroup, "AgroupId", "AgeRange");
            ViewData["GenderId"] = new SelectList(_context.TblGender, "GenderId", "Gname");
            ViewData["RelationshipId"] = new SelectList(_context.TblRelationshipStatus, "RelationshipId", "RelationshipCategory");
            return View();
        }

        // POST: TblChurchMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChurchMemberId,FirstName,LastName,DateOfBirth,CellPhone,HomePhone,WorkPhone,Email,DateRegistered,AgeGroupId,RelationshipId,GenderId,Street,City,Province,PostalCode")] TblChurchMember tblChurchMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblChurchMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeGroupId"] = new SelectList(_context.TblAgeGroup, "AgroupId", "AgeRange", tblChurchMember.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.TblGender, "GenderId", "Gname", tblChurchMember.GenderId);
            ViewData["RelationshipId"] = new SelectList(_context.TblRelationshipStatus, "RelationshipId", "RelationshipCategory", tblChurchMember.RelationshipId);
            return View(tblChurchMember);
        }

        // GET: TblChurchMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChurchMember = await _context.TblChurchMember.SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            if (tblChurchMember == null)
            {
                return NotFound();
            }
            ViewData["AgeGroupId"] = new SelectList(_context.TblAgeGroup, "AgroupId", "AgeRange", tblChurchMember.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.TblGender, "GenderId", "Gname", tblChurchMember.GenderId);
            ViewData["RelationshipId"] = new SelectList(_context.TblRelationshipStatus, "RelationshipId", "RelationshipCategory", tblChurchMember.RelationshipId);
            return View(tblChurchMember);
        }

        // POST: TblChurchMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChurchMemberId,FirstName,LastName,DateOfBirth,CellPhone,HomePhone,WorkPhone,Email,DateRegistered,AgeGroupId,RelationshipId,GenderId,Street,City,Province,PostalCode")] TblChurchMember tblChurchMember)
        {
            if (id != tblChurchMember.ChurchMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblChurchMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblChurchMemberExists(tblChurchMember.ChurchMemberId))
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
            ViewData["AgeGroupId"] = new SelectList(_context.TblAgeGroup, "AgroupId", "AgeRange", tblChurchMember.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.TblGender, "GenderId", "Gname", tblChurchMember.GenderId);
            ViewData["RelationshipId"] = new SelectList(_context.TblRelationshipStatus, "RelationshipId", "RelationshipCategory", tblChurchMember.RelationshipId);
            return View(tblChurchMember);
        }

        // GET: TblChurchMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChurchMember = await _context.TblChurchMember
                .Include(t => t.AgeGroup)
                .Include(t => t.Gender)
                .Include(t => t.Relationship)
                .SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            if (tblChurchMember == null)
            {
                return NotFound();
            }

            return View(tblChurchMember);
        }

        // POST: TblChurchMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblChurchMember = await _context.TblChurchMember.SingleOrDefaultAsync(m => m.ChurchMemberId == id);
            _context.TblChurchMember.Remove(tblChurchMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblChurchMemberExists(int id)
        {
            return _context.TblChurchMember.Any(e => e.ChurchMemberId == id);
        }
    }
}
