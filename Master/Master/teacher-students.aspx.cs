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
		public static string GetStudents(string CourseID)
		{
			using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
			{
				try
				{
					Con.Open();
					SqlCommand GetStudents = new SqlCommand("GetStudents", Con);
					GetStudents.CommandType = CommandType.StoredProcedure;
					SqlParameter parCourseID = new SqlParameter();
					parCourseID.ParameterName = "@CourseID";
					parCourseID.Value = CourseID;
					GetStudents.Parameters.Add(parCourseID);
					Object obj = GetStudents.ExecuteScalar();
					if (obj == null)
					{
						throw new HttpUnhandledException();
						/*Con.Close();
						return null;*/
					}
					CourseID = obj.ToString();
					Con.Close();
					CourseID.Trim();
					CourseID.Replace("[", string.Empty);
					CourseID.Replace("]", string.Empty);
					CourseID.Remove(0);
					System.Diagnostics.Debug.WriteLine(obj.ToString());
					return CourseID;
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
