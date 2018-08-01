using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ysamedia.Classes.TimeLogHelper;
using ysamedia.Entities;
using ysamedia.Models.TimeLogViewModels;

namespace ysamedia.Controllers
{
    [Authorize(Roles = "Administrator, Admin, Guest, Member")]    
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
            // Getting and binding the User entries for Multiselect
            List<User> UserList = new List<User>();            

            UserList = (from u in _context.User
                        select u).ToList();            

            ViewBag.ListOfUsers = UserList;

            // Getting and binding the TimeIn entries for dropdown selection
            List<TimeIn> TimeList = new List<TimeIn>();

            TimeList = (from t in _context.TimeIn
                        select t).ToList();

            ViewBag.ListOfTimes = TimeList;

            return View();
        }


        [HttpPost]
        public IActionResult Index(TimeLogViewModel vm)
        {
            
            if (ModelState.IsValid)
            {

                // Get the maximum PK in Log
                int maxLogId = 0;

                if (_context.Log.Any())
                {
                    maxLogId = _context.Log.Max(t => t.LogId);
                }

                // Get the maximum PK in UserLog
                int userLogMaxId = 0;

                if (_context.UserLog.Any())
                {
                    userLogMaxId = _context.UserLog.Max(t => t.UserLogId);
                }

                // The date selected by the user (goes in Log)
                DateTime enteredDate = DateTime.Parse(vm.date);

                // Write the Log record
                Log Log = new Log
                {                    
                    Date = enteredDate,
                    TimeInId = vm.TimeInID
                };
                _context.Add(Log);
                _context.SaveChanges();


                int tempLogId = 0;
                tempLogId = (maxLogId + 1);

                int count = (vm.SelectedIDArray).Count;

                UserLog[] tempULog = new UserLog[count];
                string[] userkeys = new string[count];
                userkeys = (vm.SelectedIDArray).ToArray();

                for(int i = 0; i < ((vm.SelectedIDArray).Count); i++)
                {
                    userLogMaxId += 1;
                    tempULog[i] = TimeLogSupport.createUserLogRecord(tempLogId, userkeys[i], userLogMaxId);
                    _context.Add(tempULog[i]);
                }

                _context.SaveChanges();
                
                return RedirectToAction("ShowLog", vm);
            }

            return View();           
        }       

        [HttpGet]
        public IActionResult DisplayLog()
        {
            // Getting and binding the TimeIn entries for dropdown selection
            List<TimeIn> TimeList = new List<TimeIn>();

            TimeList = (from t in _context.TimeIn
                        select t).ToList();

            ViewBag.ListOfTimes = TimeList;

            return View();
        }

        // Allows the user to select a date for displayings logs entered on that date
        [HttpPost]
        public IActionResult DisplayLog(TimeLogViewModel vm)
        {
            DateTime tempDate = DateTime.Parse(vm.date);

            ViewBag.TheDate = tempDate;

            TimeLogSupport timeLogSupport = new TimeLogSupport(_context);
            
            return RedirectToAction("ShowLog", vm);            
        }

        [HttpGet]
        public IActionResult ShowLog(DateTime date, TimeLogViewModel vm)
        {
            TimeLogSupport timeLogSupport = new TimeLogSupport(_context);

            string dt = date.ToString("yyyy/MM/dd");                        
            
            ViewBag.TheDate = dt;

            ViewBag.TheCategory = timeLogSupport.getTimeInCategory(vm.TimeInID);
            
            return View(timeLogSupport.getUserName(vm));           
        }                                     
    }
}
