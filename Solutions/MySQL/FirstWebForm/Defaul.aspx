<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaul.aspx.cs" Inherits="FirstWebForm.Defaul" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Height="43px" OnClick="Button1_Click" Text="Click" Width="97px" />
            <asp:Label ID="Label1" runat="server" Text="Run" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
