using System;
namespace ConnectTaxiAPI.Models
{
    public class Response
    {
        public bool Status { get; set; }
        public string Description { get; set; }
    }

    public class AddRecordResponse : Response
    {
        public int Id { get; set; }
    }
}
