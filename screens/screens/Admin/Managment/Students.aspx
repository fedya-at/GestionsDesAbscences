<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="screens.screens.Admin.Managment.Students" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestion des étudiants</title>
    <link rel="stylesheet" type="text/css" href="../../Global.css" />
    <style>
        body {
        }

        .container h1 {
            text-align: center;
            color: #333;
            margin: 20px 0;
            font-size: 32px;
        }

        .container h2 {
            color: #444;
            margin: 20px 0;
            font-size: 24px;
        }

        .container {
            width: 80%;
        }

        .btn-add {
            display: inline-block;
            padding: 10px 20px;
            background-color: #28a745;
            color: white;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-bottom: 20px;
            text-decoration: none;
        }

        .btn-add:hover {
            background-color: #218838;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            background-color: #fff;
            border: 1px solid #ddd;
        }

        th, td {
            text-align: left;
            padding: 12px;
            border-bottom: 1px solid #ddd;
        }

        th {
            background-color: #007bff;
            color: white;
        }

        tr:hover {
            background-color: #f1f1f1;
        }

        .btn-action {
            padding: 5px 10px;
            font-size: 14px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        .btn-edit {
            background-color: #007bff;
            color: white;
        }

        .btn-edit:hover {
            background-color: #0056b3;
        }

        .btn-delete {
            background-color: #dc3545;
            color: white;
        }

        .btn-delete:hover {
            background-color: #bd2130;
        }

        .btnActions {
            display: flex;
            justify-content: space-around;
            flex-direction: row;
        }

        .error-label {
            color: red;
            margin: 10px 0;
            font-weight: bold;
        }
        .success-label {
            color: green;
            margin: 10px 0;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <asp:Table ID="DashboardTable" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="109%" CssClass="dashboard-table" Height="100%">
        <asp:TableRow>
            <asp:TableCell CssClass="side-nav">
                <div>
                    <h2>Admin Panel</h2>
                    <ul>
                        <li><a href="../adminDash.aspx" class="active">Dashboard</a></li>
                        <li><a href="../ManageAbsence.aspx">Manage Absences</a></li>
                        <li><a href="User.aspx">User Management</a></li>
                        <li><a href="Modules.aspx">Manage Modules</a></li>
                        <li><a href="Students.aspx">Manage Students</a></li>
                        <li><a href="Teachers.aspx">Manage Teachers</a></li>
                        <li><a href="Reports.aspx">Reports</a></li>
                        <li><a href="#" runat="server" id="btnLogout" OnServerClick="btnLogout_OnClick">Logout</a></li>
                    </ul>
                </div>
            </asp:TableCell>
            <asp:TableCell CssClass="main-content">
                <div class="container">
                    <h1>Gestion des étudiants</h1>

                    <a href="#" class="btn-add" onclick="showForm()">Ajouter un étudiant</a>

                    <form id="formEtudiant" runat="server" style="display: none;">
                        <h2>Ajouter un étudiant</h2>
                        <asp:Label ID="Label2" runat="server" CssClass="success-label" />

                        <table>
                            <tr>
                                <td><label for="txtNom">Nom:</label></td>
                                <td><asp:TextBox ID="txtNom" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><label for="txtPrenom">Prénom:</label></td>
                                <td><asp:TextBox ID="txtPrenom" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><label for="txtDateNaissance">Date de Naissance:</label></td>
                                <td><asp:TextBox ID="txtDateNaissance" runat="server" TextMode="Date" /></td>
                            </tr>
                            <tr>
                                <td><label for="txtNumInscription">Numéro d'Inscription:</label></td>
                                <td><asp:TextBox ID="txtNumInscription" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><label for="txtCodeClasse">Code Classe:</label></td>
                                <td><asp:TextBox ID="txtCodeClasse" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><label for="txtAdresse">Adresse:</label></td>
                                <td><asp:TextBox ID="txtAdresse" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><label for="txtMail">Email:</label></td>
                                <td><asp:TextBox ID="txtMail" runat="server" TextMode="Email" /></td>
                            </tr>
                            <tr>
                                <td><label for="txtTel">Téléphone:</label></td>
                                <td><asp:TextBox ID="txtTel" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn-submit" Text="Soumettre" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </table>
                    </form>

                    <h2>Liste des étudiants</h2>
                    <asp:Label ID="ErrorLabel" runat="server" CssClass="error-label" />
                    <asp:Table ID="StudentsTable" runat="server">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Nom</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Prénom</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Date de Naissance</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Téléphone</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <script>
        function showForm() {
            const form = document.getElementById("formEtudiant");
            form.style.display = form.style.display === "none" ? "block" : "none";
        }
    </script>
</body>
</html>
