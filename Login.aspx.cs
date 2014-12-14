using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    DataBase data = new DataBase();
    public static string action = string.Empty;
    public static string susername = string.Empty;
    public static string userid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label la = (Label)Master.FindControl("label_ShowTime");
        la.Text = DateTime.Now.ToLocalTime().ToString();
        Label lab = (Label)Master.FindControl("label_showName");
        lab.Text = "Welcome!";
        
        if (!IsPostBack)
        {
          
        }
    }  
   
    protected void btn_Login_Click(object sender, EventArgs e)
    {
        
        if (this.txt_LoginUserName.Value == string.Empty ||
            this.txt_LoginPass.Value == string.Empty)
        {
            Common.ShowMessage.Show(Page, "Confirm", "username or password cannot be empty！");
            return;
        }
        else if(this.txt_LoginUserName.Value =="larry")
        {
            this.txt_LoginUserName.Value = "pb";
        }
        else if(this.txt_LoginUserName.Value =="lecturer")
        {
            this.txt_LoginUserName.Value = "bs";
        }
        string sql = "select * from userinfo where userid='" +
            this.txt_LoginUserName.Value + "' and pwd='" +
            this.txt_LoginPass.Value + "'";
        if (data.RunProcReturn(sql, "0").Tables["0"].Rows.Count == 1)
        {
            Common.SetMes.SetSession("UserID", this.txt_LoginUserName.Value);
            Common.SetMes.SetSession("UserName", data.RunProcReturn("select name from userinfo where userid='"+this.txt_LoginUserName.Value+"'", "0").Tables["0"].Rows[0]["name"].ToString());
            string role = data.RunProcReturn(sql, "0").Tables["0"].Rows[0]["roles"].ToString();
            Common.SetMes.SetSession("Role",role);
            if (role == "3")
            {
                Response.Redirect("teacher/SessionManager.aspx");
            }
            else
            {
                Response.Redirect("sessionlist.aspx");
            }   
        }
        else
        {
            Common.ShowMessage.Show(Page, "username", "Login failed!");
            return;
        }
    }
}