using System;

namespace EzPaymentBot.Dao.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Txid { get; set; }
        public bool Access { get; set; }
    }
}
