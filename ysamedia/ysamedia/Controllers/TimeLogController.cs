using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ysamedia.Entities;
using ysamedia.Models.TimeLogViewModels;

namespace ysamedia.Controllers
{
    //[Authorize(Roles = "Administrator, Admin")]    
    public class TimeLogController : Controller
    {

        private readonly ysamediaDbContext _context;

        public TimeLogController(ysamediaDbContext context)
        {            
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            // Getting and binding the tblUser entries for Multiselect
            List<TblUser> UserList = new List<TblUser>();            

            UserList = (from u in _context.TblUser
                        select u).ToList();

            ViewBag.ListOfUsers = UserList;

            // Getting and binding the tblTimeIn entries for dropdown selection
            List<TblTimeIn> TimeList = new List<TblTimeIn>();

            TimeList = (from t in _context.TblTimeIn
                        select t).ToList();

            ViewBag.ListOfTimes = TimeList;

            return View();
        }


        [HttpPost]
        public IActionResult Index(TimeLogViewModel vm)
        {
            int maxId = 0;

            if (_context.TblLog.Any())
            {
                maxId = _context.TblLog.Max(t => t.LogId);
            }

            int userLogMaxId = 0;

            if (_context.TblUserLog.Any())
            {
                userLogMaxId = _context.TblUserLog.Max(t => t.UserLogId);
            }

            if (ModelState.IsValid)
            {
                DateTime enteredDate = DateTime.Parse(vm.date);

                TblLog Log = new TblLog
                {
                    LogId = (maxId + 1),
                    Date = enteredDate,
                    TimeInId = vm.TimeInID
                };
                _context.Add(Log);
                _context.SaveChanges();

                int tempLogId = 0;
                tempLogId = (maxId + 1);

                int count = (vm.SelectedIDArray).Count;

                TblUserLog[] tempULog = new TblUserLog[count];
                string[] userkeys = new string[count];
                userkeys = (vm.SelectedIDArray).ToArray();

                for(int i = 0; i < ((vm.SelectedIDArray).Count); i++)
                {
                    userLogMaxId += 1;
                    tempULog[i] = createUserLogRecord(tempLogId, userkeys[i], userLogMaxId);
                    _context.Add(tempULog[i]);
                }

                _context.SaveChanges();
                
                return RedirectToAction("ShowIDs", vm);
            }

            return View();           
        }

        private static TblUserLog createUserLogRecord(int logid, string userid, int userlogid)
        {
            TblUserLog termItem = new TblUserLog()
            {
                LogId = logid,
                UserId = userid,
                UserLogId = userlogid
            };

            return termItem;
        }
       
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }    

        public IActionResult ShowIDs(TimeLogViewModel vm)
        {
            List<string> tempList = vm.SelectedIDArray;            
            return View(tempList);
        }
    }
}
