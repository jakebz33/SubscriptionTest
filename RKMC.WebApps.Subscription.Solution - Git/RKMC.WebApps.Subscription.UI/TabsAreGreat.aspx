<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TabsAreGreat.aspx.cs" Inherits="RKMC.WebApps.Subscription.Solution.TabsAreGreat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/jquery-ui.min.js"></script>

    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/themes/cupertino/jquery-ui.css" type="text/css" rel="stylesheet" />


    <script language="javascript">
        $(document).ready(function () {
            $('#MyTestTabs').tabs({
                fx: { effect: 'fade', opacity: 'toggle' }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <div id="MyTestTabs">
				<ul>
                    <li><a href='TabA.aspx' title="DivTabA">Tab A</a></li>
                    <li><a href='TabB.aspx' title="DivTabB">Tab B</a></li>
				</ul>
                <div id="DivTabA"></div>
                <div id="DivTabB"></div>
            </div>
    </div>
    </form>
</body>
</html>