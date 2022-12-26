using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneAppMuratOransoy
{
    public class ilackaydetbilgi
    {
        private string _IlacAdi;
        private string _UreticiFirme;
        private string _KullanimAmaci;
        private string _YanEtkileri;
        private string _kullanim;
        private string _İlaciTeslimi;
        
        public int id { get; set; }
        public int BarkodNo { get; set; }
        public string IlacAdi {
            get { return _IlacAdi; }
            set { _IlacAdi = value.ToUpper(); }
        } 
        public string UreticiFirme
        {
            get { return _UreticiFirme; }
            set { _UreticiFirme = value.ToUpper(); }
        }
        public int KutuSayisi { get; set; }
        public int Fiyati { get; set; }
        public string KullanimAmaci
        {
            get { return _KullanimAmaci; }
            set { _KullanimAmaci = value.ToUpper(); }
        }
        public string YanEtkileri
        {
            get { return _YanEtkileri; }
            set { _YanEtkileri = value.ToUpper(); }
        }
        public string kullanim
        {
            get { return _kullanim; }
            set { _kullanim = value.ToUpper(); }
        }
        public string İlaciTeslim
        {
            get { return _İlaciTeslimi; }
            set { _İlaciTeslimi = value.ToUpper(); }
        }

        
    }
}
