<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PGetVendor.aspx.cs" Inherits="RKMC.WebApps.Subscription.Solution.Process.PGetVendor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="JS/JSVendor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Literal runat="server" ID="litPageMessage" Visible="false" />
    <div>
        <table cellpadding="5" style="border: 1px solid black; padding: 5px;">
            <thead>
                <tr>
                    <td colspan="2" style="background-color: #e11b23; font-weight: bold; text-align: center; padding: 5px;" >Create/Update Vendor</td>
                </tr>
            </thead>
            <tr>
                <td>Vendor Name:</td>
                <td><asp:TextBox runat="server" ID="txtVendorName" /></td>
            </tr>
            <tr style="display: none;">
                    <td>VendorID:</td>
                    <td><asp:TextBox runat="server" ID="txtVendorID" /></td>
                </tr>
            <tr>
                <td>Address:</td>
                <td><asp:TextBox runat="server" ID="txtAddress" /></td>
            </tr>
            <tr>
                <td>City:</td>
                <td><asp:TextBox runat="server" ID="txtCity" /></td>
            </tr>
            <tr>
                <td>State:</td>
                <td><asp:TextBox runat="server" ID="txtState" /></td>
            </tr>
            <tr>
                <td>Zip:</td>
                <td><asp:TextBox runat="server" ID="txtZip" /></td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td><asp:TextBox runat="server" ID="txtPhone" /></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox runat="server" ID="txtEmail" /></td>
            </tr>
            <tr>
                <td>Elite Vendor ID:</td>
                <td><asp:TextBox runat="server" ID="txtEliteVendorID" /></td>
            </tr>
            <tr>
                <td>Billed:</td>
                <td><asp:TextBox runat="server" ID="txtBilled" /></td>
            </tr>
            <tr>
                <td>Delivered:</td>
                <td><asp:TextBox runat="server" ID="txtDelivered" /></td>
            </tr>
            <tr>
                <td>Type:</td>
                <td><asp:TextBox runat="server" ID="txtType" /></td>
            </tr>
            <tr>
                <td></td>
                <td style="padding-top: 15px;"><input type="button" class="button" value="Save" id="PGetVendor_Save" />
                <input type="button" class="button" value="Cancel" id="PGetVendor_Cancel" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
