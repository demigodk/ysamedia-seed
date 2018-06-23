using System.Collections.Generic;
using ysamedia.Classes.Lists.ListItems;

namespace ysamedia.Classes.Lists
{
    public class ListContainer
    {
        public List<Day> getDayList()
        {
            List<Day> dayList = new List<Day>
            {
                new Day { DayId = 1, DayNum = 1 },
                new Day { DayId = 2, DayNum = 2 },
                new Day { DayId = 3, DayNum = 3 },
                new Day { DayId = 4, DayNum = 4 },
                new Day { DayId = 5, DayNum = 5 },
                new Day { DayId = 6, DayNum = 6 },
                new Day { DayId = 7, DayNum = 7 },
                new Day { DayId = 8, DayNum = 8 },
                new Day { DayId = 9, DayNum = 9 },
                new Day { DayId = 10, DayNum = 10 },
                new Day { DayId = 11, DayNum = 11 },
                new Day { DayId = 12, DayNum = 12 },
                new Day { DayId = 13, DayNum = 13 },
                new Day { DayId = 14, DayNum = 14 },
                new Day { DayId = 15, DayNum = 15 },
                new Day { DayId = 16, DayNum = 16 },
                new Day { DayId = 17, DayNum = 17 },
                new Day { DayId = 18, DayNum = 18 },
                new Day { DayId = 19, DayNum = 19 },
                new Day { DayId = 20, DayNum = 20 },
                new Day { DayId = 21, DayNum = 21 },
                new Day { DayId = 22, DayNum = 22 },
                new Day { DayId = 23, DayNum = 23 },
                new Day { DayId = 24, DayNum = 24 },
                new Day { DayId = 25, DayNum = 25 },
                new Day { DayId = 26, DayNum = 26 },
                new Day { DayId = 27, DayNum = 27 },
                new Day { DayId = 28, DayNum = 28 },
                new Day { DayId = 29, DayNum = 29 },
                new Day { DayId = 30, DayNum = 30 },
                new Day { DayId = 31, DayNum = 31 }
            };
            return dayList;
        }

        public List<Month> getMonthList()
        {
            List<Month> monthList = new List<Month>
            {
                new Month { MonthId = 1, Name = "Jan" },
                new Month { MonthId = 2, Name = "Feb" },
                new Month { MonthId = 3, Name = "Mar" },
                new Month { MonthId = 4, Name = "Apr" },
                new Month { MonthId = 5, Name = "May" },
                new Month { MonthId = 6, Name = "Jun" },
                new Month { MonthId = 7, Name = "Jul" },
                new Month { MonthId = 8, Name = "Aug" },
                new Month { MonthId = 9, Name = "Sep" },
                new Month { MonthId = 10, Name = "Oct" },
                new Month { MonthId = 11, Name = "Nov" },
                new Month { MonthId = 12, Name = "Dec" }
            };

            return monthList;
        }

        public List<Year> getYearList()
        {
            List<Year> yearList = new List<Year>
            {
                new Year { YearId = 1, YearNum = 2008 },
                new Year { YearId = 2, YearNum = 2007 },
                new Year { YearId = 3, YearNum = 2006 },
                new Year { YearId = 4, YearNum = 2005 },
                new Year { YearId = 5, YearNum = 2004 },
                new Year { YearId = 6, YearNum = 2003 },
                new Year { YearId = 7, YearNum = 2002 },
                new Year { YearId = 8, YearNum = 2001 },
                new Year { YearId = 9, YearNum = 2000 },

                new Year { YearId = 10, YearNum = 1999 },
                new Year { YearId = 11, YearNum = 1998 },
                new Year { YearId = 12, YearNum = 1997 },
                new Year { YearId = 13, YearNum = 1996 },
                new Year { YearId = 14, YearNum = 1995 },
                new Year { YearId = 15, YearNum = 1994 },
                new Year { YearId = 16, YearNum = 1993 },
                new Year { YearId = 17, YearNum = 1992 },
                new Year { YearId = 18, YearNum = 1991 },
                new Year { YearId = 19, YearNum = 1990 },

                new Year { YearId = 20, YearNum = 1989 },
                new Year { YearId = 21, YearNum = 1988 },
                new Year { YearId = 22, YearNum = 1987 },
                new Year { YearId = 23, YearNum = 1986 },
                new Year { YearId = 24, YearNum = 1985 },
                new Year { YearId = 25, YearNum = 1984 },
                new Year { YearId = 26, YearNum = 1983 },
                new Year { YearId = 27, YearNum = 1982 },
                new Year { YearId = 28, YearNum = 1981 },
                new Year { YearId = 29, YearNum = 1980 },

                new Year { YearId = 30, YearNum = 1979 },
                new Year { YearId = 31, YearNum = 1978 },
                new Year { YearId = 32, YearNum = 1977 },
                new Year { YearId = 33, YearNum = 1976 },
                new Year { YearId = 34, YearNum = 1975 },
                new Year { YearId = 35, YearNum = 1974 },
                new Year { YearId = 36, YearNum = 1973 },
                new Year { YearId = 37, YearNum = 1972 },
                new Year { YearId = 38, YearNum = 1971 },
                new Year { YearId = 39, YearNum = 1970 },

                new Year { YearId = 40, YearNum = 1969 },
                new Year { YearId = 41, YearNum = 1968 },
                new Year { YearId = 42, YearNum = 1967 },
                new Year { YearId = 43, YearNum = 1966 },
                new Year { YearId = 44, YearNum = 1965 },
                new Year { YearId = 45, YearNum = 1964 },
                new Year { YearId = 46, YearNum = 1963 },
                new Year { YearId = 47, YearNum = 1962 },
                new Year { YearId = 48, YearNum = 1961 },
                new Year { YearId = 49, YearNum = 1960 },

                new Year { YearId = 50, YearNum = 1959 },
                new Year { YearId = 51, YearNum = 1958 },
                new Year { YearId = 52, YearNum = 1957 },
                new Year { YearId = 53, YearNum = 1956 },
                new Year { YearId = 54, YearNum = 1955 },
                new Year { YearId = 55, YearNum = 1954 },
                new Year { YearId = 56, YearNum = 1953 },
                new Year { YearId = 57, YearNum = 1952 },
                new Year { YearId = 58, YearNum = 1951 },
                new Year { YearId = 59, YearNum = 1950 },

                new Year { YearId = 60, YearNum = 1949 },
                new Year { YearId = 61, YearNum = 1948 }
                //1948
            };

            return yearList;
        }        
    }    
}
