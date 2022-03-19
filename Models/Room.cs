using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Models
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        public int Capacity { get; set; }

        Section section { get; set; }

        [ForeignKey("CurrentRoomNumber")]
        [InverseProperty("CurrentRoom")]
        public ICollection<CurrentBooking> CurrentBookings { get; set; }

        [ForeignKey("PreviousRoomNumber")]
        [InverseProperty("PreviousRoom")]
        public ICollection<PreviousBooking> PreviousBookings { get; set; }

        public Room()
        {
            CurrentBookings = new HashSet<CurrentBooking>();
            PreviousBookings = new HashSet<PreviousBooking>();
        }

    }

    public enum Section
    {
        First,
        Second,
        Third
    }
}