using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.Models
{
    public class DisplayPersonModel
    {
        //Validation front end via Data Annotation
        [Required]
        [StringLength(15, ErrorMessage = "Name too long!")]
        [MinLength(5, ErrorMessage = "Name too short!")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
