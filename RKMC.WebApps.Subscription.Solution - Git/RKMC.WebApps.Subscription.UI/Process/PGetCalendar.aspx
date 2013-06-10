<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PGetCalendar.aspx.cs" Inherits="RKMC.WebApps.Subscription.Solution.Process.PGetCalendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="JS/JSCalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 700px; width: 1000px; margin: 0 auto;">
        <div id="PGetCalendar_DivCalendar" style="float: left;">
            <asp:Calendar ID="SubscriptionCalendar" runat="server" DayNameFormat="Full" Width="900px"
                Font-Bold="False" ShowGridLines="True" NextPrevFormat="FullMonth">
                <WeekendDayStyle BackColor="LightGray" />
                <DayStyle VerticalAlign="Top" />
                <TodayDayStyle BackColor="LightBlue" />
                <DayHeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Top" />
            </asp:Calendar>
        </div>
        <div id="PGetCalendar_DivSubscription">
        </div>
    </div>
    </form>
</body>
</html>
