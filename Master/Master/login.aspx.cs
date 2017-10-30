using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Master
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Username.Text == Password.Text || Username.Text == "" || Password.Text == "")
            {
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                con.Open();
                SqlCommand CheckUser = new SqlCommand("UserLogin", con);
                CheckUser.CommandType = CommandType.StoredProcedure;

                SqlParameter parLogINID = new SqlParameter();//skicka in username
                parLogINID.ParameterName = "@UserID";
                parLogINID.Value = Username.Text;

                SqlParameter parPassword = new SqlParameter();//skicka in password
                parPassword.ParameterName = "@Password";
                parPassword.Value = Password.Text;

                CheckUser.Parameters.Add(parLogINID);
                CheckUser.Parameters.Add(parPassword);

                object obj = new object();
                //j = Convert.ToInt16(CheckUser.ExecuteScalar());// ändrar return till int värde
                obj = CheckUser.ExecuteScalar();
                if(obj != null)
                {
                    SqlCommand GetID = new SqlCommand("GetType", con);
                    GetID.CommandType = CommandType.StoredProcedure;
                    SqlParameter UserID = new SqlParameter();
                    UserID.ParameterName = "@UserID";
                    UserID.Value = Username.Text;
                    GetID.Parameters.Add(UserID);
                    Session["UserType"] = Convert.ToInt16(GetID.ExecuteScalar());
                    con.Close();
                    Session["User"] = Username.Text;
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }
}