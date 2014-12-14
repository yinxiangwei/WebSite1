<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMas.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="templatemo_style.css" rel="stylesheet" type="text/css" />
<link href="fullsize/fullsize.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="fullsize/jquery.js"></script>
<script type="text/javascript" src="fullsize/jquery.fullsize.minified.js"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        $("div.templatemo_gallery img").fullsize();
    });
</script>
  <hr />  
  <asp:Panel ID="panel_Login" runat="server" >
  <div class="col-sm-12">
        <div class="col-sm-6 col-sm-offset-3">
            <div class="col-sm-6">
               <h4>UserName:</h4> 
            </div>
             <div class="col-sm-6">
                <input type="text" runat="server"  class="col-xs-10 col-sm-10" id="txt_LoginUserName" name="username" placeholder=""/>
             </div>
        </div>
        <div class="space-16"></div>
        <div class=" col-sm-6 col-sm-offset-3">
            <div class="col-sm-6">
               	<h4>Password:</h4>
            </div>
             <div class="col-sm-6">
                <input type="password" runat="server" class="col-xs-10 col-sm-10"  id="txt_LoginPass" name="password" placeholder="" />
                <br />
                <a href="Register.aspx?action=1">Forget Password</a>
             </div>
        </div>
        <div class="space-16"></div>
        <div class="col-sm-6 col-sm-offset-3 center">
            <asp:Button runat="server" CssClass="btn btn-sm btn-success" ID="btn_Login" 
                Text="Login"  Width="128px" onclick="btn_Login_Click" />
        </div>
  </div>
  <div class="col-sm-12">
         <hr />
         <h3>&nbsp;</h3>  
         <hr />
        <h3>&nbsp;</h3>
  </div>
  </asp:Panel>
</asp:Content>


