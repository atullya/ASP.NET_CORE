<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="L1" Text="Username" runat="server"></asp:Label>
        <asp:TextBox ID="uname" runat="server"></asp:TextBox><br />
         <asp:Label ID="L2" Text="Password" runat="server"></asp:Label>
 <asp:TextBox ID="pass" TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:Button Id="submit" runat="server" OnClick="btn_log" Text="Submit"/>
        <asp:Label ID="res"  runat="server"></asp:Label>
    </form>
</body>
</html>
