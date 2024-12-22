﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="project.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <asp:Label ID="l1" Text="ID" runat="server"></asp:Label>
        <asp:TextBox ID="uid" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv1" ControlToValidate="uid" ErrorMessage="ID cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator> 
        <br />
        
        <asp:Label ID="l2" Text="Username" runat="server"></asp:Label>
        <asp:TextBox ID="uname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv2" ControlToValidate="uname" ErrorMessage="Username cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator> 
        <br />
        
        <asp:Label ID="l3" Text="Password" runat="server"></asp:Label>
        <asp:TextBox ID="pass" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv3" ControlToValidate="pass" ErrorMessage="Password cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator> 
        <br />
        
        <asp:Label ID="l4" Text="Re-enter Password" runat="server"></asp:Label>
        <asp:TextBox ID="repass" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv4" ControlToValidate="repass" ErrorMessage="Re-enter Password cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator> 
        <asp:CompareValidator ID="rv6" ControlToValidate="repass" ControlToCompare="pass" ErrorMessage="Passwords must match" ForeColor="Red" runat="server"></asp:CompareValidator> 
        <br />
        
        <asp:Label ID="l5" Text="Gender" runat="server"></asp:Label>
        <asp:RadioButton ID="rb1" GroupName="gender" Text="Male" runat="server" />
        <asp:RadioButton ID="rb2" GroupName="gender" Text="Female" runat="server" />
        <br />
        
        <asp:Label ID="l6" Text="Faculty" runat="server"></asp:Label>
        <asp:DropDownList ID="coun" runat="server">
            <asp:ListItem Value="Select Your Faculty" Text="Select Your Faculty"></asp:ListItem>
            <asp:ListItem Value="BIM">BIM></asp:ListItem>
            <asp:ListItem Value="CSIT">CSIT</asp:ListItem>
            <asp:ListItem Value="BCA" >BCA</asp:ListItem>
        </asp:DropDownList>
        <br />
        
        <asp:Button ID="btn1" Text="Submit"  OnClick="btn_ans" runat="server" />
        <asp:Label ID="l7" Text="Result" runat="server"></asp:Label>

    </form>
</body>
</html>
