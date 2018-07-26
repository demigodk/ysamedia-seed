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

        public static AttributeUserBridge createAttributeRecord(/*int id, */string userId, int attributeId)
        {
            AttributeUserBridge tempItem = new AttributeUserBridge()
            {
                //Id = id,
                UserId = userId,
                AttributeId = attributeId
            };

            return tempItem;
        }

        public static NegAttributeUserBridge createNegAttributeRecord(/*int id, */string userId, int attributeId)
        {
            NegAttributeUserBridge tempItem = new NegAttributeUserBridge()
            {
                //Id = id,
                UserId = userId,
                AttributeId = attributeId
            };

            return tempItem;
        }        
    }
}
