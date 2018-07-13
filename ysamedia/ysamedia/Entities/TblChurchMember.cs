using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblChurchMember
    {
        public TblChurchMember()
        {
            TblAnswer = new HashSet<TblAnswer>();
            TblChurchMemberOccupationBridge = new HashSet<TblChurchMemberOccupationBridge>();
            TblDependant = new HashSet<TblDependant>();
        }

        public int ChurchMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
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

        public TblAgeGroup AgeGroup { get; set; }
        public TblGender Gender { get; set; }
        public TblRelationshipStatus Relationship { get; set; }
        public ICollection<TblAnswer> TblAnswer { get; set; }
        public ICollection<TblChurchMemberOccupationBridge> TblChurchMemberOccupationBridge { get; set; }
        public ICollection<TblDependant> TblDependant { get; set; }
    }
}
