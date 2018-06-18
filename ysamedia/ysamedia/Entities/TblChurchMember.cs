using System;
using System.Collections.Generic;

namespace ysamedia.Entities
{
    public partial class TblChurchMember
    {
        public TblChurchMember()
        {
            TblAnswer = new HashSet<TblAnswer>();
            TblDependant = new HashSet<TblDependant>();
            TblOccupation = new HashSet<TblOccupation>();
        }

        public int ChurchMemberId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string PhysicalAddress { get; set; }
        public DateTime? DateRegistered { get; set; }
        public int? AgeGroupId { get; set; }
        public int? RelationshipId { get; set; }
        public int GenderId { get; set; }

        public TblAgeGroup AgeGroup { get; set; }
        public TblGender Gender { get; set; }
        public TblRelationshipStatus Relationship { get; set; }
        public ICollection<TblAnswer> TblAnswer { get; set; }
        public ICollection<TblDependant> TblDependant { get; set; }
        public ICollection<TblOccupation> TblOccupation { get; set; }
    }
}
