<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PGetVendorList.aspx.cs" Inherits="RKMC.WebApps.Subscription.Solution.Process.PGetVendorList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="JS/JSVendorList.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 700px; width: 1000px; margin: 0 auto;">
    <div id="PGetVendors_InnerContent">
        <div id="PGetVendorList_DivVendorList">
            <table class="reportTable" cellpadding="0" cellspacing="1" width="900">
                <thead>
                    <tr>
                        <th>&nbsp;</th>
                        <th align="left">Vendor Name</th>
                        <th align="left">Address</th>
                        <th align="left">City</th>
                        <th align="left">State</th>
                        <th align="left">Zip</th>
                        <th align="left">Phone</th>
                        <th align="left">Email</th>
                        <th align="left">Elite Vendor ID</th>
                        <th align="left">Billed</th>
                        <th align="left">Delivered</th>
                        <th align="left">Type</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal runat="server" ID="litPageMessage" Visible="false" />
                    <asp:Repeater runat="server" ID="rptVendors" Visible="false" OnItemDataBound="Repeater_OnItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td class='BorderBottom BGWhite' style="width:50px;"><asp:Literal runat="server" ID="litEditButton" /> </td>
                                <td class='BorderBottom BGWhite'><%#Eval("VendorName") %></td>
                                <td class='BorderBottom BGWhite'><%#Eval("Address") %></td>
                                <td class='BorderBottom BGWhite'><%#Eval("City") %></td>
                                <td class='BorderBottom BGWhite'><%#Eval("State") %></td>
                                <td class='BorderBottom BGWhite'><%#Eval("Zip") %></td>
                                <td class='BorderBottom BGWhite'><%#Eval("Phone") %></td>
                                <td class='BorderBottom BGWhite'><%#Eval("Email") %></td>
                                <td class='BorderBottom BGWhite'><%#Eval("EliteVendorID")%></td>
                                <td class='BorderBottom BGWhite'><%#Eval("Billed")%></td>
                                <td class='BorderBottom BGWhite'><%#Eval("Delivered")%></td>
                                <td class='BorderBottom BGWhite'><%#Eval("Type") %></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td class='BorderBottom BGLightGray' style="width:50px;"><asp:Literal runat="server" ID="litEditButton" /> </td>
                                <td class='BorderBottom BGLightGray'><%#Eval("VendorName") %></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("Address") %></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("City") %></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("State") %></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("Zip") %></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("Phone") %></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("Email") %></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("EliteVendorID")%></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("Billed")%></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("Delivered")%></td>
                                <td class='BorderBottom BGLightGray'><%#Eval("Type") %></td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div id="PGetVendorList_DivVendor"></div>
    </div>
    </div>
    </form>
</body>
</html>
