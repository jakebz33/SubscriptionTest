<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PGetSubscription.aspx.cs" Inherits="RKMC.WebApps.Subscription.Solution.Process.PGetSubscription" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="JS/JSSubscription.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Literal runat="server" ID="litPageMessage" Visible="false" />
    <div>
        <table cellpadding="5">
            <thead>
                <tr>
                    <td align="center" colspan="2" style="background-color: #e11b23; font-weight: bold; text-align: center; padding: 5px;" >Create/Update Subscription</td>
                </tr>
            </thead>
            <tbody>
                <tr style="display: none;">
                    <td>SubscriptionID:</td>
                    <td><asp:TextBox runat="server" ID="txtSubscriptionID" /></td>
                </tr>
                <tr>
                    <td>Person:</td>
                    <td><asp:TextBox runat="server" ID="txtPerson" /></td>
                </tr>
                <tr>
                    <td>Vendor:</td>
                    <td><asp:dropdownlist runat="server" ID="ddlVendor" /></td>
                </tr>
                <tr>
                    <td>Address Type:</td>
                    <td><div class="RBLADDRESS"><input runat="server" type="radio" id="rbOffice" class="rblAddress" value="Office"  /></div><div style="float: left;">Office</div>
                        <div class="RBLADDRESS"><input runat="server" type="radio" id="rbHome" class="rblAddress" value="Home" /></div><div style="float: left;">Home</div></td>
                </tr>
                <tr class="addressHidden">
                    <td>Address:</td>
                    <td><asp:TextBox runat="server" ID="txtAddress" /></td>
                </tr>
                <tr class="addressHidden">
                    <td>City:</td>
                    <td><asp:TextBox runat="server" ID="txtCity" /></td>
                </tr>
                <tr class="addressHidden">
                    <td>State:</td>
                    <td><asp:TextBox runat="server" ID="txtState" /></td>
                </tr>
                <tr class="addressHidden">
                    <td>Zip:</td>
                    <td><asp:TextBox runat="server" ID="txtZip" /></td>
                </tr>
                <tr>
                    <td>Account Number:</td>
                    <td><asp:TextBox runat="server" ID="txtAccountNumber" /></td>
                </tr>
                <tr>
                    <td>Billing Number:</td>
                    <td><asp:TextBox runat="server" ID="txtBillingNumber" /></td>
                </tr>
                <tr>
                    <td>Start Date:</td>
                    <td><asp:TextBox runat="server" ID="txtStartDate" CssClass="datepicker" /></td>
                </tr>
                <tr>
                    <td>End Date:</td>
                    <td><asp:TextBox runat="server" ID="txtEndDate" CssClass="datepicker" /></td>
                </tr>
                <tr>
                    <td>Paid:</td>
                    <td><asp:TextBox runat="server" ID="txtPaid" /></td>
                </tr>
                <tr>
                    <td>Notes:</td>
                    <td><asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" Width="95%" Height="75px" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-top: 15px;" colspan="2"><input type="button" class="button" id="PGetSubscription_Submit" />
                    <input type="button" class="button" value="Cancel" id="PGetSubscription_Cancel" /></td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
