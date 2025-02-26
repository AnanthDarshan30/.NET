<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentManagement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        /* Navigation bar styling */
        .navbar {
            background-color: black;
            color: white;
            padding: 10px 20px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .navbar a {
            color: white;
            text-decoration: none;
            font-weight: bold;
        }

        .navbar a:hover {
            text-decoration: underline;
        }

        /* Main content styling */
        main {
            padding: 20px;
            text-align: center;
        }

        .blue-button {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            text-decoration: none;
        }

        .blue-button:hover {
            background-color: #0056b3;
        }

        .content {
            margin: 30px auto;
            max-width: 800px;
            text-align: left;
            line-height: 1.6;
        }

        h1 {
            font-size: 2.5em;
            margin-bottom: 20px;
        }

        h2 {
            margin-top: 30px;
            font-size: 1.8em;
        }
    </style>

    <!-- Navigation bar -->
    <div class="navbar">
        <h1>Student Management System</h1>
        <a href="Login.aspx">Login</a>
    </div>

    <!-- Main content -->
    <main>
        <h1>Welcome to the Student Management System</h1>
        <p class="content">
            The Student Management System is a comprehensive platform designed to make managing students' academic
            records easy and efficient. This system allows administrators and teachers to perform tasks such as
            marking attendance, selecting courses, and adding or removing students. It's your one-stop solution for
            managing all aspects of a student's academic journey.
        </p>

        <h2>Features:</h2>
        <ul class="content">
            <li>Track student attendance and performance efficiently.</li>
            <li>Assign and manage courses seamlessly.</li>
            <li>Add and remove students with just a few clicks.</li>
            <li>Centralized database for easy access and updates.</li>
        </ul>

        <a href="Login.aspx" class="blue-button">Go to Login Page</a>
    </main>
</asp:Content>
