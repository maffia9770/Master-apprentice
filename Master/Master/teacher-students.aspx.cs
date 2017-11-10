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
        [WebMethod(EnableSession = true)]
        protected void CreateStudent_Click(object sender, EventArgs e)
        {
            string name = Request.Form["name"];
            string userid = Request.Form["userid"];
            string password = Request.Form["pwd"];
            string course = "DVA231";
            int p = 1;
            int Type = 0;

            using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    const string SQL = "INSERT INTO [Users] ([UserID], [Password], UserType, [Name]) VALUES (@UserID, @Password, @UserType, @Name)";
                    SqlCommand Users = new SqlCommand(SQL, Con);
                    Users.Parameters.AddWithValue("@UserID", userid);
                    Users.Parameters.AddWithValue("@Password", password);
                    Users.Parameters.AddWithValue("@UserType", Type);
                    Users.Parameters.AddWithValue("@Name", name);

                    const string SQL2 = "INSERT INTO [Participants] ([UserID], [CourseID]) VALUES (@UserID, @CourseID)";
                    SqlCommand Participants = new SqlCommand(SQL2, Con);
                    Participants.Parameters.AddWithValue("@UserID", userid);
                    Participants.Parameters.AddWithValue("@CourseID", course);

                    const string SQL3 = "INSERT INTO [UsersSkills] ([UserID], [Skill], [Points], [CourseID]) VALUES (@UserID, @Skill, @Points, @CourseID)";
                    SqlCommand DesignInnovation = new SqlCommand(SQL3, Con);
                    DesignInnovation.Parameters.AddWithValue("@UserID", userid);
                    DesignInnovation.Parameters.AddWithValue("@Skill", "Design-Innovation");
                    DesignInnovation.Parameters.AddWithValue("@Points", p);
                    DesignInnovation.Parameters.AddWithValue("@CourseID", course);

                    const string SQL4 = "INSERT INTO [UsersSkills] ([UserID], [Skill], [Points], [CourseID]) VALUES (@UserID, @Skill, @Points, @CourseID)";
                    SqlCommand Presenting = new SqlCommand(SQL4, Con);
                    DesignInnovation.Parameters.AddWithValue("@UserID", userid);
                    DesignInnovation.Parameters.AddWithValue("@Skill", "Presenting");
                    DesignInnovation.Parameters.AddWithValue("@Points", p);
                    DesignInnovation.Parameters.AddWithValue("@CourseID", course);

                    const string SQL5 = "INSERT INTO [UsersSkills] ([UserID], [Skill], [Points], [CourseID]) VALUES (@UserID, @Skill, @Points, @CourseID)";
                    SqlCommand Programming = new SqlCommand(SQL5, Con);
                    DesignInnovation.Parameters.AddWithValue("@UserID", userid);
                    DesignInnovation.Parameters.AddWithValue("@Skill", "Programming");
                    DesignInnovation.Parameters.AddWithValue("@Points", p);
                    DesignInnovation.Parameters.AddWithValue("@CourseID", course);

                    const string SQL6 = "INSERT INTO [UsersSkills] ([UserID], [Skill], [Points], [CourseID]) VALUES (@UserID, @Skill, @Points, @CourseID)";
                    SqlCommand Research = new SqlCommand(SQL6, Con);
                    DesignInnovation.Parameters.AddWithValue("@UserID", userid);
                    DesignInnovation.Parameters.AddWithValue("@Skill", "Research");
                    DesignInnovation.Parameters.AddWithValue("@Points", p);
                    DesignInnovation.Parameters.AddWithValue("@CourseID", course);

                    const string SQL7 = "INSERT INTO [UsersSkills] ([UserID], [Skill], [Points], [CourseID]) VALUES (@UserID, @Skill, @Points, @CourseID)";
                    SqlCommand Thinking = new SqlCommand(SQL7, Con);
                    DesignInnovation.Parameters.AddWithValue("@UserID", userid);
                    DesignInnovation.Parameters.AddWithValue("@Skill", "Thinking");
                    DesignInnovation.Parameters.AddWithValue("@Points", p);
                    DesignInnovation.Parameters.AddWithValue("@CourseID", course);

                    const string SQL8 = "INSERT INTO [UsersSkills] ([UserID], [Skill], [Points], [CourseID]) VALUES (@UserID, @Skill, @Points, @CourseID)";
                    SqlCommand Writing = new SqlCommand(SQL8, Con);
                    DesignInnovation.Parameters.AddWithValue("@UserID", userid);
                    DesignInnovation.Parameters.AddWithValue("@Skill", "Writing");
                    DesignInnovation.Parameters.AddWithValue("@Points", p);
                    DesignInnovation.Parameters.AddWithValue("@CourseID", course);

                    Con.Open();
                    Users.ExecuteNonQuery();
                    Participants.ExecuteNonQuery();
                    DesignInnovation.ExecuteNonQuery();
                    Presenting.ExecuteNonQuery();
                    Programming.ExecuteNonQuery();
                    Research.ExecuteNonQuery();
                    Thinking.ExecuteNonQuery();
                    Writing.ExecuteNonQuery();
                    Con.Close();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student created successfully')", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Could not create student')", true);
                    Con.Close();
                }
            }
        }

    }
}
