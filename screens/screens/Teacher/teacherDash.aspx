<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacherDash.aspx.cs" Inherits="screens.screens.Teacher.teacherDash" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Dashboard</title>
    <link rel="stylesheet" type="text/css" href="../Global.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="DashboardTable" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%" CssClass="dashboard-table" Height="825px">
            <asp:TableRow>
                <asp:TableCell CssClass="side-nav">
                    <div>
                        <h2>Teacher Panel</h2>
                        <ul>
                            <li><a href="teacherDash.aspx" class="active">Dashboard</a></li>
                            <li><a href="ManageClasses.aspx">Manage Classes</a></li>
                            <li><a href="UploadMaterials.aspx">Upload Materials</a></li>
                            <li><a href="GradeSubmissions.aspx">Grade Submissions</a></li>
                            <li><a href="ViewAttendance.aspx">View Attendance</a></li>
<li><a href="#" runat="server" id="btnLogout" OnServerClick="btnLogout_OnClick">Logout</a></li>
                        </ul>
                    </div>
                </asp:TableCell>
                <asp:TableCell CssClass="main-content">
                    <h1>Welcome, Teacher!</h1>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
