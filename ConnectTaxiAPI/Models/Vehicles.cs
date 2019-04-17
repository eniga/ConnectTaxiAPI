using System;
using Dapper;

namespace ConnectTaxiAPI.Models
{
    [Table("vehicles")]
    public class Vehicles : VehicleModels
    {
        [Key]
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; }
        public int Status { get; set; }
    }

    [Table("vehicle_types")]
    public class VehicleTypes
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
    }

    [Table("vehicle_models")]
    public class VehicleModels
    {
        [Key]
        public int VehicleModelId { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleManufacturerId { get; set; }
        public string VehicleManufacturer { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
    }

    [Table("vehicle_manufacturers")]
    public class VehicleManufacturers
    {
        [Key]
        public int VehicleManufacturerId { get; set; }
        public string VehicleManufacturer { get; set; }
    }
}
