using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(25)")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "dd")]
        public string? FirstName { get; set; }

        [Column(TypeName = "varchar(25)")]
        [StringLength(25, MinimumLength = 3)]
        [Required]
        public string? LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string? PhoneNumber { get; set; }

        [InverseProperty("Client")]
        public ICollection<Credit> Credits { get; set; }
        [InverseProperty("CurrentClient")]
        public ICollection<CurrentBooking> CurrentBookings { get; set; }
        [InverseProperty("PreviousClient")]
        public ICollection<PreviousBooking> PreviousBookings { get; set; }
        public Client()
        {
            CurrentBookings = new HashSet<CurrentBooking>();
            PreviousBookings = new HashSet<PreviousBooking>();
            Credits = new HashSet<Credit>();
        }



    }
}