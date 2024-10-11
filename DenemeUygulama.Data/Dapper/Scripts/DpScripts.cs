using DenemeUygulama.Data.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Dapper.Scripts
{
    public static class DpScripts
    {
        public static string TBLCASABIT_Select = $"select {nameof(TBLCASABIT.SUBE_KODU)},{nameof(TBLCASABIT.ISLETME_KODU)},{nameof(TBLCASABIT.CARI_KOD)} from {nameof(TBLCASABIT)}";
        public static string TBLCASABIT_SelectWhereTarih = $"select {nameof(TBLCASABIT.SUBE_KODU)},{nameof(TBLCASABIT.ISLETME_KODU)},{nameof(TBLCASABIT.CARI_KOD)} from {nameof(TBLCASABIT)} where KAYITTARIHI>@KAYITTARIHI";
    }

}
