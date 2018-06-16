using System;

namespace ysamedia.Models.ChurchViewModels
{
    public class ChurchViewModel
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int AgeGroupId { get; set; }

        public int MaritalStatusId { get; set; }

        public int OccupationId { get; set; }

        public string PhoneNumber { get; set; }

        public string HomeNumber { get; set; }

        public string WorkNumber { get; set; }

        public string PhysicalAddress { get; set; }


    }
}
