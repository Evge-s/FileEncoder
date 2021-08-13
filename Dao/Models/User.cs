using System;
using System.ComponentModel.DataAnnotations;

namespace EzPaymentBot.Dao.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TelegramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Txid { get; set; }
        public bool Access { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
