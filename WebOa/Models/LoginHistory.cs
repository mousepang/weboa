using System;

namespace WebOa.Models
{
    public class LoginHistory
    {
       public int id { get; set; }
        public string userName { get; set; }
        public DateTime loginTime { get; set; }
        public string ipAddress { get; set; }
    }
}
