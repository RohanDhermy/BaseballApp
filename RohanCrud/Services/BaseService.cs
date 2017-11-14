using RohanCrud.Adapter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RohanCrud.Services
{
    public class BaseService
    {
        public IDbAdapter Adapter
        {
            get
            {
                return new DbAdapter(new SqlCommand(), new SqlConnection("Server=DESKTOP-4F9IFK6\\SQLEXPRESS;Database=RohanCRUD;Trusted_Connection=True"));
            }
        }

    }
}