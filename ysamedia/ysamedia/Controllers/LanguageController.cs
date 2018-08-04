using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ysamedia.Entities;
using ysamedia.Models.LanguageViewModels;

/// <summary>
/// @author                 :   Bondo Kalombo
/// @date                   :   03/08/2018
/// Purpose                 :   Used for the purpose of allowing registered media members to add/edit the languages that
///                             they speak
/// </summary>
namespace ysamedia.Controllers
{
    public class LanguageController : Controller
    {
        
        private readonly ysamediaDbContext _context;
        private readonly string _userId;

        public LanguageController(ysamediaDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userId = userId;
        }
        
        // GET: Language
        public async Task<IActionResult> Index()
        {           
            var ysamediaDbContext = (from c in _context.Language
                                     where c.UserId == _userId
                                     select c).ToListAsync();

            return View(await ysamediaDbContext);
        }
      
        // GET: Language/Create
        public IActionResult Create()
        {           
            return View();
        }

        // POST: Language/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LanguageId,Language1,Proficiency,PrimaryLanguage,UserId")] LanguageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Language language = new Language
                {
                    Language1 = viewModel.Language1,
                    Proficiency = viewModel.Proficiency,
                    PrimaryLanguage = viewModel.PrimaryLanguage,
                    UserId = _userId
                };
                
                _context.Add(language);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                       
            return View(viewModel);
        }

        // GET: Language/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language.SingleOrDefaultAsync(m => m.LanguageId == id);

            if (language == null)
            {
                return NotFound();
            }

            ViewData["Proficiency"] = new SelectList(_context.Language, "Proficiency", "Proficiency", language.UserId == _userId);

            LanguageViewModel viewModel = new LanguageViewModel
            {
                LanguageId = language.LanguageId,
                Language1 = language.Language1,
                Proficiency = language.Proficiency,
                PrimaryLanguage = language.PrimaryLanguage,
                UserId = _userId
            };

            return View(viewModel);
        }

        // POST: Language/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LanguageId,Language1,Proficiency,PrimaryLanguage,UserId")] LanguageViewModel viewModel)
        {
            if (id != viewModel.LanguageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Language language = new Language
                    {
                        LanguageId = viewModel.LanguageId,
                        Language1 = viewModel.Language1,
                        Proficiency = viewModel.Proficiency,
                        PrimaryLanguage = viewModel.PrimaryLanguage,
                        UserId = _userId
                    };

                    _context.Update(language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(viewModel.LanguageId))
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

            ViewData["Proficiency"] = new SelectList(_context.Language, "Proficiency", "Proficiency", viewModel.UserId == _userId);

            return View(viewModel);
        }

        // GET: Language/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .Include(l => l.User)
                .SingleOrDefaultAsync(m => m.LanguageId == id);

            if (language == null)
            {
                return NotFound();
            }

            LanguageViewModel viewModel = new LanguageViewModel
            {
                LanguageId = language.LanguageId,
                Language1 = language.Language1,
                PrimaryLanguage = language.PrimaryLanguage,
                Proficiency = language.Proficiency,
                UserId = _userId,
                User = language.User
            };

            return View(viewModel);
        }

        // POST: Language/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var language = await _context.Language.SingleOrDefaultAsync(m => m.LanguageId == id);
            _context.Language.Remove(language);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(int id)
        {
            return _context.Language.Any(e => e.LanguageId == id);
        }
    }
}
