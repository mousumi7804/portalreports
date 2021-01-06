<%@ Page Title="" Language="C#" MasterPageFile="" AutoEventWireup="true" CodeFile="ReportSearchCommon.aspx.cs" Inherits="OnlineReport_ReportSearchCommon" %>

<%@ Register Src="../UserControl/doctorvisit_search.ascx" TagName="doctorvisit_search" TagPrefix="uc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../lib/jquery-3.3.1.min.js"></script>
    <link href="../lib/bootstrap.min.css" rel="Stylesheet" />
    <script src="../lib/bootstrap.min.js"></script>
    <link href="../lib/bootstrap-multiselect.css" rel="Stylesheet" />
    <script src="../lib/bootstrap-multiselect.min.js"></script>
    
    
</head>
<body>
    <form id="form1" runat="server">

        <%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">--%>

        <div>
            <uc1:doctorvisit_search ID="doctorvisit_search1" runat="server" />
        </div>
        <%--</asp:Content>--%>
    </form>
</body>
</html>
