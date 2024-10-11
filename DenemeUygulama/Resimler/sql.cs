using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKULOTOMASYON3.Resources
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=OkulDB;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
