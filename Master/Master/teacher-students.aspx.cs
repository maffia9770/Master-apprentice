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
                    System.Diagnostics.Debug.WriteLine("test students 1");
                    SqlCommand GetStudents = new SqlCommand("GetStudents", Con);
					GetStudents.CommandType = CommandType.StoredProcedure;
					SqlParameter parCourseID = new SqlParameter();
					parCourseID.ParameterName = "@CourseID";
					parCourseID.Value = CourseID;
					GetStudents.Parameters.Add(parCourseID);
					Object obj = GetStudents.ExecuteScalar();
					/*if (obj == null)
					{
						throw new HttpUnhandledException();
						Con.Close();
						return null;
					}*/
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
        [WebMethod(EnableSession = true)]
        public static int StudentQuests(string UserID)
        {
            using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    Con.Open();
                    SqlCommand StudentQuests = new SqlCommand("CharQuests", Con);
                    StudentQuests.CommandType = CommandType.StoredProcedure;
                    SqlParameter parUserID = new SqlParameter();
                    parUserID.ParameterName = "@UserID";
                    parUserID.Value = UserID;

                    StudentQuests.Parameters.Add(parUserID);
                    Object obj = StudentQuests.ExecuteScalar();
                    System.Diagnostics.Debug.WriteLine("StudentQuests Test 1");
                    if (obj == null)
                    {
                        Con.Close();
                        return 0;
                    }
                    Con.Close();
                    return 1;
                }
                catch
                {
                    Con.Close();
                    return 1;
                }
            }
        }
        [WebMethod(EnableSession = true)]
        public static string StudentSkills(string UserID)
        {
            using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("StudentSkills test 1");
                    Con.Open();
                    SqlCommand GetSkills = new SqlCommand("GetSkills", Con);
                    GetSkills.CommandType = CommandType.StoredProcedure;
                    SqlParameter parUserID = new SqlParameter();
                    parUserID.ParameterName = "@UserID";
                    parUserID.Value = UserID;

                    GetSkills.Parameters.Add(parUserID);
                    Object obj = GetSkills.ExecuteScalar();
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
