using ysamedia.Entities;

namespace ysamedia.Classes.ChurchMemberHelper
{
    public class MemberHelper
    {
        private readonly ysamediaDbContext _context;

        public MemberHelper(ysamediaDbContext context)
        {
            _context = context;
        }

        public static string getProvince(int selectedValue)
        {
            string province = "";

            switch (selectedValue)
            {
                case 1:
                    province = "Gauteng";
                    break;

                case 2:
                    province = "Limpopo";
                    break;

                case 3:
                    province = "Mpumalanga";
                    break;

                case 4:
                    province = "Kwazulu Natal";
                    break;

                case 5:
                    province = "Free State";
                    break;

                case 6:
                    province = "North West";
                    break;

                case 7:
                    province = "Northern Cape";
                    break;

                case 8:
                    province = "Western Cape";
                    break;

                case 9:
                    province = "Eastern Cape";
                    break;
            }

            return province;
        }
    }
}
