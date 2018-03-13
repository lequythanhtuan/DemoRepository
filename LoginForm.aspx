<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginForm.aspx.cs" Inherits="LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style type="text/css">
        ul li {
            list-style: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: auto; width: 100%; text-align: center; margin-top: 150px;">
            <ul>
                <li>UserID
                </li>
                <li>
                    <asp:TextBox
                        autofocus="autofocus"
                        runat="server" ID="txtUser"></asp:TextBox>
                </li>
                <li>Password
                </li>
                <li>
                    <asp:TextBox runat="server" ID="txtPassword"
                        TextMode="Password"></asp:TextBox>
                </li>
                <br />
                <li>
                    <asp:Label runat="server" ID="lblTB"></asp:Label>
                </li>
                <li>
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success"
                        OnClick="btnSubmit_Click"
                        Text="Sign In"></asp:Button>
                </li>

            </ul>
            <div class="alert alert-danger" runat="server" id="notification">
                <strong>Email or Password is invalid</strong>
            </div>
        </div>
    </form>
</body>
</html>
