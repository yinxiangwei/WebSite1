<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMas.master" AutoEventWireup="true" CodeFile="Invigilate.aspx.cs" Inherits="techer_Invigilate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        <div class="col-sm-8 col-sm-offset-2">
            <table>
                <tr>
                    <td>
                        Sessions:
                    </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlSession" CssClass="form-control" 
                             AutoPostBack="True" onselectedindexchanged="ddlSession_SelectedIndexChanged"></asp:DropDownList>
                     </td>
                     <td>
                        Questions:
                    </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlQuestions" CssClass="form-control" 
                             onselectedindexchanged="ddlQuestions_SelectedIndexChanged"></asp:DropDownList>
                     </td>
                     <td>
                        <asp:Button runat="server" ID="btn_Query"  Text="Query" 
                             CssClass="btn btn-success" onclick="btn_Query_Click"/>
                     </td>
                </tr>
            </table>    
        </div>  
        <asp:GridView runat="server" CssClass="table table-striped table-bordered table-hover" ID="grvSession" AutoGenerateColumns="False">            
            <Columns>
                <asp:BoundField DataField="sessionname" HeaderText="SessionName" />
                <asp:BoundField DataField="problemsTitle" HeaderText="problemsTitle" />
                <asp:BoundField DataField="rightnum" HeaderText="rightnum" />  
               <asp:BoundField DataField="wrongnum" HeaderText="wrongnum" /> 
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />            
        </asp:GridView>
        <div class="well-sm"></div>              
    </div>
</asp:Content>

