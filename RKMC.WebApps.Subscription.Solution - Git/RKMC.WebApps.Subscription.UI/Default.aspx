<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Master/Subscription.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RKMC.WebApps.Subscription.UI._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#SubscriptionTabs').tabs({
                fx: { effect: 'fade', opacity: 'toggle' }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="DivHeader" style="display:none;">
        <div id="DivHeaderDirectionsText" class="DivHeaderDirections"></div>
        <div class="DivHeaderIcons">&nbsp;</div>
    </div>
    <div class="DivHeader">
        <div style="height:5px;"></div>
    </div>
    <div id="ReportContent">
        <div class="AdminForm">
            <div>
                <div class="ErrorMessage"><asp:Label runat="server" ID="lblMessage" /></div>
            </div>
            <div id="SubscriptionTabs">
				<ul>
                    <li><a href="Process/PGetCalendar.aspx" title="DivCalendar" class="DefaultTabA">Calendar</a></li>
                    <li><a href="Process/PGetVendorList.aspx" title="DivVendorList" class="DefaultTabA">Vendors</a></li>
				</ul>
                <div id="DivCalendar"></div>
                <div id="DivVendorList"></div>
            </div>
        </div>
    </div>
</asp:Content>