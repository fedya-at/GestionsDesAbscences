<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAbsence.aspx.cs" Inherits="screens.screens.Admin.ManageAbsence" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestion des absences</title>
        <link rel="stylesheet" type="text/css" href="../Global.css" />


</head>
<body>
    <form id="form1" runat="server">
        <!-- Add the ScriptManager here -->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
           <div style="margin: 20px;">
    <h1>Liste des absences</h1>
    <table>
        <tr>
            <td>Date de début:</td>
            <td>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="StartDateCalendar" runat="server" TargetControlID="txtStartDate" Format="dd/MM/yyyy" />
            </td>
            <td>Date de fin:</td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="EndDateCalendar" runat="server" TargetControlID="txtEndDate" Format="dd/MM/yyyy" />
            </td>
        </tr>
        <tr>
            <td>Classe:</td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Choisir une classe" Value="" />
                    <asp:ListItem Text="Classe A" Value="A" />
                    <asp:ListItem Text="Classe B" Value="B" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Nom Etudiant:</td>
            <td><asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox></td>
            <td>Prénom Etudiant:</td>
            <td><asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btnSearch" runat="server" Text="Recherche" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <h3>Résultats</h3>
    <asp:Table ID="tblResults" runat="server" BorderWidth="1" BorderColor="#ccc" CellPadding="5" CellSpacing="0">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell CssClass="header-cell">Matière</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="header-cell">Nombre d'absence</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</div>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
        
    </form>
</body>
</html>
