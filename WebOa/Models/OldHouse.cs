using System;

namespace WebOa.Models
{
    public class OldHouse
    {
        public int ID { set; get; }
        public string DataServer { set; get; }
        public string Server { set; get; }
        public int Gil { set; get; }
        public string Account { set; get; } 
        public string Password { set; get; }
        public string CreateUser { set; get; }
        public DateTime CreateTime { set; get; }
        public string LastUser { set; get; } 
        public DateTime? LastUseTime { get; set; }
    }
}
