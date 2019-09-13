<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonEdit.aspx.cs" Inherits="PersonEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblMsg" />
        <table cellpadding=5 cellspacing=0>
            <tr>
                <td>PersonID</td>
                <td><asp:Label runat="server" ID="lblPersonID" /></td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtNameFirst" />
                    <asp:RequiredFieldValidator runat="server" ID="req01" Text="*" ControlToValidate="txtNameFirst" ErrorMessage="First Name is required" />
                </td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtNameLast" />
                    <asp:RequiredFieldValidator runat="server" ID="req02" Text="*" ControlToValidate="txtNameLast" ErrorMessage="Last Name is required" />
                </td>
            </tr>
            <tr>
                <td>Birth Date:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtDOB" />
                    <asp:RangeValidator runat="server" ID="rng01" Text="*" ControlToValidate="txtDOB" MinimumValue="1/1/1850" MaximumValue="1/1/2010" Type="Date" ErrorMessage="Please enter a valid birth date" />
                </td>
            </tr>                            
            <tr>
                <td></td>
                <td><asp:Button runat="server" ID="cmdSave" Text="Save" OnClick="cmdSave_Click" /></td>
            </tr>
        </table>
        <asp:ValidationSummary runat="server" ID="valSum" ShowMessageBox="true" ShowSummary="false" />
    </div>
    </form>
</body>
</html>
