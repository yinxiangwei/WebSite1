using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class techer_SessionManager : System.Web.UI.Page
{
    DataBase data = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        btn_Invigilate.Visible = false;
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void grvSession_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sql = "delete from userproblem  where sessionid=" + grvSession.DataKeys[e.RowIndex].Value.ToString() + "; " +
                     "delete from problems where sessionid=" + grvSession.DataKeys[e.RowIndex].Value.ToString() + "; " +
                     "delete from usersession where sessionid=" + grvSession.DataKeys[e.RowIndex].Value.ToString() + "; " +
                     "delete from sessions where sessionid=" + grvSession.DataKeys[e.RowIndex].Value.ToString() + ";";    
        data.RunProc(sql);
        bind();
        Common.ShowMessage.Show(Page, "Delete", "Delete Session success!");
    }

    private void bind()
    {
        string sql = "select * from sessions;";
        this.grvSession.DataSource = data.RunProcReturn(sql, "sessions").Tables["sessions"];
        this.grvSession.DataBind();
    }
    protected void btn_Mnager_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddSessions.aspx");
    }
    protected void btn_Invigilate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Invigilate.aspx");
    }
   
    protected void grvSession_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string sql = "update sessions set passflag=1 where sessionid=" + grvSession.DataKeys[e.RowIndex].Value.ToString();
        data.RunProc(sql);
        Common.ShowMessage.Show(Page, "End", "End Session success!");
    }
    protected void grvSession_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string sql = "update sessions set passflag=2 where sessionid=" + grvSession.DataKeys[e.NewEditIndex].Value.ToString();
        data.RunProc(sql);
        Common.ShowMessage.Show(Page, "Start", "Start Session success!");
    }
}