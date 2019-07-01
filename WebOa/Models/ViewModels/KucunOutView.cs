using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOa.Models.ViewModels
{
    public class KucunOutView
    {
        public int id { get; set; }
        public string dataServer { get; set; }
        public string server { get; set; }
        public int outGil { get; set; }

        private DateTime _created_time;
        public DateTime created_time
        {
            get
            {
                if (_created_time == null)
                {
                    _created_time = DateTime.Now;
                }
                return _created_time;
            }
            set
            {
                _created_time = value;
            }
        }

        public int nowKucun { get; set; }
        public string name { get; set; }
        public string game_time { get; set; }
        public string flag { get; set; }
    }
}
