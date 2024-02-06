using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

using System.Web.Services;
using System.Web.Script.Services;

namespace CREDIT
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (Request.Form["Req"] == "1")
            // {
            //     SelectData();
            // }
        }
        // public void SelectData()
        // {
        //     string val = "";
        //     string connectionString = ConfigurationManager.AppSettings["LocalDatabase"];

        //     using (SqlConnection connection = new SqlConnection(connectionString))
        //     {

        //         connection.Open();
        //         string query = ConfigurationManager.AppSettings["Info1"];

        //         query += Request.Form["name"] + ",";
        //         query += Request.Form["place"];

        //         using (SqlCommand command = new SqlCommand(query, connection))
        //         {
        //             SqlDataReader reader = command.ExecuteReader();
        //             if (reader.Read())
        //             {
        //                 val = reader.GetValue(reader.GetOrdinal("msg")).ToString();
        //             }
        //             Response.Write(val);

        //         }
        //         connection.Close();
        //         Response.End();

        //     }
        // }

        [WebMethod]
        public static string InsertData(string roleId, string dept,string roleName)
        {
            string connectionString = ConfigurationManager.AppSettings["LocalDatabase"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = "INSERT INTO ROLES VALUES (@Value1,@Value2,@Value3)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", roleId);
                    command.Parameters.AddWithValue("@Value2", dept);
                    command.Parameters.AddWithValue("@Value3", roleName);

                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        connection.Close();
                        return "success";
                    }
                    else
                    {
                        connection.Close();
                        return "failure";
                    }
                }
            }
        }

        [WebMethod]

        public static string GetJsonData()
        {
            string res = "";
            string connectionString = ConfigurationManager.AppSettings["LocalDatabase"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = "SELECT DEPT_ID FROM DEPARTMENT FOR JSON AUTO";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        res = reader[0].ToString();
                    }
                    reader.Close();
                }
                connection.Close();
                return res;

            }

        }
    }
}