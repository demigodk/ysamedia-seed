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
using ysamedia.Models.UserProfileViewModels;

namespace ysamedia.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ysamediaDbContext _context;

        public HomeController(ysamediaDbContext context)
        {
            _context = context;           
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

            CombinedProfileViewModel model = new CombinedProfileViewModel();

            model.UserViewModel = _context.User.FirstOrDefault(u => u.UserId == id);

            if (model.UserViewModel == null)
            {
                return NotFound();
            }

            model.LanguageViewModel = (from l in _context.Language
                                       where l.UserId == id
                                       select l).ToList();

            model.GenderViewModel = (from g in _context.Gender
                                     where g.GenderId == model.UserViewModel.GenderId
                                     select g).FirstOrDefault();

            model.NextOfKinViewModel = (from n in _context.NextOfKin
                                        where n.UserId == id
                                        select n).ToList();

            return View(model);
        }       

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
