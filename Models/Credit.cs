using System.ComponentModel.DataAnnotations;

namespace DataAnnotations.Models
{
    public class Credit
    {
        [Key]
        public int CreditNumber { get; set; }
        public bool IsValid { get; set; }

        [StringLength(20)]
        public string HolderName { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }

        public DateTime ExpiryDate { get; set; }

    }
}