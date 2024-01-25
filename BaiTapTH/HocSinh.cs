using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTH
{
    internal class HocSinh
    {
        private string name;
        private string address;
        private string ID;
        private DateTime birthday;
        public HocSinh(string name, string address,  DateTime birthday, string iD)
        {
            this.name = name;
            this.address = address;
            this.birthday = birthday;
            this.ID = iD;    
        }
    }
}
