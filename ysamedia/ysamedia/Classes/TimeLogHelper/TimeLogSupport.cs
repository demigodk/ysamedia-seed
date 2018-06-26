using ysamedia.Entities;

namespace ysamedia.Classes.TimeLogHelper
{
    public static class TimeLogSupport
    {

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
    }
}
