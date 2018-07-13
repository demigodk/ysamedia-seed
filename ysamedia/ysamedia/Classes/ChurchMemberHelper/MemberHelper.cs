using System;
using System.Collections.Generic;
using System.Linq;
using ysamedia.Entities;
using ysamedia.Models.ChurchViewModels;

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

        public CompleteViewModel getViewModel(int recordId)
        {
            CompleteViewModel tempModel = new CompleteViewModel();

            List<TblChurchMember> churchMember = (from c in _context.TblChurchMember
                                                  where c.ChurchMemberId == recordId
                                                  select c).ToList();

            foreach (var item in churchMember)
            {
                tempModel.FirstName = item.FirstName;
                tempModel.Surname = item.LastName;

                if (item.GenderId == 1)
                {
                    tempModel.GenderId = "Male";
                }
                else if (item.GenderId == 2)
                {
                    tempModel.GenderId = "Female";
                }
                else
                {
                    tempModel.GenderId = "Unspecified";
                }

                // Handling the date of Birth
                string DOB = item.DateOfBirth;                
                string[] stringSeparators = new string[] { "/" };
                string[] result;
               
                result = DOB.Split(stringSeparators, StringSplitOptions.None);

                for (int i = 0; i < result.Length; i++)
                {
                    if (i == 0)
                    {
                        tempModel.Day = Convert.ToInt32(result[i]);
                    }
                    else if (i == 1)
                    {
                        tempModel.Month = Convert.ToInt32(result[i]);
                    }
                    else if (i == 2)
                    {
                        tempModel.Year = result[i];
                    }
                }

                // Physical Address 
                tempModel.Street = item.Street;
                tempModel.City = item.City;
                tempModel.Province = item.Province;
                tempModel.PostalCode = item.PostalCode;

                tempModel.CellNumber = item.CellPhone;
                tempModel.HomeNumber = item.HomePhone;
                tempModel.WorkNumber = item.WorkPhone;
                tempModel.EmailAddress = item.Email;

                /*******************  Age Group ***********************/
                if (item.AgeGroupId == 1)
                {
                    tempModel.AGroupId = "18-25";

                }
                else if (item.AgeGroupId == 2)
                {
                    tempModel.AGroupId = "26-35";

                }
                else if (item.AgeGroupId == 3)
                {
                    tempModel.AGroupId = "36-50";

                }
                else if (item.AgeGroupId == 4)
                {
                    tempModel.AGroupId = "51-75";

                }
                else
                {
                    tempModel.AGroupId = "N/A";
                }


                /********************** From tblRelationshipStatus ********************/
                if (item.RelationshipId == 1)
                {
                    tempModel.RelationshipId = "Single";

                }
                else if (item.RelationshipId == 2)
                {
                    tempModel.RelationshipId = "Engaged";

                }
                else if (item.RelationshipId == 3)
                {
                    tempModel.RelationshipId = "Married";

                }
                else if (item.RelationshipId == 4)
                {
                    tempModel.RelationshipId = "Widow";

                }
                else if (item.RelationshipId == 5)
                {
                    tempModel.RelationshipId = "Widower";

                }
                else
                {
                    tempModel.RelationshipId = "Unspecified";
                }

                tempModel.DateRecorded = item.DateRegistered;
            }


            /****************** Record from tblDependant *********************/
            List<TblDependant> dependant = (from c in _context.TblDependant
                                            where c.ChurchMemberId == recordId
                                            select c).ToList();

            dependant.ToArray();

            for (int i = 0; i <= (dependant.Count + 1); i++)
            {
                if (i == 0)
                {
                    tempModel.NumPreschool = (dependant[i].NumDependant).ToString();

                } else if ( i == 1)
                {
                    tempModel.NumPrimary = (dependant[i].NumDependant).ToString();

                } else if (i == 2)
                {
                    tempModel.NumHigh = (dependant[i].NumDependant).ToString();

                } else if ( i == 3)
                {
                    tempModel.NumTertiary = (dependant[i].NumDependant).ToString();
                }                
            }

            /******************** From tblDependantMemberOccupationBridge **********************/
            List<TblChurchMemberOccupationBridge> occupationBridge = new List<TblChurchMemberOccupationBridge>();
            occupationBridge = (from o in _context.TblChurchMemberOccupationBridge
                                where o.ChurchMemberId == recordId
                                select o).ToList();

           foreach(var item in occupationBridge)
           {
                if (item.OccupationId == 1)
                {
                    tempModel.OccupationId = "Student";

                }
                else if (item.OccupationId == 2)
                {
                    tempModel.OccupationId = "Internship";

                }
                else if (item.OccupationId == 3)
                {
                    tempModel.OccupationId = "Employed";

                }
                else if (item.OccupationId == 4)
                {
                    tempModel.OccupationId = "Self-Employed";
                }
                else
                {
                    tempModel.OccupationId = "Other";
                }
            }

            /****************** From tblAnswer ***********************/
            List<TblAnswer> answers = new List<TblAnswer>();
            answers = (from a in _context.TblAnswer
                       where a.ChurchMemberId == recordId
                       select a).ToList();

            answers.ToArray();

            for (int i = 0; i < (answers.Count+1); i++)
            {                
                if (i == 0)
                {
                    tempModel.Question1 = answers[i].Answer;
                }
                else if (i == 1)
                {
                    tempModel.Question2 = answers[i].Answer;
                }
                else if (i == 2)
                {
                    tempModel.Question3 = answers[i].Answer;
                }
                else if (i == 3)
                {
                    tempModel.Question4 = answers[i].Answer;
                }
                else if (i == 4)
                {
                    tempModel.Question5 = answers[i].Answer;
                }
                else if (i == 5)
                {
                    tempModel.Question6 = answers[i].Answer;
                }
            }
                        
            return tempModel;
        }
    }
}
