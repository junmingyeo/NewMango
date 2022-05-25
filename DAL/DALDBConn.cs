using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;
using System.Text;

namespace RestaurantOwner.DAL
{
    public class DALDBConn
    {
        public SqlConnection getConnection()
        {
            SqlConnection dbConn;
            String connString = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;

            dbConn = new SqlConnection(connString);

            return dbConn;
        }

        //Get content in datatable type
        public DataTable getDataTable(SqlCommand cmd)
        {
            cmd.Connection = getConnection();
            cmd.Connection.Open();
            cmd.CommandTimeout = 1200;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            cmd.Connection.Close();

            return dt;
        }

        public DataSet getDataSet(SqlCommand cmd)
        {
            cmd.Connection = getConnection();
            cmd.Connection.Open();
            cmd.CommandTimeout = 1200;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();


            dataAdapter.Fill(ds);
            cmd.Connection.Close();

            return ds;
        }


        public Boolean executeScalar(SqlCommand cmd)
        {
            bool exist = false;

            cmd.Connection = getConnection();
            cmd.Connection.Open();
            cmd.CommandTimeout = 1200;
            object record = cmd.ExecuteScalar();

            if (record != null)
            {
                exist = true;
            }

            cmd.Connection.Close();
            return exist;
        }

        public int executeScalarInt(SqlCommand cmd)
        {
            cmd.Connection = getConnection();
            cmd.Connection.Open();
            cmd.CommandTimeout = 1200;
            int value = (int)cmd.ExecuteScalar();

            cmd.Connection.Close();
            return value;
        }

        public decimal executeScalarDecimal(SqlCommand cmd)
        {
            cmd.Connection = getConnection();
            cmd.Connection.Open();
            cmd.CommandTimeout = 1200;
            decimal value = (decimal)cmd.ExecuteScalar();

            cmd.Connection.Close();
            return value;
        }

        public string executeScalarString(SqlCommand cmd)
        {
            cmd.Connection = getConnection();
            cmd.Connection.Open();
            cmd.CommandTimeout = 1200;
            object obj = cmd.ExecuteScalar();
            cmd.Connection.Close();

            if (obj == DBNull.Value) return null;
            else return (string)obj;
        }

        public Boolean executeNonQuery(SqlCommand cmd)
        {
            try
            {
                bool success = false;

                cmd.Connection = getConnection();
                cmd.Connection.Open();
                cmd.CommandTimeout = 1200;
                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    success = true;
                }

                cmd.Connection.Close();
                return success;
            }
            catch (Exception e)
            {
                string msg = e.ToString();
                return false;
            }
        }
    }
}
