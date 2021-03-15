using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace TicketManagement4.Models
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}