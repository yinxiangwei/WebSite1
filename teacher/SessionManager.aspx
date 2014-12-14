<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMas.master" AutoEventWireup="true" CodeFile="SessionManager.aspx.cs" Inherits="techer_SessionManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<meta name="keywords" content="Teal Com, www.865171.cn, Web Design" />
<meta name="description" content="Teal Com - www.865171.cn, HTML CSS, Web Design Layout" />
<link href="../templatemo_style.css" rel="stylesheet" type="text/css" />
<link href="../fullsize/fullsize.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../fullsize/jquery.js"></script>
<script type="text/javascript" src="../fullsize/jquery.fullsize.minified.js"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        $("div.templatemo_gallery img").fullsize();
    });   
</script>
<hr />
<link href="../templatemo_style.css" rel="stylesheet" type="text/css" />
<link href="../fullsize/fullsize.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../fullsize/jquery.js"></script>
<script type="text/javascript" src="../fullsize/jquery.fullsize.minified.js"></script>

<!-- basic styles -->

		<link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
		<link rel="stylesheet" href="../assets/css/font-awesome.min.css" />

		<!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

		<!-- page specific plugin styles -->

		<!-- fonts -->

		<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

		<!-- ace styles -->

		<link rel="stylesheet" href="../assets/css/ace.min.css" />
		<link rel="stylesheet" href="../assets/css/ace-rtl.min.css" />
		<link rel="stylesheet" href="../assets/css/ace-skins.min.css" />

		<!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

		<!-- inline styles related to this page -->

		<!-- ace settings handler -->

		<script src="../assets/js/ace-extra.min.js"></script>

		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

		<!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
<div class="col-sm-12">
    <div class="col-sm-10">        
        <div class="col-sm-12">
            <asp:GridView runat="server" 
                CssClass="table table-striped table-bordered table-hover" ID="grvSession" 
            DataKeyNames="sessionid" AutoGenerateColumns="False" 
                onrowdeleting="grvSession_RowDeleting" 
                onrowediting="grvSession_RowEditing" onrowupdating="grvSession_RowUpdating">            
            <Columns>
                <asp:BoundField DataField="sessionid" HeaderText="SessionID" />
                <asp:BoundField DataField="sessionname" HeaderText="Session" />
                <asp:BoundField DataField="dateandtime" HeaderText="DateAndTime" />               
                 <asp:TemplateField HeaderText="Operation" ShowHeader="False">                       
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="Start" ForeColor="Red" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>    
                                &nbsp;&nbsp;                     
                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Update"
                                Text="Close" ForeColor="Red" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
                                 &nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="Delete" ForeColor="Red" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
                        </ItemTemplate>
                  </asp:TemplateField>             
             </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />            
        </asp:GridView>
        </div>
        <div class="space-10"></div>
        <div class="col-sm-12">
            <asp:Button runat="server" ID="btn_Mnager" CssClass="btn btn-info" 
                Text="Add Session" onclick="btn_Mnager_Click" />
            &nbsp;&nbsp;
             <asp:Button runat="server" ID="btn_Invigilate" CssClass="btn btn-info" 
                Text="Invigilate" onclick="btn_Invigilate_Click" />
        </div>          
         <div class="space-10"></div>             
    </div>
</div></asp:Content>

