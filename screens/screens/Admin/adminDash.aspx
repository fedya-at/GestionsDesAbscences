<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminDash.aspx.cs" Inherits="screens.screens.Admin.adminDash" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link rel="stylesheet" type="text/css" href="../Global.css" />
   

</head>
<body>
    <form id="form1" runat="server">
       <asp:Table ID="DashboardTable" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%" CssClass="dashboard-table" Height="825px">
    <asp:TableRow>
        <asp:TableCell CssClass="side-nav">
            <div>
                <h2>Admin Panel</h2>
                <ul>
    <li><a href="adminDash.aspx" class="active">Dashboard</a></li>
    <li><a href="ManageAbsence.aspx">Manage Absences</a></li>
    <li><a href="Managment/User.aspx">User Management</a></li>
    <li><a href="Managment/Modules.aspx">Manage Modules</a></li>
    <li><a href="Managment/Students.aspx">Manage Students</a></li>
    <li><a href="Managment/Teachers.aspx">Manage Teachers</a></li>
    <li><a href="Managment/Reports.aspx">Reports</a></li>
<li><a href="#" runat="server" id="btnLogout" OnServerClick="btnLogout_OnClick">Logout</a></li>
</ul>
            </div>
        </asp:TableCell>
        <asp:TableCell CssClass="main-content">
           <h1>Hello admin </h1>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

    </form>
</body>
</html>  