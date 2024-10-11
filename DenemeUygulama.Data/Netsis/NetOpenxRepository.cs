using System;
using System.Runtime.InteropServices;
//using NetOpenX50;

namespace DenemeUygulama.Data.Netsis
{
    public class NetOpenxRepository : IDisposable
    {
        //public Kernel _kernel;
        //public Sirket _sirket;

        //public Fatura _fatura;
        //public FatUst _fatUst;
        //public FatKalem _fatKalem;

        //public Dekomas _dekomas;
        //public Dekont _dekont;

        //public Mustahsil _mustahsil;
        //public MustahsilUst _mustahsilUst;
        //public MustahsilKalem _mustahsilKalem;

        private readonly string _netsisSirket;
        private readonly int _netsisSube;
        private readonly string _netsisKullaniciAdi;
        private readonly string _netsisKullaniciSifresi;

        public NetOpenxRepository(string netsisSirket, int netsisSube, string netsisKullaniciAdi, string netsisKullaniciSifresi, NetOpenxIslemTipi islemTipi)
        {
            _netsisSirket = netsisSirket;
            _netsisSube = netsisSube;
            _netsisKullaniciAdi = netsisKullaniciAdi;
            _netsisKullaniciSifresi = netsisKullaniciSifresi;

            //_kernel = new Kernel();

            //_sirket = default(Sirket);
            //_sirket = _kernel.yeniSirket(TVTTipi.vtMSSQL, _netsisSirket, "TEMELSET", "", _netsisKullaniciAdi, _netsisKullaniciSifresi, _netsisSube);

            //switch (islemTipi)
            //{
            //    case NetOpenxIslemTipi.Fatura:
            //        _fatura = default(Fatura);
            //        _fatUst = default(FatUst);
            //        _fatKalem = default(FatKalem);
            //        break;
            //    case NetOpenxIslemTipi.Dekont:
            //        _dekomas = default(Dekomas);
            //        _dekont = default(Dekont);
            //        break;
            //    case NetOpenxIslemTipi.Kasa:
            //        break;
            //    case NetOpenxIslemTipi.Mustahsil:
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException(nameof(islemTipi), islemTipi, null);
            //}


        }

        public void Kapat()
        {
            //if (_fatKalem != null)
            //{
            //    Marshal.ReleaseComObject(_fatKalem);
            //}
            //if (_fatUst != null)
            //{
            //    Marshal.ReleaseComObject(_fatUst);
            //}
            //if (_fatura != null)
            //{
            //    Marshal.ReleaseComObject(_fatura);
            //}
            //if (_sirket != null)
            //{
            //    Marshal.ReleaseComObject(_sirket);
            //}
            //_sirket?.LogOff();

            //_kernel.FreeNetsisLibrary();
            //Marshal.ReleaseComObject(_kernel);
        }

        #region IDisposable Members
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            //if (!this.disposed)
            //{
            //    if (disposing)
            //    {
            //        if (_fatKalem != null)
            //        {
            //            Marshal.ReleaseComObject(_fatKalem);
            //        }
            //        if (_fatUst != null)
            //        {
            //            Marshal.ReleaseComObject(_fatUst);
            //        }
            //        if (_fatura != null)
            //        {
            //            Marshal.ReleaseComObject(_fatura);
            //        }
            //        if (_sirket != null)
            //        {
            //            Marshal.ReleaseComObject(_sirket);
            //        }
            //        _sirket?.LogOff();

            //        _kernel.FreeNetsisLibrary();
            //        Marshal.ReleaseComObject(_kernel);
            //    }
            //}

            //this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    public enum NetOpenxIslemTipi
    {
        Fatura = 1,
        Dekont = 2,
        Kasa = 3,
        Mustahsil = 4
    }

}
