using System;

namespace WebOa.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime Dt { set; get; } = DateTime.Now;
    }
}
