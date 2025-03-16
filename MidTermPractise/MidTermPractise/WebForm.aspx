<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="FinalExam.WebForm" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
</head>
<body>
    <form ID="form1" runat="server">

        <asp:Label runat="server" ID="l1" Text="Username"></asp:Label>
        <asp:TextBox runat="server" ID="uname"></asp:TextBox>
        <asp:RequriedFieldValidator ID="rv1" runat="server" ControlToValidate="uname" ErrorMessage="Username chaixa..." ForeColor="Blue" > </asp:RequriedFieldValidator>
    
        <!-- Password Field -->
     <asp:Label ID="l3" Text="Password" runat="server"></asp:Label>
     <asp:TextBox ID="pass" TextMode="Password" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="rv3" ControlToValidate="pass" ErrorMessage="Password cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
     <br />

     <!-- Re-enter Password Field -->
     <asp:Label ID="l4" Text="Re-enter Password" runat="server"></asp:Label>
     <asp:TextBox ID="repass" TextMode="Password" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="rv4" ControlToValidate="repass" ErrorMessage="Re-enter Password cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
    
    
     <asp:CompareValidator ID="cv1" ControlToValidate="repass" ControlToCompare="pass" ErrorMessage="Passwords must match" ForeColor="Red" runat="server"></asp:CompareValidator>
     <br />

       <!-- Age Field (Range Validator) -->
       <asp:Label ID="l5" Text="Age" runat="server"></asp:Label>
       <asp:TextBox ID="age" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rv5" ControlToValidate="age" ErrorMessage="Age cannot be empty" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
      
       <asp:RangeValidator ID="rv6" ControlToValidate="age" MinimumValue="18" MaximumValue="80" Type="Integer" ErrorMessage="Age must be between 18 and 100" ForeColor="Red" runat="server"></asp:RangeValidator>
       <br />

  

    </form>

</body>

</html>