using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectTaxiAPI.Models
{
    [Table("users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        [ReadOnly(true)]
        public DateTime DateCreated { get; set; }
    }
}
