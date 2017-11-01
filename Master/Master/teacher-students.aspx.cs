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
	public partial class teacher_students : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["User"] == null)
			{
				Response.Redirect("Login.aspx");
			}

			if (Convert.ToInt16(Session["UserType"]) == 0)
			{
				Response.Redirect("charachter.aspx");
			}
		}

		[WebMethod(EnableSession = true)]
		public static string GetSkills(string QuestID)
		{
			using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
			{
				try
				{
					Con.Open();
					SqlCommand GetStudents = new SqlCommand("GetStudents", Con);
					GetStudents.CommandType = CommandType.StoredProcedure;
					SqlParameter parUserID = new SqlParameter();
					var UserID = (string)HttpContext.Current.Session["User"];
					parUserID.ParameterName = "@UserID";
					parUserID.Value = UserID;

					GetStudents.Parameters.Add(parUserID);
					Object obj = GetStudents.ExecuteScalar();
					if (obj == null)
					{
						Con.Close();
						return null;
					}
					UserID = obj.ToString();
					Con.Close();
					UserID.Trim();
					UserID.Replace("[", string.Empty);
					UserID.Replace("]", string.Empty);
					UserID.Remove(0);
					System.Diagnostics.Debug.WriteLine(obj.ToString());
					return UserID;
				}
				catch
				{
					Con.Close();
					return null;
				}
			}

		}
	}
}
