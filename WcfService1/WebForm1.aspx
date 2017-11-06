<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WcfService1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:cornflowerblue">
    <form id="form1" runat="server">
        <div style="margin-top:50px">
            <asp:FileUpload ID="FileUpload1" runat="server"  />
        </div>
        
        <div >
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" Width="200px" style="background-color:lightblue" />
        </div>  <div >

        <asp:Button ID="Button2" runat="server" Text="Download" OnClick="Button2_Click" Width="200px" style="background-color:lightblue" />
            </div>

    </form>
</body>
</html>
