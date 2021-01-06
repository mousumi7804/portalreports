<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SampleReportFinal.aspx.cs" Inherits="OnlineReport_SampleReportFinal" %>

<%@ Register Src="../UserControl/report_viewer.ascx" TagName="report_viewer" TagPrefix="uc1" %>



<%@ Register Src="../UserControl/doctorvisit_search.ascx" TagName="doctorvisit_search" TagPrefix="uc2" %>



<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">--%>
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
<%--<link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>--%>
<%--<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>--%>


<%--</asp:Content>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        label {
            color: Black;
        }
    </style>
    <script src="../lib/jquery-3.3.1.min.js" type="text/javascript"></script>
    <link href="../lib/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../lib/bootstrap.min.js" type="text/javascript"></script>
    <link href="../lib/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../lib/bootstrap-multiselect.min.js" type="text/javascript"></script>


    <%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">--%>


    <%--<table width="100%">
        <tr>
            <td>
                <div style="height: 30px; text-align: center;">
                    <h2>Doctor Visit Report</h2>
                </div>

                <div style="padding-top: 10px; padding-bottom: 40px;">
                    
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">--%>

    <asp:UpdatePanel runat="server" ID="pnl_report">
        <ContentTemplate>
            <div class="container">
                <div class="col-md-12" style="text-align: center;">
                    <h2>Sample Report</h2>
                </div>
                <div class="col-md-12">&nbsp;</div>
                <div class="col-md-12">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </div>

                <div id="adminsearch" style="visibility: visible;" >
                    <div class="row">
                        
                        <div class="col-md-3">
                            <label>Month</label></div>
                        <div class="col-md-3">
                            <label>Year</label></div>
                        <div class="col-md-3">
                            <label>Division</label></div>
                        <div class="col-md-3">
                            <label>ZSM HQ</label></div>
                        <%--<div class="col-md-3">
                            <label>Employee</label></div>--%>
                    </div>
                    
                    <div class="row">                        
                        <div class="col-md-3">
                            <asp:ListBox ID="src_month4m" runat="server" SelectionMode="Single"></asp:ListBox>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="src_year" runat="server" AppendDataBoundItems="false" ></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:ListBox ID="src_div" runat="server" SelectionMode="Multiple" AppendDataBoundItems="false" onchange="DropdownPopulate();"></asp:ListBox>
                        </div>
                        <div class="col-md-3">
                            <asp:ListBox ID="src_zsm" runat="server" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
                        </div>
                    </div>
                    <div class="row">&nbsp;</div>
                    <div class="row">
                        <div class="col-md-3">
                            <label>RSM-HQ</label></div>
                        <div class="col-md-3">
                            <label>District</label></div>
                        <div class="col-md-3">
                            <label>Employee</label></div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:ListBox ID="src_rsm" runat="server" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
                        </div>
                       <div class="col-md-3">
                            <asp:ListBox ID="src_district" runat="server" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
                        </div>
                        <div class="col-md-3">
                            <asp:ListBox ID="src_employee" runat="server" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
                        </div>
                    </div>
                <div class="row">
                    &nbsp;
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-2">
                        <asp:Button ID="btnsearch" runat="server" Text="Search" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsearch_Click" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnReset_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnhiddenforjs" runat="server" OnClick="btnhiddenforjs_Click" style="visibility:hidden;" />
                    </div>
                </div>
                <div class="row">
                    &nbsp;
                </div>
                </div>

        <div class="col-md-12">
            <uc1:report_viewer ReportTitle="Default" ReportName="Default Name" runat="server"
                ID="rpt_sample" />
        </div>
            </div>



            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>



            <script type="text/javascript">
                function pageLoad(sender, args) {
                    $(document).ready(function () {

                        $('[id*=src_month4m]').multiselect({
                            includeSelectAllOption: true,
                            maxHeight: 400,
                            enableFiltering: true,
                            enableCaseInsensitiveFiltering: true
                        });

                        $('[id*=src_div]').multiselect({
                            includeSelectAllOption: true,
                            maxHeight: 400,
                            enableFiltering: true,
                            enableCaseInsensitiveFiltering: true
                        });

                        $('[id*=src_district]').multiselect({
                            includeSelectAllOption: true,
                            maxHeight: 400,
                            enableFiltering: true,
                            enableCaseInsensitiveFiltering: true
                        });

                        $('[id*=src_employee]').multiselect({
                            includeSelectAllOption: true,
                            maxHeight: 400,
                            enableFiltering: true,
                            enableCaseInsensitiveFiltering: true
                        });

                        $('[id*=src_zsm]').multiselect({
                            includeSelectAllOption: true,
                            maxHeight: 400,
                            enableFiltering: true,
                            enableCaseInsensitiveFiltering: true
                        });

                        $('[id*=src_rsm]').multiselect({
                            includeSelectAllOption: true,
                            maxHeight: 400,
                            enableFiltering: true,
                            enableCaseInsensitiveFiltering: true
                        });
                    });
                }

                function DropdownPopulate() {
                    var values = "";
                    var sepa = "";
                    var selected = $("[id*=src_div] :selected");
                    selected.each(function () {
                        values = values + sepa + "'" + $(this).val() + "'";
                        sepa = ",";
                        //values += $(this).html() + " " + $(this).val() + "\n";
                    });

                    var selmn = "";
                    sepa = "";
                    selected = $("[id*=src_month4m] :selected");
                    selected.each(function () {
                        selmn = selmn + sepa + "'" + $(this).val() + "'";
                        sepa = ",";
                    });

                    <%= Page.ClientScript.GetPostBackEventReference(btnhiddenforjs,"") %>

                   <%-- $.ajax({
                        type: "post",
                        url: "json/DoctorVisitJSON.asmx/PopulateAllData",
                        dataType: "text",
                        data: {
                            'filteron': 'division',
                            'value': values,
                            'mvalue': selmn,
                            'dvalue':''
                        },
                        success: function (result) {
                            $("[id$=src_rsm]").innerHTML = result;
                            //document.getElementById("<%= src_rsm.ClientID %>").innerHTML = request;
                        }
                    });--%> // End ajax method
                }



            </script>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

