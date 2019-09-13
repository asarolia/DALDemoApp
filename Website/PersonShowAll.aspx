<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonShowAll.aspx.cs" Inherits="PersonShowAll" %>
<%@ Import Namespace="Demo.Business" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridPeople" runat="server" AutoGenerateColumns="False" EnableViewState="false" CellPadding=5>            
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <input type="checkbox" name="chkSelectedItems" value="<%# ((Person)Container.DataItem).PersonID.ToString() %>" />
                    </ItemTemplate>
                </asp:TemplateField>                                  
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <%# ((Person)Container.DataItem).PersonID %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last">
                    <ItemTemplate>
                        <%# ((Person)Container.DataItem).NameLast %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First">
                    <ItemTemplate>
                        <%# ((Person)Container.DataItem).NameFirst %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOB">
                    <ItemTemplate>
                        <%# ((Person)Container.DataItem).DOB == Demo.Common.Constants.NullDateTime ? "" : ((Person)Container.DataItem).DOB.ToString("M/d/yyyy") %>
                    </ItemTemplate>
                </asp:TemplateField>             
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <a href="PersonEdit.aspx?PersonID=<%# ((Person)Container.DataItem).PersonID.ToString() %>">Edit</a>
                    </ItemTemplate>
                </asp:TemplateField>                  
            </Columns>
        </asp:GridView>    
        <asp:LinkButton runat="server" ID="lnkDeleteSelected" Text="Delete Selected Items" OnClientClick="return confirm('Are you sure you want to delete the selected items?');" OnClick="lnkDeleteSelected_Click" /><br />
        <a href="PersonEdit.aspx?PersonID=0">Add a New Person</a>
    </div>
    </form>
</body>
</html>
