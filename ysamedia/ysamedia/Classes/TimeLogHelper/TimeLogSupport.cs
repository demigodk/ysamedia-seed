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
        public static TblUserLog createUserLogRecord(int logid, string userid, int userlogid)
        {
            TblUserLog termItem = new TblUserLog()
            {
                LogId = logid,
                UserId = userid,
                UserLogId = userlogid
            };

            return termItem;
        }        

        public List<TblLog> getLogId(DateTime date)
        {
            List<TblLog> LogList = new List<TblLog>();

            LogList = (from u in _context.TblLog
                       where u.Date == date
                       select u).ToList();

            return LogList;
        }       

        // Returns a List<TblUser> containing all the records returned from the select query
        public List<TblUser> getUserName(ShowLogViewModel vm)
        {
            List<TblUser> showLVM = new List<TblUser>();

            DateTime date = DateTime.Parse(vm.date);

            showLVM = (from l in _context.TblLog
                       join c in _context.TblUserLog on l.LogId equals c.LogId
                       join u in _context.TblUser on c.UserId equals u.UserId
                       where c.UserId == u.UserId && l.TimeInId == vm.timeInId && l.Date == date
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
