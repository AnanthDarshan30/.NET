<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="QueryString.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 400px;
        }
        .auto-style2 {
            width: 136px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="4" cellspacing="4" class="auto-style1">
                <tr>
                    <td class="auto-style2">STUDENT ID</td>
                    <td>
                        <asp:TextBox ID="IDTextBox" runat="server" Width="164px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">STUDENT NAME</td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Width="164px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">STUDENT AGE</td>
                    <td>
                        <asp:TextBox ID="AgeTextBox" runat="server" Width="164px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="SendButton" runat="server" Height="33px" OnClick="SendButton_Click" Text="Send" Width="71px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
