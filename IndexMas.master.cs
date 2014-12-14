using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexMas : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Common.GetMes.GetSession("UserID")))
            {
                btn_Logout.Visible = false;
            }
        }
    }
    protected void btn_Logout_Click(object sender, EventArgs e)
    {
        Common.SetMes.RemoveAllSession();
        Response.Redirect("~/Login.aspx");
    }   
}
