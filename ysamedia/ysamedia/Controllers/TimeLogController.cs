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
            
            if (ModelState.IsValid)
            {

                // Get the maximum PK in tblLog
                int maxLogId = 0;

                if (_context.TblLog.Any())
                {
                    maxLogId = _context.TblLog.Max(t => t.LogId);
                }

                // Get the maximum PK in tblUserLog
                int userLogMaxId = 0;

                if (_context.TblUserLog.Any())
                {
                    userLogMaxId = _context.TblUserLog.Max(t => t.UserLogId);
                }

                // The date selected by the user (goes in tblLog)
                DateTime enteredDate = DateTime.Parse(vm.date);

                // Write the Log record
                TblLog Log = new TblLog
                {
                    LogId = (maxLogId + 1),
                    Date = enteredDate,
                    TimeInId = vm.TimeInID
                };
                _context.Add(Log);
                _context.SaveChanges();


                int tempLogId = 0;
                tempLogId = (maxLogId + 1);

                int count = (vm.SelectedIDArray).Count;

                TblUserLog[] tempULog = new TblUserLog[count];
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
            // Getting and binding the tblTimeIn entries for dropdown selection
            List<TblTimeIn> TimeList = new List<TblTimeIn>();

            TimeList = (from t in _context.TblTimeIn
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
