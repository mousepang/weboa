using System;

namespace WebOa.Models
{
    public class KucunTable
    {
        public int id { get; set; }
        public string daqu { get; set; }
        public string fuwuqi { get; set; }
        public int kucun { get; set; }

        private DateTime _updatetime;
        public DateTime updatetime {
            get
            {
                if(_updatetime == null)
                {
                  _updatetime = DateTime.Now;
                }
                return _updatetime;
            }
            set
            {
                    _updatetime = value;
            }
        }
        public int reservation { get; set; }

        private string _Appointee;
        public string Appointee {
            get
            {
                if(string.IsNullOrEmpty(_Appointee))
                {
                    _Appointee = "noone";
                }
                return _Appointee;
            }
            set
            {
                _Appointee = value;
            }
        }
    }
}
