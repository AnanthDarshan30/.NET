<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStudents.aspx.cs" Inherits="StudentManagement.ViewStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Student details</title>
</head>
<body>
   <div style="text-align: right; margin: 10px;">
        <a href="Dashboard.aspx" style="text-decoration: none; font-size: 14px; color: blue;">Go to Homepage</a>
    </div>
    <form id="form1" runat="server">
        <h2>View Student Details</h2>
        <div>
            <label for="ddlStudents">Select Student:</label>
            <asp:DropDownList ID="ddlStudents" runat="server"></asp:DropDownList>
            <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" OnClick="btnGetDetails_Click" />
        </div>
        <br />
        <div id="studentDetails" runat="server" visible="false">
            <h3>Student Information</h3>
            <p><strong>Name:</strong> <asp:Label ID="lblStudentName" runat="server"></asp:Label></p>
            <p><strong>Email:</strong> <asp:Label ID="lblStudentEmail" runat="server"></asp:Label></p>
            <p><strong>Phone:</strong> <asp:Label ID="lblStudentPhone" runat="server"></asp:Label></p>
            <br />
            <h3>Enrolled Courses</h3>
            <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="Instructor" HeaderText="Instructor" />
                </Columns>
            </asp:GridView>
            <br />
            <h3>Attendance Records</h3>
            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="AttendanceDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="IsPresent" HeaderText="Present" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
