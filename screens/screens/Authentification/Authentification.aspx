<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authentification.aspx.cs" Inherits="screens.screens.Authentification.Authentification" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Authentification</title>
    <style>
        body {
            font-family: Arial, sans-serif;
              background-image: url('../../../assets/bg.jpg');
            background-size: cover;
            background-repeat: no-repeat;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .auth-container {
            background: #fff;
            padding: 30px 40px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
            backdrop-filter: blur(17px) saturate(180%);
            -webkit-backdrop-filter: blur(17px) saturate(180%);
            background-color: rgba(255, 255, 255, 0.47);
            border-radius: 12px;
            border: 1px solid rgba(255, 255, 255, 0.125);
        }

        .auth-container h2 {
            margin-bottom: 20px;
            font-size: 24px;
            color: #333;
            text-align: center;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            color: #555;
            font-weight: bold;
        }

        .form-group input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            font-size: 14px;
        }

        .form-group input:focus {
            border-color: #007bff;
            outline: none;
        }

        .form-group button {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .form-group button:hover {
            background-color: #0056b3;
        }

        .form-footer {
            margin-top: 15px;
            text-align: center;
            font-size: 14px;
            color: #777;
        }

        .form-footer a {
            color: #555;
            text-decoration: none;
        }

        .form-footer a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auth-container">
            <h2>Authentification</h2>
            <div class="form-group">
                <label for="username">Nom d'utilisateur</label>
<asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control" placeholder="Entrez votre nom d'utilisateur" required="true" />
            </div>
            <div class="form-group">
                <label for="password">Mot de passe</label>
<asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Entrez votre mot de passe" required="true" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Onclick" />
            </div>
            <div class="form-footer">
                <p>Vous avez oublié votre mot de passe ? Merci de contacter l'administration</p>
            </div>
        </div>
    </form>
</body>
</html>
