<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <div> <asp:TextBox ID="TextBox1" runat="server" CssClass="tb"></asp:TextBox>
                                  <cc1:AutoCompleteExtender ServiceMethod="GetEmployeeName"
    MinimumPrefixLength="2"
    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="TextBox1"
    ID="AutoCompleteExtender2" runat="server" FirstRowSelected = "false">
</cc1:AutoCompleteExtender>
    
    </div>
    </form>
</body>
</html>
