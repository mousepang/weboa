using System;

namespace WebOa.Models
{
    public class Account
    {
        public int id { set; get; }
        public string account { set; get; }
        public string password { set; get; }

        private DateTime _loginTime;
        public DateTime loginTime
        {
            get
            {
                if (_loginTime == null)
                {
                    _loginTime = DateTime.Now.AddHours(8);
                }
                return _loginTime;
            }
            set
            {
                _loginTime = value;
            }
        }
        private DateTime _createTime;
        public DateTime createTime
        {
            get
            {
                if (_createTime == null)
                {
                    _createTime = DateTime.Now.AddHours(8);
                }
                return _createTime;
            }
            set
            {
                _createTime = value;
            }
        }

        public int state { get; set; }

        public string Role { get; set; }
    }
}
