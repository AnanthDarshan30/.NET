<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceManagement.aspx.cs" Inherits="StudentManagement.ManageAttendance" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Attendance</title>
    <style>
        .submit-button {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
        }
        .submit-button:hover {
            background-color: #45a049;
        }
        #loading {
            font-size: 16px;
            color: blue;
        }
    </style>
</head>
<body>
    <div style="text-align: right; margin: 10px;">
        <a href="Dashboard.aspx" style="text-decoration: none; font-size: 14px; color: blue;">Go to Homepage</a>
    </div>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div id="loading" style="display:none; text-align:center;">Loading...</div>
        <div>
            <h2>Manage Attendance</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblCourse" runat="server" Text="Select Course:"></asp:Label>
            <asp:DropDownList ID="ddlCourses" runat="server">
                <asp:ListItem Text="Select a Course" Value="0" />
            </asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblDate" runat="server" Text="Select Date:"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" TextMode="Date" MaxLength="10"></asp:TextBox>
            <asp:CustomValidator 
                ID="cvDateValidator" 
                runat="server" 
                ControlToValidate="txtDate" 
                ErrorMessage="Date cannot be in the future." 
                OnServerValidate="cvDateValidator_ServerValidate" 
                ForeColor="Red">
            </asp:CustomValidator>
            <br /><br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnLoadStudents" runat="server" Text="Load Students" OnClick="btnLoadStudents_Click" />
                    <br /><br />
                    <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="StudentId" HeaderText="Student ID" ReadOnly="True" />
                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Mark Attendance">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsPresent" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button 
                        ID="btnSubmitAttendance" 
                        runat="server" 
                        Text="Submit Attendance" 
                        OnClick="btnSubmitAttendance_Click" 
                        CssClass="submit-button" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnLoadStudents" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSubmitAttendance" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
       
    </form>
</body>
</html>
