using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class techer_AddSessions : System.Web.UI.Page
{
    DataBase data = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_next_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(txt_ExamName.Text))
        {
            Common.ShowMessage.Show(Page,"Session Name","Session Name is NULL!");
            return;
        }
        if (string.IsNullOrEmpty(datepicker.Value))
        {
            Common.ShowMessage.Show(Page, "Session Name", "Start Time is NULL!");
            return;
        }
        if (string.IsNullOrEmpty(txt_Detail.Text))
        {
            Common.ShowMessage.Show(Page, "Session Detail", "Session Detail is NULL!");
            return;
        }
        if (string.IsNullOrEmpty(txt_FinishTime.Value))
        {
            try
            {
                int i = int.Parse(txt_FinishTime.Value);
            }
            catch
            {
                Common.ShowMessage.Show(Page, "FinishTime Name", "FinishTime Time is invalid!");
                return;
            }
            Common.ShowMessage.Show(Page, "FinishTime Name", "FinishTime Time is NULL!");
            return;
        }
        try
        {
            int i = int.Parse(txt_FinishTime.Value);
        }
        catch
        {
            Common.ShowMessage.Show(Page, "FinishTime Name", "FinishTime Time is invalid!");
            return;
        }
        string sql = "insert into sessions(sessionname,dateandtime,passflag,sessiondetail,finishtime) values('" + txt_ExamName.Text + "','" +DateTime.Parse(datepicker.Value).ToString("yyyy-MM-dd HH:mm:ss") + "',0,'" + txt_Detail.Text + "'," + txt_FinishTime.Value + ")";
        data.RunProc(sql);
        string maxid = data.RunProcReturn("select max(sessionid) as sessionid from sessions;", "sessions").Tables["sessions"].Rows[0]["sessionid"].ToString();
        Common.SetMes.SetSession("sessionid", maxid);
        Common.ShowMessage.ShowModalDialog(Page, "add session success!", "AddQuestions.aspx");
        Response.Redirect("AddQuestions.aspx");
    }
}