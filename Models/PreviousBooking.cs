using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Models
{
    public class PreviousBooking
    {
        public int Id { get; set; }
        public int PreviousClientId { get; set; }
        public Client PreviousClient { get; set; }


        public int PreviousRoomNumber { get; set; }
        public Room PreviousRoom { get; set; }
    }
}