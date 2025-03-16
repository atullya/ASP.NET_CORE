<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MidTermExam.aspx.cs" Inherits="MidTermPractise.MidTermExam" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
</head>
<body>
    <form id="form1" runat="server">
 
            <!-- ID Field -->
            <asp:Label runat="server" ID="l1" Text="ID"></asp:Label>
            <asp:TextBox runat="server" ID="uid"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rv1" runat="server" ControlToValidate="uid" ErrorMessage="Id cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <!-- Username Field -->
            <asp:Label ID="l2" Text="Username" runat="server"></asp:Label>
            <asp:TextBox runat="server" ID="uname"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rv2" runat="server" ControlToValidate="uname" ErrorMessage="Username cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

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
            <asp:RangeValidator ID="rv6" ControlToValidate="age" MinimumValue="18" MaximumValue="100" Type="Integer" ErrorMessage="Age must be between 18 and 100" ForeColor="Red" runat="server"></asp:RangeValidator>
            <br />


            <!-- Gender Field -->
             <!-- input type="radio" -->
            <asp:Label ID="l6" Text="Gender" runat="server"></asp:Label>
            <asp:RadioButton ID="rb1" GroupName="gender" Text="Male" runat="server" />
            <asp:RadioButton ID="rb2" GroupName="gender" Text="Female" runat="server" />
            <br />

            <!-- Country Checkbox Field -->
            <asp:Label ID="l7" Text="Select Country" runat="server"></asp:Label>
            <asp:CheckBox ID="chkNepal" runat="server" Text="Nepal" />
            <asp:CheckBox ID="chkIndia" runat="server" Text="India" />
            <asp:CheckBox ID="chkOther" runat="server" Text="Other" />
            <br />

            <!-- <select>
                <option value=""></option>
            </select> -->
            <!-- Faculty DropDown Field -->
            <asp:Label ID="l8" Text="Select Faculty" runat="server"></asp:Label>
            <asp:DropDownList ID="facu" runat="server">
                <asp:ListItem Value="Select Your Faculty" Text="Select Your Faculty"></asp:ListItem>
                <asp:ListItem Value="BIM">BIM</asp:ListItem>
                <asp:ListItem Value="CSIT">CSIT</asp:ListItem>
                <asp:ListItem Value="BCA">BCA</asp:ListItem>
            </asp:DropDownList>
            <br />

            <asp:Label ID="lblMessage" runat="server" ></asp:Label>

            <!-- Submit Button -->
           <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />

            <!-- Display Data Table -->
            <asp:GridView ID="gridView" runat="server"></asp:GridView>
       

     
    </form>
</body>
</html>
