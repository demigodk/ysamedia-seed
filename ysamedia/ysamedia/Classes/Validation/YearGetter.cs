/**
 * @author      :   Bondo Kalombo
 * @date        :   2018-06-20
 * 
 * Summary - When the user submits the registration form, the pass along the Values for DayId, MonthId and YearId.
 * The other two values correspond to the Day and Month in those Lists. So I had to get the Corresponding YearId
 * value by way of the getYearOfBirth(int year) method implemented in this class.
 * **/
namespace ysamedia.Classes.Validation
{
    public class YearGetter
    {
        /***************** Gets the Year corresponding to the YearId chosen by the User *******************/
        public int getYearOfBirth(int year)
        {
            int tempYear = 0;

            switch (year)
            {
                case 1:
                    tempYear = 2008;
                    break;
                case 2:
                    tempYear = 2007;
                    break;
                case 3:
                    tempYear = 2006;
                    break;
                case 4:
                    tempYear = 2005;
                    break;
                case 5:
                    tempYear = 2004;
                    break;
                case 6:
                    tempYear = 2003;
                    break;
                case 7:
                    tempYear = 2002;
                    break;
                case 8:
                    tempYear = 2001;
                    break;
                case 9:
                    tempYear = 2000;
                    break;
                case 10:
                    tempYear = 1999;
                    break;
                case 11:
                    tempYear = 1998;
                    break;
                case 12:
                    tempYear = 1997;
                    break;
                case 13:
                    tempYear = 1996;
                    break;
                case 14:
                    tempYear = 1995;
                    break;
                case 15:
                    tempYear = 1994;
                    break;
                case 16:
                    tempYear = 1993;
                    break;
                case 17:
                    tempYear = 1992;
                    break;
                case 18:
                    tempYear = 1991;
                    break;
                case 19:
                    tempYear = 1990;
                    break;
                case 20:
                    tempYear = 1989;
                    break;
                case 21:
                    tempYear = 1988;
                    break;
                case 22:
                    tempYear = 1987;
                    break;
                case 23:
                    tempYear = 1986;
                    break;
                case 24:
                    tempYear = 1985;
                    break;
                case 25:
                    tempYear = 1984;
                    break;
                case 26:
                    tempYear = 1983;
                    break;
                case 27:
                    tempYear = 1982;
                    break;
                case 28:
                    tempYear = 1981;
                    break;
                case 29:
                    tempYear = 1980;
                    break;
                case 30:
                    tempYear = 1979;
                    break;
                case 31:
                    tempYear = 1978;
                    break;
                case 32:
                    tempYear = 1977;
                    break;
                case 33:
                    tempYear = 1976;
                    break;
                case 34:
                    tempYear = 1975;
                    break;
                case 35:
                    tempYear = 1974;
                    break;
                case 36:
                    tempYear = 1973;
                    break;
                case 37:
                    tempYear = 1972;
                    break;
                case 38:
                    tempYear = 1971;
                    break;
                case 39:
                    tempYear = 1970;
                    break;
                case 40:
                    tempYear = 1969;
                    break;
                case 41:
                    tempYear = 1968;
                    break;
                case 42:
                    tempYear = 1967;
                    break;
                case 43:
                    tempYear = 1966;
                    break;
                case 44:
                    tempYear = 1965;
                    break;
                case 45:
                    tempYear = 1964;
                    break;
                case 46:
                    tempYear = 1963;
                    break;
                case 47:
                    tempYear = 1962;
                    break;
                case 48:
                    tempYear = 1961;
                    break;
                case 49:
                    tempYear = 1960;
                    break;
                case 50:
                    tempYear = 1959;
                    break;
                case 51:
                    tempYear = 1958;
                    break;
                case 52:
                    tempYear = 1957;
                    break;
                case 53:
                    tempYear = 1956;
                    break;
                case 54:
                    tempYear = 1955;
                    break;
                case 55:
                    tempYear = 1954;
                    break;
                case 56:
                    tempYear = 1953;
                    break;
                case 57:
                    tempYear = 1952;
                    break;
                case 58:
                    tempYear = 1951;
                    break;
                case 59:
                    tempYear = 1950;
                    break;
                case 60:
                    tempYear = 1949;
                    break;
                case 61:
                    tempYear = 1948;
                    break;               
            }

            return tempYear;
        }
    }
}
