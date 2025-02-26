<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="QueryString.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 400px;
        }
        .auto-style2 {
            width: 137px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="4" cellspacing="4" class="auto-style1">
            <tr>
                <td class="auto-style2">STUDENT ID</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">STUDENT NAME</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">STUDENT AGE</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
