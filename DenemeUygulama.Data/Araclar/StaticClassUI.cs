using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Araclar
{
    public static class StaticClassUI
    {

        //public static List<TBLCASABIT> CariListesiStatik { get; set; } = new List<TBLCASABIT>();
        //   public static List<TBLSTSABIT> StokListesiStatik { get; set; } = new List<TBLSTSABIT>();


        
      
        public static short BranchCodeYeni { get; set; } //gitaş 3. org için 0 karapınar için 1 olacak ve proje koduna işleyecek
        public static short BranchCodeProjeKodunaCevrilecek { get; set; } //gitaş 3. org için 0 karapınar için 1 olacak ve proje koduna işleyecek
        public static short BranchCodeNetsisSubesizSifir { get; set; } = 0;
        //  public static short BranchCode { get; set; } // Giriş yapılan Şubenin Kodu  //inideki şube kodu
        public static string BranchName { get; set; } // Giriş yapılan Şubenin Adı
    }
}
