<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DepotwiseProductSale.aspx.cs" Inherits="OnlineReport_DepotwiseProductSale" %>

<%@ Register Src="~/UserControl/report_viewer.ascx" TagName="reportviewer" TagPrefix="uc1" %>
 <%@Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" 
      namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb"%>
<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
<link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        label
        {
            color:Black;
            }
        
    </style>

    
    <script src="lib/jquery-3.3.1.min.js"></script>
    <link href="lib/bootstrap.min.css" rel="stylesheet" />
        <script src="lib/bootstrap.min.js"></script>
    <link href="lib/bootstrap-multiselect.css" rel="stylesheet" />
      <script src="lib/bootstrap-multiselect.min.js"></script>




    <script type="text/javascript">  
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('[id*=SKT]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 400,
                    enableFiltering: true,
                    enableCaseInsensitiveFiltering: true
                });
                $('[id*=PPS]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 400,
                    enableFiltering: true,
                    enableCaseInsensitiveFiltering: true
                });
                $('[id*=Division').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 400,
                    enableFiltering: true,
                    enableCaseInsensitiveFiltering: true
                });


            });
            setTimeout(function () {
                window.document.getElementById('wp').style.display = 'none';
                window.document.getElementById('searchp').style.display = '';
            }, 100);
        }
    </script>



<%--</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">--%>
    <asp:UpdatePanel runat="server" ID="pnl_report">
        <ContentTemplate>
            <div class="container">
                <div id="wp" style="display : none; min-height : 200px; text-align : center; font-size : 22px; font-weight : bold;"> Please wait</div>
                                <div id="searchp" style="display : none;">
                <div class="row">
                    <div class="col-md-2">
                        <label for="From Date">
                            From Date:</label><br />
                        <asp:TextBox ID="txtfrmdate" runat="server" autocomplete="off" onkeydown="return false;"
                            AutoCompleteType="Disabled"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="req" runat="server" ErrorMessage="*Required" ControlToValidate="txtfrmdate"
                    CssClass="req_css" ValidationGroup="req"></asp:RequiredFieldValidator>
                        <asp:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtfrmdate" />
                    </div>
                    
                  

                    <div class="col-md-3">
                <label for="From Date">
                    Product name & Pack Size</label><br />
                <%--<asp:DropDownList ID="PPS" runat="server" DataSourceID="mendinemaster" 
                    DataTextField="Mpharm_Pd_Name" DataValueField="Mpharm_Pd_Name">
                </asp:DropDownList>--%>
                 <asp:ListBox ID="PPS" runat="server" SelectionMode="Multiple" 
            DataSourceID="mendinemaster" DataTextField="Mpharm_Pd_Name" 
            DataValueField="Mpharm_Pd_Name" ></asp:ListBox>
                <asp:SqlDataSource ID="mendinemaster" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>" 
                    SelectCommand="select distinct Mpharm_Pd_Name from (SELECT mpharm_pd_name+'---'+cast(pack as varchar) Mpharm_Pd_Name 
                    FROM [ProductTransform] 
                   )a order by Mpharm_Pd_Name">
                </asp:SqlDataSource>
            </div>

            <div class="col-md-3">
                <label for="From Date">
                    Division:</label><br />
                <%--<asp:DropDownList ID="PPS" runat="server" DataSourceID="mendinemaster" 
                    DataTextField="Mpharm_Pd_Name" DataValueField="Mpharm_Pd_Name">
                </asp:DropDownList>--%>
                 <asp:ListBox ID="Division" runat="server" SelectionMode="Multiple">
                            <asp:ListItem>PHOENIX</asp:ListItem>
                            <asp:ListItem>EVA</asp:ListItem>
                            <asp:ListItem>CONCORD</asp:ListItem>
                        </asp:ListBox>
            </div>

             <div class="col-md-3">
                <label for="From Date">
                    Stock location:</label><br />
                <asp:ListBox ID="SKT" runat="server" SelectionMode="Multiple" DataSourceID="Stocklocation"
                            DataTextField="STOCKLOCATION" DataValueField="STOCKLOCATION"></asp:ListBox>
                        <asp:SqlDataSource ID="Stocklocation" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="Select Depo STOCKLOCATION from vw_outsrandingdepo order by depo">
                        </asp:SqlDataSource>
            </div>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="req"
                            OnClick="btnsubmit_Click" />
                    </div>

</div>
                </div>
                <div class="row">
                    <div class="col-md-5">
                        <asp:Label ID="lblstatus" runat="server"></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <uc1:reportviewer ReportTitle="Default" ReportName="Default Name" runat="server"
                            ID="rpt_Transactionbilltrends" />
                    </div>
                </div>
            </div>

            <script>
                function fnc() {
                    window.document.getElementById('searchp').style.display = 'none';
                    window.document.getElementById('wp').style.display = '';

                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
