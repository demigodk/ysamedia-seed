using System;
using System.Linq;
using System.Collections.Generic;
using ysamedia.Entities;
using ysamedia.Models.TimeLogViewModels;

namespace ysamedia.Classes.TimeLogHelper
{
    public class TimeLogSupport
    {

        private readonly ysamediaDbContext _context;

        public TimeLogSupport(ysamediaDbContext context)
        {
            _context = context;
        }

        // Enters the UserLog record into the table, using the specified parameters
        public static UserLog createUserLogRecord(int logid,string userid, int userlogid)
        {
            UserLog termItem = new UserLog()
            {
                LogId = logid,
                UserId = userid,
                UserLogId = userlogid
            };

            return termItem;
        }        

        public List<Log> getLogId(DateTime date)
        {
            List<Log> LogList = new List<Log>();

            LogList = (from u in _context.Log
                       where u.Date == date
                       select u).ToList();

            return LogList;
        }       

        // Returns a List<User> containing all the records returned from the select query
        public List<User> getUserName(TimeLogViewModel vm)
        {
            List<User> showLVM = new List<User>();

            DateTime date = DateTime.Parse(vm.date);

            showLVM = (from l in _context.Log
                       join c in _context.UserLog on l.LogId equals c.LogId
                       join u in _context.User on c.UserId equals u.UserId
                       where c.UserId == u.UserId && l.TimeInId == vm.TimeInID && l.Date == date
                       select u).ToList();

            return showLVM;

        }

        public string getTimeInCategory(int categoryId)
        {
            string category = null;

            switch (categoryId)
            {
                case 1:
                    category = "Before 08:00 AM";
                    break;
                case 2:
                    category = "Before 08:15 AM";
                    break;
                case 3:
                    category = "Before 08:30";
                    break;

                case 4:
                    category = "After 08:30";
                    break;

                case 5:
                    category = "Absent";
                    break;
            }

            return category;
        }
    }        
}
