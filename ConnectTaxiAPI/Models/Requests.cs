using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectTaxiAPI.Models
{
    [Table("requests")]
    public class Requests
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Passengers { get; set; }
        public int Duration { get; set; }
        public DateTime PickupDate { get; set; }
        public string PickupTime { get; set; }
        public DateTime ReturnDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Promo { get; set; }
        [ForeignKey("vehicle_models")]
        public VehicleModels VehicleModel { get; set; }
        [Dapper.IgnoreInsert]
        public Vehicles Vehicle { get; set; }
        public int Status { get; set; }
    }
}
