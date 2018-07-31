using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ysamedia.Entities;

namespace ysamedia.Controllers
{
    public class NextOfKinController : Controller
    {        
        private readonly ysamediaDbContext _context;
        private readonly string _userId;
        
        public NextOfKinController(ysamediaDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userId = userId;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ysamediaDbContext = _context.NextOfKin.Include(n => n.User);
            return View(await ysamediaDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKin
                .Include(n => n.User)
                .SingleOrDefaultAsync(m => m.KinId == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            return View(nextOfKin);
        }

        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,RelationshipType,KinId,Email,PhoneNumber,WorkNumber")] NextOfKin nextOfKin)
        {
            if (ModelState.IsValid)
            {
                nextOfKin.UserId = _userId;
                _context.Add(nextOfKin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(nextOfKin);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKin.SingleOrDefaultAsync(m => m.KinId == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }
           
            return View(nextOfKin);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,RelationshipType,KinId,Email,PhoneNumber,WorkNumber")] NextOfKin nextOfKin)
        {
            if (id != nextOfKin.KinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nextOfKin.UserId = _userId;
                    _context.Update(nextOfKin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NextOfKinExists(nextOfKin.KinId))
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
            return View(nextOfKin);
        }

       [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKin
                .Include(n => n.User)
                .SingleOrDefaultAsync(m => m.KinId == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            return View(nextOfKin);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nextOfKin = await _context.NextOfKin.SingleOrDefaultAsync(m => m.KinId == id);
            _context.NextOfKin.Remove(nextOfKin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NextOfKinExists(int id)
        {
            return _context.NextOfKin.Any(e => e.KinId == id);
        }
    }
}
