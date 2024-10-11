using DenemeUygulama.Data.Araclar;
using DenemeUygulama.Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Tools
{
    public static class FrmHelper
    {

        public static tKullanici AktifKullanici { get; set; }
        public static string appPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        public static IniFile myIni = new IniFile(appPath + "\\Cn.cfg");
    }
}
