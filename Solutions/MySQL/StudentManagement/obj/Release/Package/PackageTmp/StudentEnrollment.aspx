<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEnrollment.aspx.cs" Inherits="StudentManagement.EnrollStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student</title>
    <style>
        .error{
            border: 2px solid red;
        }
    </style>
</head>
<body>
    <div style="text-align: right; margin: 10px;">
        <a href="Dashboard.aspx" style="text-decoration: none; font-size: 14px; color: blue;">Go to Homepage</a>
    </div>
    <form id="form1" runat="server">
        <div>
            <h2>Enroll a New Student</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblPhone" runat="server" Text="Phone:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblCourse" runat="server" Text="Select Course:"></asp:Label>
            <asp:DropDownList ID="ddlCourses" runat="server"></asp:DropDownList>
            <br /><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Enroll" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
