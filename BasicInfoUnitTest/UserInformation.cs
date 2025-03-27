using System.ComponentModel.DataAnnotations;

public class UserInformation
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string HouseNumber { get; set; }
    public string Street { get; set; }
    public string Barangay { get; set; }
    public string City { get; set; }
    public string Municipality { get; set; }
    public string Country { get; set; }
}
