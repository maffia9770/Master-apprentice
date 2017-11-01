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
        public static string Character(string QuestID)
        {
            using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                System.Diagnostics.Debug.WriteLine("testcharacter1");
                try
                {
                    System.Diagnostics.Debug.WriteLine("testcharacter2");
                    Con.Open();
                    SqlCommand GetName = new SqlCommand("GetName", Con);
                    GetName.CommandType = CommandType.StoredProcedure;
                    SqlParameter parUserID = new SqlParameter();
                    var UserID = (string)HttpContext.Current.Session["User"];
                    parUserID.ParameterName = "@UserID";
                    parUserID.Value = UserID;

                    GetName.Parameters.Add(parUserID);
                    Object obj = GetName.ExecuteScalar();
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
                    System.Diagnostics.Debug.WriteLine("test character fail");
                    Con.Close();
                    return null;
                }
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
                    SqlCommand GetSkills = new SqlCommand("GetSkills", Con);
                    GetSkills.CommandType = CommandType.StoredProcedure;
                    SqlParameter parUserID = new SqlParameter();
                    var UserID = (string)HttpContext.Current.Session["User"];
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
        public static string GetLevels(string Skill)
        {
            using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    Con.Open();
                    SqlCommand GetLevels = new SqlCommand("GetLevels", Con);
                    GetLevels.CommandType = CommandType.StoredProcedure;
                    SqlParameter parSkill = new SqlParameter();
                    parSkill.ParameterName = "@Skill";
                    parSkill.Value = Skill;

                    GetLevels.Parameters.Add(parSkill);
                    Object obj = GetLevels.ExecuteScalar();
                    if (obj == null)
                    {
                        Con.Close();
                        return null;
                    }
                    Skill = obj.ToString();
                    Con.Close();
                    Skill.Trim();
                    Skill.Replace("[", string.Empty);
                    Skill.Replace("]", string.Empty);
                    Skill.Remove(0);
                    System.Diagnostics.Debug.WriteLine(obj.ToString());
                    return Skill;
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