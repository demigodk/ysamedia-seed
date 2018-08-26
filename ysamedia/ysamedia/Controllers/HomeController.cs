using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ysamedia.Entities;
using ysamedia.Models;

namespace ysamedia.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ysamediaDbContext _context;
        private readonly string _userId;
       
        public HomeController(ysamediaDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userId = userId;
        }

        public IActionResult Index()
        {
            List<User> UserList = new List<User>();

            UserList = (from u in _context.User
                        select u).ToList();

            ViewData["NumMediaMembers"] = UserList.Count;
           
            List<User> maleList = (from m in _context.User
                             where m.GenderId == 1
                             select m).ToList();

            int maleCount = maleList.Count();

            ViewData["NumMales"] = maleCount;



            List<User> femaleList = (from m in _context.User
                                   where m.GenderId == 2
                                   select m).ToList();

            int femaleCount = femaleList.Count();

            ViewData["NumFemales"] = femaleCount;



            List<Log> LogList = new List<Log>();

            LogList = (from l in _context.Log
                       select l).ToList();
           
            ViewData["NumLogs"] = LogList.Count;

            List<ChurchMember> churchMembersList = new List<ChurchMember>();

            churchMembersList = (from c in _context.ChurchMember
                                 select c).ToList();

            ViewData["NumChurchMembers"] = churchMembersList.Count;
           
            var ysamediaDbContext = _context.User.Include(c => c.Gender);            

            return View(ysamediaDbContext.ToList());
        }

        // GET: ChurchMembers/Details/5
        public async Task<IActionResult> Profile(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Language> LanguageList = new List<Language>();

            LanguageList = (from l in _context.Language
                       select l).ToList();

            var mediaMember = await _context.User
                .Include(m => m.Gender)
                .Include(m => m.AttributeUserBridge)
                .Include(m => m.NextOfKin)
                .Include(m => m.Language)                
                .Include(m => m.DlicenceUserBridge)
                .Include(m => m.NegAttributeUserBridge)
                .Include(m => m.ScreeningAnswer)
                .Include(m => m.Photo)
                .Include(m => m.RateAnswerUserBridge)
                .SingleOrDefaultAsync(m => m.UserId == id);            

            if (mediaMember == null)
            {
                return NotFound();
            }            

            return View(mediaMember);
        }

        // GET: Language
        public async Task<IActionResult> Language()
        {
            var ysamediaDbContext = (from c in _context.Language
                                     where c.UserId == _userId
                                     select c).ToListAsync();

            return View(await ysamediaDbContext);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
