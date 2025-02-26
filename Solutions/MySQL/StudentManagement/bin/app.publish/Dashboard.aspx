<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="StudentManagement.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
</head>
<body>
    <div style="text-align: right; margin: 10px;">
        <a href="Dashboard.aspx" style="text-decoration: none; font-size: 14px; color: blue;">Go to Homepage</a>
    </div>
    <form id="form1" runat="server">
        <div>
            <h2>Welcome, <asp:Label ID="lblUsername" runat="server"></asp:Label></h2>
            <br />

            <asp:Button ID="btnEnrollStudents" runat="server" Text="Enroll Students" OnClick="btnEnrollStudents_Click" />
            <br /><br />

            <asp:Button ID="btnManageAttendance" runat="server" Text="Manage Attendance" OnClick="btnManageAttendance_Click" />
            <br /><br />

            <asp:Button ID="btnViewCourses" runat="server" Text="View Courses and Students" OnClick="btnViewCourses_Click" />
            <br /><br />

            <asp:Button ID="btnViewStudents" runat="server" Text="View Students" OnClick="btnViewStudents_Click" />
            <br /><br />

            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
