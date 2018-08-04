using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ysamedia.Entities;
using ysamedia.Models.DepartmentViewModels;

namespace ysamedia.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ysamediaDbContext _context;

        public DepartmentController(ysamediaDbContext context)
        {
            _context = context;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            var ysamediaDbContext = _context.Department.Include(d => d.DepartmentLeader).Include(d => d.DeputyNavigation);           
            return View(await ysamediaDbContext.ToListAsync());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .Include(d => d.DepartmentLeader)
                .Include(d => d.DeputyNavigation)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            ViewData["DepartmentLeaderId"] = new SelectList(_context.User, "UserId", "DisplayName");
            ViewData["DeputyId"] = new SelectList(_context.User, "UserId", "DisplayName");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentLeaderId,NumMembers,DepartmentName,DepartmentLead,DeputyId,Deputy")] DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department
                {
                    DepartmentId = viewModel.DepartmentId,
                    DepartmentLeaderId = viewModel.DepartmentLeaderId,
                    NumMembers = viewModel.NumMembers,
                    DepartmentName = viewModel.DepartmentName,
                    DepartmentLead = viewModel.DepartmentLead,
                    DeputyId = viewModel.DeputyId,
                    Deputy = viewModel.Deputy
                };

                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["DepartmentLeaderId"] = new SelectList(_context.User, "UserId", "DisplayName", viewModel.DepartmentLeaderId);
            ViewData["DeputyId"] = new SelectList(_context.User, "UserId", "DisplayName", viewModel.DeputyId);
            return View(viewModel);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            DepartmentViewModel viewModel = new DepartmentViewModel
            {

                DepartmentId = department.DepartmentId,
                DepartmentLeaderId = department.DepartmentLeaderId,
                NumMembers = department.NumMembers,
                DepartmentName = department.DepartmentName,
                DepartmentLead = department.DepartmentLead,
                DeputyId = department.DeputyId,
                Deputy = department.Deputy
            };                   
    

            ViewData["DepartmentLeaderId"] = new SelectList(_context.User, "UserId", "DisplayName", department.DepartmentLeaderId);           
            ViewData["DeputyId"] = new SelectList(_context.User, "UserId", "DisplayName", department.DeputyId);
            return View(viewModel);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentLeaderId,NumMembers,DepartmentName,DepartmentLead,DeputyId,Deputy")] DepartmentViewModel viewModel)
        {
            if (id != viewModel.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    User DeptLeader = _context.User.FirstOrDefault(u => u.UserId == viewModel.DepartmentLeaderId);
                    User DeptDeputy = _context.User.FirstOrDefault(u => u.UserId == viewModel.DeputyId);

                    viewModel.DepartmentLead = DeptLeader.DisplayName;
                    viewModel.Deputy = DeptDeputy.DisplayName;

                    Department department = new Department
                    {
                        DepartmentId = viewModel.DepartmentId,
                        DepartmentLeaderId = viewModel.DepartmentLeaderId,
                        NumMembers = viewModel.NumMembers,
                        DepartmentName = viewModel.DepartmentName,
                        DepartmentLead = viewModel.DepartmentLead,
                        DeputyId = viewModel.DeputyId,
                        Deputy = viewModel.Deputy
                    };

                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(viewModel.DepartmentId))
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
            ViewData["DepartmentLeaderId"] = new SelectList(_context.User, "UserId", "DisplayName", viewModel.DepartmentLeaderId);
            ViewData["DeputyId"] = new SelectList(_context.User, "UserId", "DisplayName", viewModel.DeputyId);           
            return View(viewModel);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> AddUsers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.SingleOrDefaultAsync(m => m.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }

            DepartmentMemberViewModel viewModel = new DepartmentMemberViewModel
            {

                DepartmentId = department.DepartmentId,
                DepartmentLeaderId = department.DepartmentLeaderId,
                NumMembers = department.NumMembers,
                DepartmentName = department.DepartmentName,
                DepartmentLead = department.DepartmentLead,
                DeputyId = department.DeputyId,
                Deputy = department.Deputy
            };

            // Getting and binding the User entries for Multiselect
            List<User> UserList = new List<User>();

            UserList = (from u in _context.User
                        select u).ToList();            

            ViewData["DepartmentLeaderId"] = new SelectList(_context.User, "UserId", "DisplayName", department.DepartmentLeaderId);
            ViewData["DeputyId"] = new SelectList(_context.User, "UserId", "DisplayName", department.DeputyId);
            ViewData["UserList"] = UserList;

            return View(viewModel);
        }

        [HttpPost]       
        public async Task<IActionResult> AddUsers(int id,DepartmentMemberViewModel viewModel)
        {
            if (id != viewModel.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //User DeptLeader = _context.User.FirstOrDefault(u => u.UserId == viewModel.DepartmentLeaderId);
                    //User DeptDeputy = _context.User.FirstOrDefault(u => u.UserId == viewModel.DeputyId);

                    //viewModel.DepartmentLead = DeptLeader.DisplayName;
                    //viewModel.Deputy = DeptDeputy.DisplayName;

                    //Department department = new Department
                    //{
                    //    DepartmentId = viewModel.DepartmentId,
                    //    DepartmentLeaderId = viewModel.DepartmentLeaderId,
                    //    NumMembers = viewModel.NumMembers,
                    //    DepartmentName = viewModel.DepartmentName,
                    //    DepartmentLead = viewModel.DepartmentLead,
                    //    DeputyId = viewModel.DeputyId,
                    //    Deputy = viewModel.Deputy
                    //};

                    //_context.Update(department);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(viewModel.DepartmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //int count = (viewModel.SelectedIDArray).Count;                
                //return RedirectToAction("Worked", count);
                //return RedirectToAction(nameof(Index));
                return View(viewModel);
            }
            ViewData["DepartmentLeaderId"] = new SelectList(_context.User, "UserId", "DisplayName", viewModel.DepartmentLeaderId);
            ViewData["DeputyId"] = new SelectList(_context.User, "UserId", "DisplayName", viewModel.DeputyId);
            ViewData["UserList"] = new MultiSelectList(_context.User, "UserId", "DisplayName", viewModel.SelectedIDArray);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Worked(int count)
        {
            ViewData["Count"] = count;
            return View();
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .Include(d => d.DepartmentLeader)
                .Include(d => d.DeputyNavigation)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            DepartmentViewModel viewModel = new DepartmentViewModel
            {
                DepartmentId = department.DepartmentId,
                DepartmentLeaderId = department.DepartmentLeaderId,
                NumMembers = department.NumMembers,
                DepartmentName = department.DepartmentName,
                DepartmentLead = department.DepartmentLead,
                DeputyId = department.DeputyId,
                Deputy = department.Deputy
            };

            return View(viewModel);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Department.SingleOrDefaultAsync(m => m.DepartmentId == id);
            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.DepartmentId == id);
        }
    }
}
