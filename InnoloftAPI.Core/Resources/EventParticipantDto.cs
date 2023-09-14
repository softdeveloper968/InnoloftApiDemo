using System.ComponentModel.DataAnnotations;

namespace InnoloftAPI.Core.Resources
{
    public class ParticipantsViewModel
    {
        public int ID { get; set; }
        public int EventID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

        [Url(ErrorMessage = "Invalid website URL format.")]
        public string Website { get; set; }

        public string AddressStreet { get; set; }
        public string AddressSuite { get; set; }
        public string AddressCity { get; set; }

        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid zipcode format.")]
        public string AddressZipcode { get; set; }

        [RegularExpression(@"^-?\d+\.\d+$", ErrorMessage = "Invalid latitude format.")]
        public string GeoLat { get; set; }

        [RegularExpression(@"^-?\d+\.\d+$", ErrorMessage = "Invalid longitude format.")]
        public string GeoLng { get; set; }

        public string CompanyName { get; set; }
        public string CompanyCatchPhrase { get; set; }
        public string CompanyBs { get; set; }
    }
}
