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
                SqlConnection con = new SqlConnection("Server=tcp:judas.database.windows.net,1433;Initial Catalog=User_server;Persist Security Info=False;User ID=Judas;Password=Admin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=10;");
                con.Open();
                SqlCommand CheckUser = new SqlCommand("UsersProc", con);
                CheckUser.CommandType = CommandType.StoredProcedure;

                SqlParameter parLogINID = new SqlParameter();//skicka in username
                parLogINID.ParameterName = "@Username";
                parLogINID.Value = Username.Text;

                SqlParameter parPassword = new SqlParameter();//skicka in password
                parPassword.ParameterName = "@Password";
                parPassword.Value = Password.Text;

                CheckUser.Parameters.Add(parLogINID);
                CheckUser.Parameters.Add(parPassword);

                int j = 0;

                j = Convert.ToInt16(CheckUser.ExecuteScalar());// ändrar return till int värde

                if (j > 0)
                {//ev ej nödvändigt, har med userid att göra
                    SqlCommand GetID = new SqlCommand("GetID", con);
                    GetID.CommandType = CommandType.StoredProcedure;
                    SqlParameter UserID = new SqlParameter();
                    UserID.ParameterName = "@Username";
                    UserID.Value = Username.Text;
                    GetID.Parameters.Add(UserID);
                    Session["UserID"] = Convert.ToInt16(GetID.ExecuteScalar());
                    //
                    con.Close();
                    Session["User"] = Username.Text;
                    Session["logon"] = (bool)true;
                    Response.Redirect("index.aspx");
                }
            }
    }
}