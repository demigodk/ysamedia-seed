using ysamedia.Entities;

namespace ysamedia.Classes.UserScreeningHelper
{
    public class UserScreeningSupport
    {
        private readonly ysamediaDbContext _context;

        public UserScreeningSupport(ysamediaDbContext context)
        {
            _context = context;
        }

        public static TblAttributeUserBridge createAttributeRecord(int id, string userId, int attributeId)
        {
            TblAttributeUserBridge tempItem = new TblAttributeUserBridge()
            {
                Id = id,
                UserId = userId,
                AttributeId = attributeId
            };

            return tempItem;
        }

        public static TblNegAttributeUserBridge createNegAttributeRecord(int id, string userId, int attributeId)
        {
            TblNegAttributeUserBridge tempItem = new TblNegAttributeUserBridge()
            {
                Id = id,
                UserId = userId,
                AttributeId = attributeId
            };

            return tempItem;
        }
    }
}
