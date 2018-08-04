using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ysamedia.Models.DepartmentViewModels
{
    public class DepartmentMemberViewModel
    {
        [Key]
        public int DepartmentId { get; set; }

        [Display(Name = "Lead")]    // Named so for display purposes
        public string DepartmentLeaderId { get; set; }

        [Display(Name = "Number Of Members")]
        public int? NumMembers { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Display(Name = "Lead")]
        public string DepartmentLead { get; set; }

        [Display(Name = "Deputy")]  // Named so for display purposes
        public string DeputyId { get; set; }

        [Display(Name = "Deputy")]
        public string Deputy { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select at least one user")]
        public List<string> SelectedIDArray { get; set; }               // Needed for MultiSelectList in order to add Users to a Department
    }
}
