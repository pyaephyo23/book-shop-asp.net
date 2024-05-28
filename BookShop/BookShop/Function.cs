using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BookShop
{
    public class Function
    {
        

        public Function() {
            string constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Documents\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
        }

    }
}