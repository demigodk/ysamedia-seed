using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ysamedia.Classes.UserScreeningHelper;
using ysamedia.Entities;
using ysamedia.Models;
using ysamedia.Models.UserScreeningViewModels;

/// <summary>
/// @author                 :   Bondo Kalombo
/// @date                   :   01/07/2018
/// Purpose                 :   Controller for handling the capturing of user screening data
/// </summary>
namespace ysamedia.Controllers
{
    public class UserScreeningController : Controller
    {
        UserManager<ApplicationUser> UserManager;       

        private readonly ysamediaDbContext _context;
        private readonly string _userId;

        public UserScreeningController(ysamediaDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userId = userId;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Getting and binding the tblAttribute entries for Multiselect
            List<TblAttribute> PosAttributeList = new List<TblAttribute>();

            PosAttributeList = (from p in _context.TblAttribute
                        select p).ToList();

            ViewBag.ListPosAttri = PosAttributeList;

            // Getting and binding the tblNegativeAttribute
            List<TblNegativeAttribute> NegAttributeList = new List<TblNegativeAttribute>();

            NegAttributeList = (from n in _context.TblNegativeAttribute
                                select n).ToList();

            ViewBag.ListNegAttri = NegAttributeList;

            return View();
        }

        [HttpPost]
        public IActionResult Index(UserScreeningViewModel vm)
        {
            if (ModelState.IsValid)
            {
                /**Code Segment 1 - Entering data into tblScreeningAnswer **/
                int maxAnsId = 0;

                if (_context.TblScreeningAnswer.Any())
                {
                    // Get the maximum id in the table, so I can increment it for the next record
                    maxAnsId = _context.TblScreeningAnswer.Max(a => a.AnswerId);
                }

                TblScreeningAnswer ScreenAnswer1 = new TblScreeningAnswer
                {
                    AnswerId = (maxAnsId + 1),
                    UserId = _userId,
                    QuestionId = 1,
                    Answer = vm.Question1
                };
                _context.Add(ScreenAnswer1);
                _context.SaveChanges();

                TblScreeningAnswer ScreenAnswer2 = new TblScreeningAnswer
                {
                    AnswerId = (maxAnsId + 2),
                    UserId = _userId,
                    QuestionId = 2,
                    Answer = vm.Question2
                };
                _context.Add(ScreenAnswer2);
                _context.SaveChanges();

                TblScreeningAnswer ScreenAnswer3 = new TblScreeningAnswer
                {
                    AnswerId = (maxAnsId + 3),
                    UserId = _userId,
                    QuestionId = 3,
                    Answer = vm.Question3
                };
                _context.Add(ScreenAnswer3);
                _context.SaveChanges();

                TblScreeningAnswer ScreenAnswer4 = new TblScreeningAnswer
                {
                    AnswerId = (maxAnsId + 4),
                    UserId = _userId,
                    QuestionId = 4,
                    Answer = vm.Question4
                };
                _context.Add(ScreenAnswer4);               
                _context.SaveChanges();

                /** End code segment 1 **/

                /**************************** Code Segment 2 - Entering data into tblAttributeUserBridge *****************/
                int bridgeMaxId = 0;

                if (_context.TblAttributeUserBridge.Any())
                {
                    bridgeMaxId = _context.TblAttributeUserBridge.Max(b => b.Id);
                }

                // Count of position attributes selected
                int bridgeCount = (vm.PosAttribute).Count;

                TblAttributeUserBridge[] attrUserBridge = new TblAttributeUserBridge[bridgeCount];
                int[] attributeIds = new int[bridgeCount];
                attributeIds = (vm.PosAttribute).ToArray();

                for (int a = 0; a < ((vm.PosAttribute).Count); a++)
                {
                    bridgeMaxId = (bridgeMaxId + 1);
                    attrUserBridge[a] = UserScreeningSupport.createAttributeRecord(bridgeMaxId, _userId, attributeIds[a]);
                    _context.Add(attrUserBridge[a]);
                }

                _context.SaveChanges();

                /** Code Segment 2 End **/


                /***************************  Code Segment 3 - Entering data for   tblNegAttributeUserBridge  ****************************/
                int nbridgeMaxId = 0;

                if (_context.TblNegAttributeUserBridge.Any())
                {
                    nbridgeMaxId = _context.TblNegAttributeUserBridge.Max(n => n.Id);
                }

                // Count of negative attributes selected
                int nbridgeCount = (vm.NegAttribute).Count;

                TblNegAttributeUserBridge[] negAttriUserBridge = new TblNegAttributeUserBridge[nbridgeCount];
                int[] negAttributeIds = new int[nbridgeCount];
                negAttributeIds = (vm.NegAttribute).ToArray();

                for (int i = 0; i < ((vm.NegAttribute).Count); i++)
                {
                    nbridgeMaxId += 1;
                    negAttriUserBridge[i] = UserScreeningSupport.createNegAttributeRecord(nbridgeMaxId, _userId, negAttributeIds[i]);
                    _context.Add(negAttriUserBridge[i]);
                }
                _context.SaveChanges();

                /** Code Segment 3 End **/



                /************************* Code Segment 4 - Entering Data For tblRatingQuestion ****************************************/
                int ratingMaxId = 0;        // Max ID in tblRatingAnswer

                if (_context.TblRatingAnswer.Any())
                {
                    ratingMaxId = _context.TblRatingAnswer.Max(r => r.AnswerId);
                }

                //TblRatingAnswer RatingAnswer1 = new TblRatingAnswer
                //{
                //    AnswerId = (ratingMaxId + 1),
                //    Rating = vm.RQuestion1,
                //    QuestionId = 1
                //};
                //_context.Add(RatingAnswer1);
                //_context.SaveChanges();

                _context.TblRatingAnswer.AddRange(
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 1), Rating = vm.RQuestion1, QuestionId = 1 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 2), Rating = vm.RQuestion2, QuestionId = 2 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 3), Rating = vm.RQuestion3, QuestionId = 3 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 4), Rating = vm.RQuestion4, QuestionId = 4 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 5), Rating = vm.RQuestion5, QuestionId = 5 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 6), Rating = vm.RQuestion6, QuestionId = 6 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 7), Rating = vm.RQuestion7, QuestionId = 7 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 8), Rating = vm.RQuestion8, QuestionId = 8 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 9), Rating = vm.RQuestion9, QuestionId = 9 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 10), Rating = vm.RQuestion10, QuestionId = 10 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 11), Rating = vm.RQuestion11, QuestionId = 11 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 12), Rating = vm.RQuestion12, QuestionId = 12 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 13), Rating = vm.RQuestion13, QuestionId = 13 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 14), Rating = vm.RQuestion14, QuestionId = 14 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 15), Rating = vm.RQuestion15, QuestionId = 15 },
                    new TblRatingAnswer { AnswerId = (ratingMaxId + 16), Rating = vm.RQuestion16, QuestionId = 16 }
                    );
                _context.SaveChanges();


                int rateBridgeMaxId = 0;    // Max ID in tblRateAnswerUserBridge

                if (_context.TblRateAnswerUserBridge.Any())
                {
                    rateBridgeMaxId = _context.TblRateAnswerUserBridge.Max(b => b.Id);
                }

                _context.TblRateAnswerUserBridge.AddRange(
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 1), UserId = _userId, AnswerId = (ratingMaxId + 1) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 2), UserId = _userId, AnswerId = (ratingMaxId + 2) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 3), UserId = _userId, AnswerId = (ratingMaxId + 3) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 4), UserId = _userId, AnswerId = (ratingMaxId + 4) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 5), UserId = _userId, AnswerId = (ratingMaxId + 5) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 6), UserId = _userId, AnswerId = (ratingMaxId + 6) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 7), UserId = _userId, AnswerId = (ratingMaxId + 7) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 8), UserId = _userId, AnswerId = (ratingMaxId + 8) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 9), UserId = _userId, AnswerId = (ratingMaxId + 9) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 10), UserId = _userId, AnswerId = (ratingMaxId + 10) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 11), UserId = _userId, AnswerId = (ratingMaxId + 11) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 12), UserId = _userId, AnswerId = (ratingMaxId + 12) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 13), UserId = _userId, AnswerId = (ratingMaxId + 13) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 14), UserId = _userId, AnswerId = (ratingMaxId + 14) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 15), UserId = _userId, AnswerId = (ratingMaxId + 15) },
                    new TblRateAnswerUserBridge { Id = (rateBridgeMaxId + 16), UserId = _userId, AnswerId = (ratingMaxId + 16) }
                );
                _context.SaveChanges();
            }
            else
            {
                return View();
            }

            return RedirectToAction("Reached");
        }

        public IActionResult Reached()
        {
            return View();
        }
    }
}
