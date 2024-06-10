using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEfotobudka_githubik
{
    public class Connection
    {
        public static SqlConnection doConnection() {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=Itogovaya;Integrated Security=True");
            // 
            return conn;
        }
    }
}
