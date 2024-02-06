using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace CREDIT
{
    public partial class CreditTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreditNum.Attributes["type"] = "number";
            CreditAmt.Attributes["type"] = "number";
            CreditCvv.Attributes["type"] = "number";
        }

        protected void Transact(object sender, EventArgs e)
        {
            string credit_num = Request.Form["CreditNum"];
            string credit_name = Request.Form["CreditName"];
            credit_name=credit_name.ToUpper();
            string credit_date = Request.Form["CreditDate"];
            string credit_cvv = Request.Form["CreditCvv"];
            decimal credit_amt = Convert.ToDecimal(Request.Form["CreditAmt"]);
            string connectionString = ConfigurationManager.AppSettings["LocalDatabase"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string credit_trans = "SELECT *  FROM CARD_DETAILS WHERE CREDIT_CARD_NUMBER = " + credit_num;

                using (SqlCommand command1 = new SqlCommand(credit_trans, connection))
                {
                    SqlDataReader reader = command1.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader.GetValue(reader.GetOrdinal("CARD_HOLDER_NAME")).ToString();
                        name=name.ToUpper();
                        string date = reader.GetDateTime(reader.GetOrdinal("EXPIRY_DATE")).ToString("yyyy-MM-dd");
                        string cvv_num = reader.GetValue(reader.GetOrdinal("CVV")).ToString();
                        reader.Close();
                        if (name != credit_name)
                        {
                            Response.Write("<h2 style='background-color: red;'>Invalid Card Holder Name</h2>");
                        }
                        else if (date != credit_date)
                        {
                            Response.Write("<h2 style='background-color: red;'>Invalid Expiry Date</h2>");
                        }
                        else if (cvv_num != credit_cvv)
                        {
                            Response.Write("<h2 style='background-color: red;'>Invalid CVV</h2>");
                        }
                        else
                        {
                            string query = "INSERT INTO CARD_TRANSACTION(CREDIT_CARD_NUMBER,AMOUNT) VALUES (@Value1, @Value2)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Value1", credit_num);
                                command.Parameters.AddWithValue("@Value2", credit_amt);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Response.Write("<h2 style='background-color: green;'>Registered Successfully</h2>");
                                }
                                else
                                {
                                    Response.Write("Failed to insert record.");
                                }

                            }
                        }
                    }
                    else
                    {
                        Response.Write("<h2 style='background-color: red;'>Account Doesn't Exist</h2>");

                    }
                }
            }
        }
    }
}