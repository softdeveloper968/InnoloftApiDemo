using System.ComponentModel.DataAnnotations;

public class Participant
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }
    public string AddressStreet { get; set; }
    public string AddressSuite { get; set; }
    public string AddressCity { get; set; }
    public string AddressZipcode { get; set; }
    public string GeoLat { get; set; }
    public string GeoLng { get; set; }
    public string CompanyName { get; set; }
    public string CompanyCatchPhrase { get; set; }
    public string CompanyBs { get; set; }

}
