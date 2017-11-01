using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            System.Diagnostics.Debug.WriteLine(Name + "sug mig");
        }
	}
}