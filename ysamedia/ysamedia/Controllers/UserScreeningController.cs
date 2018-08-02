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
                /************************* Code Segment 1 - Entering Data For RatingQuestion ****************************************/                
                _context.RatingAnswer.AddRange(
                    new RatingAnswer { Rating = vm.RQuestion1, QuestionId = 1 },
                    new RatingAnswer { Rating = vm.RQuestion2, QuestionId = 2 },
                    new RatingAnswer { Rating = vm.RQuestion3, QuestionId = 3 },
                    new RatingAnswer { Rating = vm.RQuestion4, QuestionId = 4 },
                    new RatingAnswer { Rating = vm.RQuestion5, QuestionId = 5 },
                    new RatingAnswer { Rating = vm.RQuestion6, QuestionId = 6 },
                    new RatingAnswer { Rating = vm.RQuestion7, QuestionId = 7 },
                    new RatingAnswer { Rating = vm.RQuestion8, QuestionId = 8 },
                    new RatingAnswer { Rating = vm.RQuestion9, QuestionId = 9 },
                    new RatingAnswer { Rating = vm.RQuestion10, QuestionId = 10 },
                    new RatingAnswer { Rating = vm.RQuestion11, QuestionId = 11 },
                    new RatingAnswer { Rating = vm.RQuestion12, QuestionId = 12 },
                    new RatingAnswer { Rating = vm.RQuestion13, QuestionId = 13 },
                    new RatingAnswer { Rating = vm.RQuestion14, QuestionId = 14 },
                    new RatingAnswer { Rating = vm.RQuestion15, QuestionId = 15 },
                    new RatingAnswer { Rating = vm.RQuestion16, QuestionId = 16 }
                    );

                _context.SaveChanges();

                /*************************************** RateAnserBridge ********************************************/

                int ratingMaxId = 0;        // Max ID in RatingAnswer

                if (_context.RatingAnswer.Any())
                {
                    ratingMaxId = _context.RatingAnswer.Max(r => r.AnswerId);
                }               

                _context.RateAnswerUserBridge.AddRange(
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 1) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 2) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 3) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 4) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 5) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 6) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 7) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 8) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 9) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 10) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 11) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 12) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 13) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 14) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 15) },
                    new RateAnswerUserBridge { UserId = _userId, AnswerId = (ratingMaxId + 16) }
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
            // Getting and binding the Attribute entries for Multiselect
            List<PositiveAttribute> PosAttributeList = new List<PositiveAttribute>();

            PosAttributeList = (from p in _context.PositiveAttribute
                                select p).ToList();

            ViewBag.ListPosAttri = PosAttributeList;

            // Getting and binding the NegativeAttribute table
            List<NegativeAttribute> NegAttributeList = new List<NegativeAttribute>();

            NegAttributeList = (from n in _context.NegativeAttribute
                                select n).ToList();

            ViewBag.ListNegAttri = NegAttributeList;

            return View();
        }

        [HttpPost]
        public IActionResult AttributeSet(AttributeSetViewModel vm)
        {
            /**************************** Code Segment 1 - Entering data into AttributeUserBridge table *****************/
            
            // Count of positive attributes selected
            int bridgeCount = (vm.PosAttribute).Count;

            AttributeUserBridge[] attrUserBridge = new AttributeUserBridge[bridgeCount];
            int[] attributeIds = new int[bridgeCount];
            attributeIds = (vm.PosAttribute).ToArray();

            for (int a = 0; a < ((vm.PosAttribute).Count); a++)
            {                
                attrUserBridge[a] = UserScreeningSupport.createAttributeRecord(_userId, attributeIds[a]);
                _context.Add(attrUserBridge[a]);
            }

            _context.SaveChanges();

            /** Code Segment 1 End **/

            /***************************  Code Segment 2 - Entering data for  NegAttributeUserBridge Table  ****************************/
            
            // Count of negative attributes selected
            int nbridgeCount = (vm.NegAttribute).Count;

            NegAttributeUserBridge[] negAttriUserBridge = new NegAttributeUserBridge[nbridgeCount];
            int[] negAttributeIds = new int[nbridgeCount];
            negAttributeIds = (vm.NegAttribute).ToArray();

            for (int i = 0; i < ((vm.NegAttribute).Count); i++)
            {              
                negAttriUserBridge[i] = UserScreeningSupport.createNegAttributeRecord(_userId, negAttributeIds[i]);
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
                /**Code Segment 1 - Entering data into ScreeningAnswer Table **/                
                ScreeningAnswer ScreenAnswer1 = new ScreeningAnswer
                {                   
                    UserId = _userId,
                    QuestionId = 1,
                    Answer = vm.Question1
                };
                _context.Add(ScreenAnswer1);
                _context.SaveChanges();

                ScreeningAnswer ScreenAnswer2 = new ScreeningAnswer
                {                    
                    UserId = _userId,
                    QuestionId = 2,
                    Answer = vm.Question2
                };
                _context.Add(ScreenAnswer2);
                _context.SaveChanges();

                ScreeningAnswer ScreenAnswer3 = new ScreeningAnswer
                {                   
                    UserId = _userId,
                    QuestionId = 3,
                    Answer = vm.Question3
                };
                _context.Add(ScreenAnswer3);
                _context.SaveChanges();

                ScreeningAnswer ScreenAnswer4 = new ScreeningAnswer
                {                   
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
