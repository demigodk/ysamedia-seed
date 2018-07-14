using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ysamedia.Classes.UserScreeningHelper;
using ysamedia.Entities;
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
        //UserManager<ApplicationUser> UserManager;       

        private readonly ysamediaDbContext _context;
        private readonly string _userId;

        public UserScreeningController(ysamediaDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userId = userId;
        }

        [HttpGet]
        public IActionResult Rating()
        {
            var model = new RatingViewModel
            {
            };

            if (_context.RateAnswerUserBridge.Any())
            {
                
                List<RatingAnswer> tableList = new List<RatingAnswer>();

                tableList = (from a in _context.RatingAnswer
                             join b in _context.RateAnswerUserBridge on a.AnswerId equals b.AnswerId
                             join c in _context.RatingQuestion on a.QuestionId equals c.QuestionId
                             where b.UserId == _userId
                             select a).ToList();
               
                /********* If found records containing the UserId specified *******/
                if (tableList.Any())
                {
                    
                    foreach (var item in tableList)
                    {                       
                        if (item.QuestionId == 1)
                        {
                            model.RQuestion1 = item.Rating;
                        }
                        else if (item.QuestionId == 2)
                        {
                            model.RQuestion2 = item.Rating;
                        }
                        else if (item.QuestionId == 3)
                        {
                            model.RQuestion3 = item.Rating;
                        }
                        else if (item.QuestionId == 4)
                        {
                            model.RQuestion4 = item.Rating;
                        }
                        else if (item.QuestionId == 5)
                        {
                            model.RQuestion5 = item.Rating;
                        }
                        else if (item.QuestionId == 6)
                        {
                            model.RQuestion6 = item.Rating;
                        }
                        else if (item.QuestionId == 7)
                        {
                            model.RQuestion7 = item.Rating;
                        }
                        else if (item.QuestionId == 8)
                        {
                            model.RQuestion8 = item.Rating;
                        }
                        else if (item.QuestionId == 9)
                        {
                            model.RQuestion9 = item.Rating;
                        }
                        else if (item.QuestionId == 10)
                        {
                            model.RQuestion10 = item.Rating;
                        }
                        else if (item.QuestionId == 11)
                        {
                            model.RQuestion11 = item.Rating;                      
                        }
                        else if (item.QuestionId == 12)
                        {
                            model.RQuestion12 = item.Rating;
                        }
                        else if (item.QuestionId == 13)
                        {
                            model.RQuestion13 = item.Rating;
                        }
                        else if (item.QuestionId == 14)
                        {
                            model.RQuestion14 = item.Rating;
                        }
                        else if (item.QuestionId == 15)
                        {
                            model.RQuestion15 = item.Rating;
                        }
                        else if (item.QuestionId == 16)
                        {
                            model.RQuestion16 = item.Rating;
                        }
                    }                   
                }
                
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Rating(RatingViewModel vm)
        {
            if (ModelState.IsValid)
            {
                /************************* Code Segment 1 - Entering Data For tblRatingQuestion ****************************************/
                int ratingMaxId = 0;        // Max ID in tblRatingAnswer

                if (_context.RatingAnswer.Any())
                {
                    ratingMaxId = _context.RatingAnswer.Max(r => r.AnswerId);
                }

                _context.RatingAnswer.AddRange(
                    new RatingAnswer { AnswerId = (ratingMaxId + 1), Rating = vm.RQuestion1, QuestionId = 1 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 2), Rating = vm.RQuestion2, QuestionId = 2 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 3), Rating = vm.RQuestion3, QuestionId = 3 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 4), Rating = vm.RQuestion4, QuestionId = 4 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 5), Rating = vm.RQuestion5, QuestionId = 5 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 6), Rating = vm.RQuestion6, QuestionId = 6 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 7), Rating = vm.RQuestion7, QuestionId = 7 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 8), Rating = vm.RQuestion8, QuestionId = 8 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 9), Rating = vm.RQuestion9, QuestionId = 9 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 10), Rating = vm.RQuestion10, QuestionId = 10 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 11), Rating = vm.RQuestion11, QuestionId = 11 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 12), Rating = vm.RQuestion12, QuestionId = 12 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 13), Rating = vm.RQuestion13, QuestionId = 13 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 14), Rating = vm.RQuestion14, QuestionId = 14 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 15), Rating = vm.RQuestion15, QuestionId = 15 },
                    new RatingAnswer { AnswerId = (ratingMaxId + 16), Rating = vm.RQuestion16, QuestionId = 16 }
                    );

                _context.SaveChanges();


                int rateBridgeMaxId = 0;    // Max ID in tblRateAnswerUserBridge

                if (_context.RateAnswerUserBridge.Any())
                {
                    rateBridgeMaxId = _context.RateAnswerUserBridge.Max(b => b.Id);
                }

                _context.RateAnswerUserBridge.AddRange(
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 1), UserId = _userId, AnswerId = (ratingMaxId + 1) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 2), UserId = _userId, AnswerId = (ratingMaxId + 2) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 3), UserId = _userId, AnswerId = (ratingMaxId + 3) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 4), UserId = _userId, AnswerId = (ratingMaxId + 4) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 5), UserId = _userId, AnswerId = (ratingMaxId + 5) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 6), UserId = _userId, AnswerId = (ratingMaxId + 6) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 7), UserId = _userId, AnswerId = (ratingMaxId + 7) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 8), UserId = _userId, AnswerId = (ratingMaxId + 8) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 9), UserId = _userId, AnswerId = (ratingMaxId + 9) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 10), UserId = _userId, AnswerId = (ratingMaxId + 10) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 11), UserId = _userId, AnswerId = (ratingMaxId + 11) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 12), UserId = _userId, AnswerId = (ratingMaxId + 12) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 13), UserId = _userId, AnswerId = (ratingMaxId + 13) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 14), UserId = _userId, AnswerId = (ratingMaxId + 14) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 15), UserId = _userId, AnswerId = (ratingMaxId + 15) },
                    new RateAnswerUserBridge { Id = (rateBridgeMaxId + 16), UserId = _userId, AnswerId = (ratingMaxId + 16) }
                );

                _context.SaveChanges();
            }
            else
            {
                return View();
            }

            return View();
        }
               
        [HttpGet]
        public IActionResult AttributeSet()
        {
            // Getting and binding the tblAttribute entries for Multiselect
            List<PositiveAttribute> PosAttributeList = new List<PositiveAttribute>();

            PosAttributeList = (from p in _context.PositiveAttribute
                                select p).ToList();

            ViewBag.ListPosAttri = PosAttributeList;

            // Getting and binding the tblNegativeAttribute
            List<NegativeAttribute> NegAttributeList = new List<NegativeAttribute>();

            NegAttributeList = (from n in _context.NegativeAttribute
                                select n).ToList();

            ViewBag.ListNegAttri = NegAttributeList;

            return View();
        }

        [HttpPost]
        public IActionResult AttributeSet(AttributeSetViewModel vm)
        {
            /**************************** Code Segment 1 - Entering data into tblAttributeUserBridge *****************/
            int bridgeMaxId = 0;

            if (_context.AttributeUserBridge.Any())
            {
                bridgeMaxId = _context.AttributeUserBridge.Max(b => b.Id);
            }

            // Count of positive attributes selected
            int bridgeCount = (vm.PosAttribute).Count;

            AttributeUserBridge[] attrUserBridge = new AttributeUserBridge[bridgeCount];
            int[] attributeIds = new int[bridgeCount];
            attributeIds = (vm.PosAttribute).ToArray();

            for (int a = 0; a < ((vm.PosAttribute).Count); a++)
            {
                bridgeMaxId = (bridgeMaxId + 1);
                attrUserBridge[a] = UserScreeningSupport.createAttributeRecord(bridgeMaxId, _userId, attributeIds[a]);
                _context.Add(attrUserBridge[a]);
            }

            _context.SaveChanges();

            /** Code Segment 1 End **/

            /***************************  Code Segment 2 - Entering data for   tblNegAttributeUserBridge  ****************************/
            int nbridgeMaxId = 0;

            if (_context.NegAttributeUserBridge.Any())
            {
                nbridgeMaxId = _context.NegAttributeUserBridge.Max(n => n.Id);
            }

            // Count of negative attributes selected
            int nbridgeCount = (vm.NegAttribute).Count;

            NegAttributeUserBridge[] negAttriUserBridge = new NegAttributeUserBridge[nbridgeCount];
            int[] negAttributeIds = new int[nbridgeCount];
            negAttributeIds = (vm.NegAttribute).ToArray();

            for (int i = 0; i < ((vm.NegAttribute).Count); i++)
            {
                nbridgeMaxId += 1;
                negAttriUserBridge[i] = UserScreeningSupport.createNegAttributeRecord(nbridgeMaxId, _userId, negAttributeIds[i]);
                _context.Add(negAttriUserBridge[i]);
            }
            _context.SaveChanges();

            /** Code Segment 2 End **/

            return View();
        }

        [HttpGet]
        public IActionResult QuestionSet()
        {
            if (_context.ScreeningAnswer.Any())
            {
                List<ScreeningAnswer> tableList = new List<ScreeningAnswer>();

                tableList = (from a in _context.ScreeningAnswer
                             where a.UserId == _userId
                             select a).ToList();

                if (tableList.Any())
                {
                    var model = new QuestionSetViewModel
                    {
                    };

                    foreach (var item in tableList)
                    {
                        if (item.QuestionId == 1)
                        {
                            model.Question1 = item.Answer;                            
                        }
                        else if (item.QuestionId == 2)
                        {
                            model.Question2 = item.Answer;

                        }
                        else if (item.QuestionId == 3)
                        {
                            model.Question3 = item.Answer;

                        }
                        else if (item.QuestionId == 4)
                        {
                            model.Question4 = item.Answer;
                        }
                    }

                    return View(model);
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult QuestionSet(QuestionSetViewModel vm)
        {
            if (ModelState.IsValid)
            {
                /**Code Segment 1 - Entering data into tblScreeningAnswer **/
                int maxAnsId = 0;

                if (_context.ScreeningAnswer.Any())
                {
                    // Get the maximum id in the table, so I can increment it for the next record
                    maxAnsId = _context.ScreeningAnswer.Max(a => a.AnswerId);
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
                //Success message here
            }

            return View(vm);
        }       
    }
}
