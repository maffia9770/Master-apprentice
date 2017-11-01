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
	public partial class teacher_home : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if(Convert.ToInt16(Session["UserType"]) == 0)
            {
                Response.Redirect("Home.aspx");
            }
		}
        protected void CreateQuest_Click(object sender, EventArgs e)
        {
            string Name = Request.Form["NewName"];
            string Desc = Request.Form["NewDesc"];
            string Obj = Request.Form["NewObj"];
            string Rew = Request.Form["NewRew"];
            int Type = Convert.ToInt16(Request.Form["Type"]);

            using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    const string SQL = "INSERT INTO [Quests] ([QuestName], [QuestDes], [QuestObj], [QuestRew], [CourseID], QuestType) VALUES (@QuestName, @QuestDes, @QuestObj, @QuestRew, @CourseID, @Type)";
                    SqlCommand cmd = new SqlCommand(SQL, Con);
                    cmd.Parameters.AddWithValue("@QuestName", Name);
                    cmd.Parameters.AddWithValue("@QuestDes", Desc);
                    cmd.Parameters.AddWithValue("@QuestObj", Obj);
                    cmd.Parameters.AddWithValue("@QuestRew", Rew);
                    cmd.Parameters.AddWithValue("@CourseID", "DVA231");
                    cmd.Parameters.AddWithValue("@Type", Type);
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Quest created successfully')", true);
                }
                catch (HttpUnhandledException)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Could not create quest')", true);
                    Con.Close();
                }
            }
        }
	}
}