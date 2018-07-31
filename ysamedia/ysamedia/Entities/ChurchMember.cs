using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class ChurchMember
    {
        public int ChurchMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int? Day { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public DateTime? DateRegistered { get; set; }
        public int? AgeGroupId { get; set; }
        public int? RelationshipId { get; set; }
        public int GenderId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public int OccupationId { get; set; }
        public int? NumDepInPreSchool { get; set; }
        public int? NumDepInPrimary { get; set; }
        public int? NumDepInHighSchool { get; set; }
        public int? NumDepInTertiary { get; set; }
        public string AnswerToQ1 { get; set; }
        public string AnswerToQ2 { get; set; }
        public string AnswerToQ3 { get; set; }
        public string AnswerToQ4 { get; set; }
        public string AnswerToQ5 { get; set; }
        public string AnswerToQ6 { get; set; }

        public AgeGroup AgeGroup { get; set; }
        public Gender Gender { get; set; }
        public Occupation Occupation { get; set; }
        public RelationshipStatus Relationship { get; set; }
    }
}
