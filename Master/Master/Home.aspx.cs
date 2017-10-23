using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace Master
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand CheckQuests = new SqlCommand("CheckQuests", con);
            CheckQuests.CommandType = CommandType.StoredProcedure;
            /* tills vi har user att skicka in
            SqlParameter parLogINID = new SqlParameter();
            parLogINID.ParameterName = "@Username";
            parLogINID.Value = User.Text;
            */ 
            SqlParameter parCourse = new SqlParameter();
            parCourse.ParameterName = "@Course";
            parCourse.Value = "DVA231";

            //CheckQuests.Parameters.Add(parUser);
            CheckQuests.Parameters.Add(parCourse);
            Object obj = CheckQuests.ExecuteScalar();
            Q1.InnerText = obj.ToString();
            con.Close();
        }
        [WebMethod(EnableSession = true)]
        public static string DisplayQuest(string Quest)
        {
            Quest = "Search for the Golden Pineapple";//detta ska inte vara här sen :p
            SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand CheckQuests = new SqlCommand("DisplayQuest", con);
            CheckQuests.CommandType = CommandType.StoredProcedure;
            SqlParameter parCourse = new SqlParameter();
            parCourse.ParameterName = "@Quest";
            parCourse.Value = "Quest";

            CheckQuests.Parameters.Add(parCourse);
            Object obj = CheckQuests.ExecuteScalar();
            Quest = obj.ToString();
            con.Close();
            
            return Quest;
        }
    }
}