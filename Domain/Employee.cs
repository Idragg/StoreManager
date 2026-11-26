using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class Employee
{
    public int Id { get; set; }
    [Length(5,30)]
    [Required] public string FirstName { get; set; }
    [Length(5, 40)]
    [Required] public string LastName { get; set; }

    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public string Email { get; set; }

    [Required] public Store Store { get; set; }


    /*
     email regex
     ^ – begin van de string.
    [^@\s]+ – één of meer tekens die geen @ of whitespace zijn.
    @ – verplicht @-teken.
    [^@\s]+ – domeinnaamgedeelte.
    \. – letterlijk een punt.
    [^@\s]+ – een gedeelte na de punt.
    $ – einde van de string.
    */
}