<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayCourses.aspx.cs" Inherits="StudentManagement.DispalyCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Courses and Students</title>
    
</head>
<body>
    <div style="text-align: right; margin: 10px;">
        <a href="Dashboard.aspx" style="text-decoration: none; font-size: 14px; color: blue;">Go to Homepage</a>
    </div>
     <h1>Courses and Students</h1>

    <!-- Dropdown to Select Course -->
    <form id="form1" runat="server">
        <label for="courseDropdown">Select a Course:</label>
        <asp:DropDownList ID="courseDropdown" runat="server"></asp:DropDownList>
        <br /><br />
        <asp:Button ID="btnGetStudents" runat="server" Text="Get Students" OnClick="btnGetStudents_Click" />
    </form>

    <br />
    <!-- Area to Display Students -->
    <div>
        <h2>Students in Selected Course:</h2>
        <asp:Literal ID="studentList" runat="server"></asp:Literal>
    </div>
</body>
</html>
