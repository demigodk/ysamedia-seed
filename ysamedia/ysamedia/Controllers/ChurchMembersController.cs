﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            var ysamediaDbContext = _context.ChurchMember.Include(c => c.AgeGroup).Include(c => c.Gender).Include(c => c.Occupation).Include(c => c.Relationship);
            return View(await ysamediaDbContext.ToListAsync());
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
                .Include(c => c.Occupation)
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
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "OccupationId", "Occupation1");
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory");
            return View();
        }

        // POST: ChurchMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChurchMemberId,FirstName,LastName,DateOfBirth,Day,Month,Year,CellPhone,HomePhone,WorkPhone,Email,DateRegistered,AgeGroupId,RelationshipId,GenderId,Street,City,Province,PostalCode,OccupationId,NumDepInPreSchool,NumDepInPrimary,NumDepInHighSchool,NumDepInTertiary,AnswerToQ1,AnswerToQ2,AnswerToQ3,AnswerToQ4,AnswerToQ5,AnswerToQ6")] ChurchMember churchMember)
        {
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
                                                                                                                        
                churchMember.DateRegistered = DateTime.Now;
                _context.Add(churchMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeGroupId"] = new SelectList(_context.AgeGroup, "AgroupId", "AgeRange", churchMember.AgeGroupId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "Gname", churchMember.GenderId);
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "OccupationId", "Occupation1", churchMember.OccupationId);
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
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "OccupationId", "Occupation1", churchMember.OccupationId);
            ViewData["RelationshipId"] = new SelectList(_context.RelationshipStatus, "RelationshipId", "RelationshipCategory", churchMember.RelationshipId);
            return View(churchMember);
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
