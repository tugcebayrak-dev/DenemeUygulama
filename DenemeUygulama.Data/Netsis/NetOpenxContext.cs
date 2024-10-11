namespace DenemeUygulama.Data.Netsis
{
    public class NetOpenxContext
    {
        public static NetOpenxRepository Create(string netsisSirket, int netsisSube, string netsisKullaniciAdi, string netsisKullaniciSifresi, NetOpenxIslemTipi islemTipi)
        {
            return new NetOpenxRepository(netsisSirket, netsisSube, netsisKullaniciAdi, netsisKullaniciSifresi, islemTipi);
        }
    }
}
