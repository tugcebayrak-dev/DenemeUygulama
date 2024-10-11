using DevExpress.Export;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DenemeUygulama.Data.Entity.Context;
using DenemeUygulama.Data.Entity.Models;
using DenemeUygulama.Data.Entity.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeUygulama.Data.Araclar
{
    public class MethodsHelper
    {



        public static string appPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

        public static bool GridLayoutKaydet(GridControl grid, string formAdi,int AktifKullaniciId)
        {
            try
            {
                //string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
                if (Environment.OSVersion.Version.Major >=7)
                {
                    appPath = Directory.GetParent(appPath).ToString();
                }
                string filename = $"{appPath}/Layout/DenemeUygulama_{AktifKullaniciId}_{formAdi}_{grid.Name}.xml";
                grid.MainView.SaveLayoutToXml(filename);
                return true;

            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Grid tasarımı kaydedilirken bir hata oluştu.Hata:" + ex.Message, "Hata");
                return false;
            }
        }
        public static void GridLayoutYukle(GridControl grid, string formAdi,int AktifKullaniciId)
        {
            //string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 7)
            {
                appPath = Directory.GetParent(appPath).ToString();
            }

            string filename = $"{appPath}/Layout/DenemeUygulama_{AktifKullaniciId}_{formAdi}_{grid.Name}.xml";
            if (File.Exists(filename))
                grid.MainView.RestoreLayoutFromXml(filename);
        }



        public static void GetYetki(NavBarItem item,int kullaniciId)
        {

            using (UnitOfWork _context = new UnitOfWork(new EFContext()))
            {
                //UIClass.LoadingPanel("Menü yetkilendirmeleri ayarlanıyor...");
                var ModulAdi = item.Caption;
                var repoModul = _context.GetRepository<tModul>();
                var entityModul = repoModul.GetAllActive(x => x.ModulAdi.Equals(ModulAdi)).FirstOrDefault();

                if (entityModul != null)
                {
                    var modul = _context.GetRepository<tKullaniciYetki>().
                   GetAllActive(k => k.KullaniciId.Equals(kullaniciId) && k.ModulId == entityModul.Id).FirstOrDefault();
                    if (modul == null)
                    {
                        item.Visible = false;

                    }
                    else
                    {
                        item.Visible = true;
                    }

                    //return modul ?? new tKullaniciYetki { Ekle=false,  Guncelle= false, Goruntule=false};
                }
                else
                {
                    item.Visible = false;
                    //return new tKullaniciYetki { Ekle = false, Guncelle = false, Goruntule = false };

                }

            }
        }

        public static void GetButonYetki(BarButtonItem item, int kullaniciId)
        {

            using (UnitOfWork _context = new UnitOfWork(new EFContext()))
            {
                //UIClass.LoadingPanel("Menü yetkilendirmeleri ayarlanıyor...");
                var ModulAdi = item.Caption;
                var repoModul = _context.GetRepository<tModul>();
                var entityModul = repoModul.GetAllActive(x => x.ModulAdi.Equals(ModulAdi)).FirstOrDefault();

                if (entityModul != null)
                {
                    var modul = _context.GetRepository<tKullaniciYetki>().
                   GetAllActive(k => k.KullaniciId.Equals(kullaniciId) && k.ModulId == entityModul.Id).FirstOrDefault();
                    if (modul == null)
                    {
                        item.Enabled = false;

                    }
                    else
                    {
                        item.Enabled = true;
                    }

                    //return modul ?? new tKullaniciYetki { Ekle=false,  Guncelle= false, Goruntule=false};
                }
                else
                {
                    item.Enabled = false;
                    //return new tKullaniciYetki { Ekle = false, Guncelle = false, Goruntule = false };

                }

            }
        }
        public static void GridExceleAktar(GridControl grid, GridView gridview)
        {

            try
            {
                using (var dialog = new SaveFileDialog())
                {

                    if (StaticClassUI.BranchCodeYeni == 0)
                    {
                        dialog.FileName = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToFileTimeUtc() + ".xlsx";
                        dialog.Title = "Raporu kaydedeceğiniz bir dizin seçiniz.";
                        dialog.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx";

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                            gridview.OptionsPrint.ExpandAllDetails = true;
                            gridview.OptionsPrint.PrintDetails = true;

                            var filename = dialog.FileName;
                            grid.ExportToXlsx(filename);

                            var msgDialog = MessageBox.Show("Dosyayı açmak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult.Yes == msgDialog)
                                Process.Start(filename);
                        }


                    }
                    else
                    {
                        // var hedefPath = Sabitler.WPF_RAPOR_URL + "KonyaRapor";
                        var hedefPath = Sabitler.WPF_RAPOR_URL + "IslemRapor";

                        if (StaticClassUI.BranchCodeYeni != 0)
                            hedefPath = Sabitler.WPF_RAPOR_URL + "IslemRapor";


                        string hedefFileName = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToFileTimeUtc() + ".xlsx";
                        string hedefFile = Path.Combine(hedefPath, hedefFileName);

                        ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                        gridview.OptionsPrint.ExpandAllDetails = true;
                        gridview.OptionsPrint.PrintDetails = true;
                        grid.ExportToXlsx(hedefFile);
                        Process.Start(hedefFile);
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya kaydedilirken bir hata oluştu. Hata:" + ex.Message);
            }
        }
    }
}
