using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ysamedia.Entities;
using ysamedia.Models.ChurchViewModels;

namespace ysamedia.Controllers
{
    public class ChurchMemberController : Controller
    {
        private ysamediaDbContext db = new ysamediaDbContext();

        [HttpGet]
        public IActionResult MemberRegister(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MemberRegister(ChurchMemberViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                TblUser churchMember = new TblUser()
                {
                    FirstName = model.FirstName,
                    Surname = model.Surname,
                    GenderId = model.GenderId
                };

                db.TblUser.Add(churchMember);
                db.SaveChanges();                
            }

            return View(model);
        }
    }
}
