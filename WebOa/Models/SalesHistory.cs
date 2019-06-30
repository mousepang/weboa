using System;

namespace WebOa.Models
{
    public class SalesHistory
    {
        public int Id { set; get; }
        public string DataServer { set; get; }
        public string Server { set; get; }
        public int Gil { set; get; }
        public decimal Price { set; get; }
        public decimal Total { set; get; }
        public string Buyers { set; get; }
        public string Seller { set; get; }
        public DateTime SellTime { set; get; }
        public string Account { set; get; }
        public string PayState { set; get; }
    }
}
