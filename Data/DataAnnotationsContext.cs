#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAnnotations.Models;

namespace DataAnnotations.Data
{
    public class DataAnnotationsContext : DbContext
    {
        public DataAnnotationsContext (DbContextOptions<DataAnnotationsContext> options)
            : base(options)
        {
        }

        public DbSet<DataAnnotations.Models.Client> Client { get; set; }
        public DbSet<DataAnnotations.Models.Room> Room { get; set; }
        public DbSet<DataAnnotations.Models.Credit> Credit { get; set; }
        public DbSet<DataAnnotations.Models.CurrentBooking> CurrentBooking { get; set; }
        public DbSet<DataAnnotations.Models.PreviousBooking> PreviousBooking { get; set; }
    }
}
