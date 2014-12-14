<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMas.master" AutoEventWireup="true" CodeFile="sessionlist.aspx.cs" Inherits="Recmendaton" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <meta name="keywords" content="Teal Com, www.865171.cn, Web Design" />
<meta name="description" content="Teal Com - www.865171.cn, HTML CSS, Web Design Layout" />
<link href="templatemo_style.css" rel="stylesheet" type="text/css" />
<link href="fullsize/fullsize.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="fullsize/jquery.js"></script>
<script type="text/javascript" src="fullsize/jquery.fullsize.minified.js"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        $("div.templatemo_gallery img").fullsize();
    });
    function checkSessionid() { 
        
    }
</script>
<hr />
<div class="col-sm-12">
    <div class="col-sm-2">
        <asp:Button  runat="server" CssClass="btn btn-success" ID="btn_PostSession" 
            Text="Post Session" onclick="btn_PostSession_Click"/>
         <br/>
         <asp:Button  runat="server" CssClass="btn btn-success" ID="btn_Upcoming" 
            Text="Upcoming Session" onclick="btn_Upcoming_Click"/>
    </div>
    <div class="col-sm-10">        
        <div class="col-sm-12">
            <asp:GridView runat="server" 
                CssClass="table table-striped table-bordered table-hover" ID="grvSession" 
            DataKeyNames="sessionid" AutoGenerateColumns="False" 
                onrowediting="grvSession_RowEditing">            
            <Columns>
                <asp:BoundField DataField="sessionid" HeaderText="SessionID" />
                <asp:BoundField DataField="sessionname" HeaderText="Session" />
                <asp:BoundField DataField="dateandtime" HeaderText="DateAndTime" />  
                <asp:BoundField DataField="userscore" ItemStyle-ForeColor="Red" HeaderText="UserScore" /> 
                 <asp:TemplateField HeaderText="Operation" ShowHeader="False">                       
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="Enter Test/View Score " ForeColor="Red" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>                                          
                         </ItemTemplate>
                  </asp:TemplateField>   
             </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />            
        </asp:GridView>
        </div>
        <div class="space-10"></div>
        <div class="col-sm-3">
            <asp:Button runat="server" ID="btn_Mnager" CssClass="btn btn-info" Text="Manage Session" />
            &nbsp;&nbsp;
        </div>
         <div class="col-sm-3" >
            <asp:Button runat="server" ID="Button1" CssClass="btn btn-info" Text="Session Info" />
            &nbsp;&nbsp;
         </div>
          <div class="col-sm-3">
            <asp:Button runat="server" ID="Button2" CssClass="btn btn-info" Text="Update Material"/>
            &nbsp;&nbsp;
          </div>  
          <div class="col-sm-3">
            <asp:Button runat="server" ID="Button3" CssClass="btn btn-info" Text="Personal info" OnClick="Button3_Click"/>
            &nbsp;&nbsp;
          </div>        
         <div class="space-10"></div>             
    </div>
</div>
</asp:Content>

