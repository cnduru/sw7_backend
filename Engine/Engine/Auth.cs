﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static class Auth
    {
        public static string VerifyAccount(string username, string password)
        {
            // database stuff here
            // return XML indicating success or failure
            DBController dbc = new DBController();

            Account acc = dbc.getAccount(username);
            string pwd = acc.password;

            dbc.Close();

            if (password == pwd)
            {
                return "<Login><UserId>" + acc.id + "</UserId><Valid>" + "TRUE" + "</Valid>" + "</Login>";
            }
            else
            {
                return "<Login><UserId>" + acc.id + "</UserId><Valid>" + "FALSE" + "</Valid>" + "</Login>";
            }
        }
    }
}
