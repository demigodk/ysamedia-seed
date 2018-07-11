using System.ComponentModel.DataAnnotations;

namespace ysamedia.Models.UserProfileViewModel
{
    public class UserPhotoViewModel
    {
        [Key]
        public int PhotoId { get; set; }
        
        public string Photo { get; set; }

        public string PhotoName { get; set; }
        
        public string UserId { get; set; }

        public string StatusMessage { get; set; }
    }
}
