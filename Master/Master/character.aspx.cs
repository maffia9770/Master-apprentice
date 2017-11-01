using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Master
{
	public partial class character : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Convert.ToInt16(Session["UserType"]) == 1)
            {
                Response.Redirect("teacher-home.aspx");
            }
        }
		[WebMethod(EnableSession = true)]
		public static string ShowUsersName()
		{
			using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
			{
				try
				{
					con.Open();
					try
					{
						con.Open();
						SqlCommand ShowUsersName = new SqlCommand("ShowUsersName", con);
						ShowUsersName.CommandType = CommandType.StoredProcedure;
						/* tills vi har user att skicka in
						SqlParameter parLogINID = new SqlParameter();
						parLogINID.ParameterName = "@Username";
						parLogINID.Value = User.Text;
						*/
						var UserID = (string)HttpContext.Current.Session["User"];
						SqlParameter parLogINID = new SqlParameter();
						parLogINID.ParameterName = "@UserID";
						parLogINID.Value = UserID;

						//CheckQuests.Parameters.Add(parUser);
						ShowUsersName.Parameters.Add(parLogINID);
						Object obj = ShowUsersName.ExecuteScalar();
						if (obj == null)
						{
							con.Close();
							return null;
						}
						UserID = obj.ToString();
						con.Close();
						UserID.Trim();
						UserID.Replace("[", string.Empty);
						UserID.Replace("]", string.Empty);
						UserID.Remove(0);
						System.Diagnostics.Debug.WriteLine(obj.ToString());
						return UserID;
					}
					catch
					{
						con.Close();
						return null;
					}
				}
				catch
				{
					con.Close();
					return null;
				}
			}
		}
	}
}
