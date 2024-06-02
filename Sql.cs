using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul_Sistemi
{
    class Sql
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglantı = new SqlConnection("Data Source=EMRE_SEFEROGLU\\SQLEXPRESS;Initial Catalog=eokulsistem;Integrated Security=True;Encrypt=False");
            baglantı.Open();
            return baglantı;
        }
    }
}
