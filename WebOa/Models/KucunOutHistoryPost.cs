using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOa.Models
{
    public class KucunOutHistoryPost
    {
        public string account { get; set; }
        public List<KucunOutHistory> KucunOutHistorys { get; set; }
    }
}
