<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineReport/OReport.master" AutoEventWireup="true" CodeFile="ExecuteSp.aspx.cs" Inherits="OnlineReport_ExecuteSp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="padding-bottom:30px;">
            <div>
                <h2>Ageing Stored procedure</h2>
            </div>
            <div id="divheadselection" runat="server" style="padding-bottom: 40px;">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 25%">
                            <asp:DropDownList ID="ddlDivision_ageing" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width: 25%">
                            <asp:DropDownList ID="ddlmonth_ageing" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width: 25%">
                            <asp:Button ID="btnsprun_ageing" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_ageing_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblageingmsg" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>
        
        <div style="padding-bottom:30px;">
            <div>
                <h2>Return Store procedure</h2>
            </div>
            <div id="div1" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlDivision_return" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_return" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_return" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_return_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblreturnmsg" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>

    
        <div style="padding-bottom:30px;">
            <div>
                <h2>Doctor Visit Store procedure</h2>
            </div>
            <div id="div2" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_docvisit" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_docvisit" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_docvisit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lbldocvisitmsg" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>

    <div style="padding-bottom:30px;">
            <div>
                <h2>Doctor Chemist Mapping Store procedure</h2>
            </div>
            <div id="div3" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_docchemmap" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_docchemmap" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_docchemmap_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lbldocchemmapmsg" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>

    <div style="padding-bottom:30px;">
            <div>
                <h2>Doctor List Store procedure</h2>
            </div>
            <div id="div4" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_doclist" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_doclist" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_doclist_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lbldoclist" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>
    <div style="padding-bottom:30px;">
            <div>
                <h2>Tour Plan Store procedure</h2>
            </div>
            <div id="div5" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_tourplan" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_tourplan" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_tourplan_Click"  />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lbltourplan" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>

     <div style="padding-bottom:30px;">
            <div>
                <h2>Unlisted Client Visit Store procedure</h2>
            </div>
            <div id="div6" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_unlistedvisit" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_unlistedvisit" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_unlistedvisit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblunlistedvisit" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>

     <div style="padding-bottom:30px;">
            <div>
                <h2>Sample Store procedure</h2>
            </div>
            <div id="div7" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_sample" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_sample" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_sample_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblsample" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>

    <div style="padding-bottom:30px;">
            <div>
                <h2>Call Average Store procedure</h2>
            </div>
            <div id="div8" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_callaverage" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_callaverage" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_callaverage_Click"  />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblcallaverage" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>

    <div style="padding-bottom:30px;">
            <div>
                <h2>Ageing Transaction Store procedure</h2>
            </div>
            <div id="div9" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_ageingtransaction" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_ageingtransaction" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_ageingtransaction_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblageingtransaction" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>

     <div style="padding-bottom:30px;">
            <div>
                <h2>Monthly Attendance Store procedure</h2>
            </div>
            <div id="div10" runat="server" style="padding-bottom:40px;">
                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            <asp:DropDownList ID="ddlmonth_monthlyattn" runat="server" Width="75%"></asp:DropDownList>
                        </td>
                        <td style="width:25%">
                             <asp:Button ID="btnsprun_monthlyattn" runat="server" Text="Execute SP" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsprun_monthlyattn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblmonthlyattn" runat="server" Font-Size="18px" ForeColor="Red"></asp:Label>
            </div>
        </div>
</asp:Content>

