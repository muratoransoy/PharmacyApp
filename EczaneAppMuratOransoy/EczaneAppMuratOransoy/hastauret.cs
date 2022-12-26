using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneAppMuratOransoy
{

    public class hastauret
    {
        private string _Ad;
        private string _tcNo;
      
        public int id { get; set; }

        public string tcNo {
            get { return _tcNo; }
            set
            {
               
                string yıldız = "";
                for (int i = 3; i < 12; i++)
                {
                    yıldız += '*';
                }
                _tcNo = value.Substring(0, 3) + yıldız + value.Substring(8, 3);

            }
        }

        public string AdSoyad
        {
            get { return _Ad; }
            set { _Ad = value.ToUpper(); }
        }
        public string sosyal { get; set; }
        public string telNo { get; set; }
    }
    
}
