using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Models
{
    public class CurrentBooking
    {
        public int Id { get; set; }
        public int CurrentClientId { get; set; }
        public Client CurrentClient { get; set; }


        public int CurrentRoomNumber { get; set; }
        public Room CurrentRoom { get; set; }
    }
}