<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentDash.aspx.cs" Inherits="screens.screens.Students.studentDash" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Dashboard</title>
    <link rel="stylesheet" type="text/css" href="../Global.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="DashboardTable" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%" CssClass="dashboard-table" Height="825px">
            <asp:TableRow>
                <asp:TableCell CssClass="side-nav">
                    <div>
                        <h2>Student Panel</h2>
                        <ul>
                            <li><a href="studentDash.aspx" class="active">Dashboard</a></li>
                            <li><a href="ViewSchedule.aspx">View Schedule</a></li>
                            <li><a href="SubmitAssignments.aspx">Submit Assignments</a></li>
                            <li><a href="ViewGrades.aspx">View Grades</a></li>
                            <li><a href="ViewReports.aspx">View Reports</a></li>
                            <li><a href="#" runat="server" id="btnLogout" OnServerClick="btnLogout_OnClick">Logout</a></li>
                        </ul>
                    </div>
                </asp:TableCell>
                <asp:TableCell CssClass="main-content">
                    <h1>Welcome, Student!</h1>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
