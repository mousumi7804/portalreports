using DataLayer;
using Microsoft.Reporting.WebForms;
using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnlineReport_AgeingReportFinal : System.Web.UI.Page
{
    string gmonth = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populatedropdowns();

            SearchDoctorVisit itmsearch = new SearchDoctorVisit();
            itmsearch.months = "'" + gmonth + "'";
            itmsearch.divs = "'eva'";
            FetchReportdata(itmsearch, 1000);

            
        }
    }

    private void FetchReportdata(SearchDoctorVisit searchdoctorvisit, int rows)
    {
        DataSet ds = (new RptDocVisitDL()).GetDoctorVisitReportDataDynamic(searchdoctorvisit, rows);

        //manage headers as per division
        String disthead = "";
        if (searchdoctorvisit.divs.ToLower().Contains("eva") || searchdoctorvisit.divs.ToLower().Contains("concord"))
            disthead = "MFSO";

        if (searchdoctorvisit.divs.ToLower().Contains("phoenix"))
        {
            if (disthead != "")
                disthead = disthead + "_SO";
            else
                disthead = "SO";
        }
        if (searchdoctorvisit.divs.ToLower().Contains("mad"))
        {
            if (disthead != "")
                disthead = disthead + "_MSR";
            else
                disthead = "MSR";
        }
        if (disthead != "")
            disthead = disthead + "_HQ";
        else
            disthead = "MFSO_HQ";

        ds.Tables[0].Columns["District"].ColumnName = disthead;

        ds.Tables[0].Columns["AsmHQ"].ColumnName = "ASM_DSO_HQ";

        ds.Tables[0].Columns.Remove("rptdoctorvisitID");

        foreach(DataColumn col in ds.Tables[0].Columns)
        {
            col.ColumnName = col.ColumnName.ToUpper();
        }


        rpt_docvisit.ReportTitle = "Doctor Visit Report";
        rpt_docvisit.ReportName = "DoctorVisitReport";
        rpt_docvisit.DataBind(ds.Tables[0].Copy());
        rpt_docvisit.Visible = true;

        Session["tab"] = ds.Tables[0];
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        String separator = "";
        String monthsearch = "";
        String divsearch = "";
        string rsmsearch = "";
        string distsearch = "";
        string empsearch = "";
        string desigsearch = "";
        string asmsearch = "";
        string msrsearch = "";

        foreach(ListItem itm in src_month4m.Items)
        {
            if (itm.Selected)
            {
                monthsearch = monthsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        separator = "";
        foreach(ListItem itm in src_div.Items)
        {
            if (itm.Selected)
            {
                divsearch = divsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        separator = "";
        foreach(ListItem itm in src_rsm.Items)
        {
            if (itm.Selected)
            {
                rsmsearch = rsmsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        separator = "";
        foreach(ListItem itm in src_district.Items)
        {
            if (itm.Selected)
            {
                distsearch = distsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        separator = "";
        foreach(ListItem itm in src_employee.Items)
        {
            if (itm.Selected)
            {
                empsearch = empsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        separator = "";
        foreach(ListItem itm in src_designation.Items)
        {
            if (itm.Selected)
            {
                desigsearch = desigsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        separator = "";
        foreach(ListItem itm in src_asm.Items)
        {
            if (itm.Selected)
            {
                asmsearch = asmsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        separator = "";
        foreach (ListItem itm in src_mfso.Items)
        {
            if (itm.Selected)
            {
                msrsearch = msrsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        SearchDoctorVisit itmsearch = new SearchDoctorVisit();
        itmsearch.months = monthsearch;
        itmsearch.divs = divsearch;
        itmsearch.rsms = rsmsearch;
        itmsearch.dists = distsearch;
        itmsearch.emps = empsearch;
        itmsearch.desigs = desigsearch;
        itmsearch.asms = asmsearch;
        itmsearch.msrs = msrsearch;

        FetchReportdata(itmsearch,0);



    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        SearchDoctorVisit itmsearch = new SearchDoctorVisit();
        itmsearch.months = "'" + gmonth + "'";
        itmsearch.divs = "'eva'";
        FetchReportdata(itmsearch,0);
        populatedropdowns();
    }


    private void populatedropdowns()
    {
        string curmonth = DateTime.Now.ToString("MMMM");
        int curyr = DateTime.Now.Year;
        bool blncontinue = true;
        String prevmonth = "";
        src_month4m.Items.Clear();
        for (int i= 1; i<Common.monthlist.Length;i++)
        {
            string str = Common.monthlist[i];
            //if (curmonth == str)
            //{
            //    blncontinue = false;
            //}

            if (blncontinue)
            {
                src_month4m.Items.Add(str.ToUpper());
                prevmonth = str.ToUpper();
            }
        }

        DateTime firstdayofmonth = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + curyr);
        DateTime lastdayofprevmonth = firstdayofmonth.AddDays(-1);
        prevmonth = Common.monthlist[lastdayofprevmonth.Month];

        //src_month4m.SelectedValue = "August".ToUpper();        //prevmonth;
        src_month4m.SelectedValue = prevmonth.ToUpper();        //prevmonth;
        gmonth = prevmonth.ToUpper();


        src_div.Items.Clear();
        src_div.Items.Add("EVA");
        src_div.Items.Add("MAD");
        src_div.Items.Add("PHOENIX");
        src_div.Items.Add("CONCORD");
        src_div.SelectedValue = "eva".ToUpper();


        StaticData itmstat = (new RptDocVisitDL()).GetDropdownData("'august'");
        src_rsm.DataSource = itmstat.lstrsm;
        src_rsm.DataBind();

        src_district.DataSource = itmstat.lstdistrict;
        src_district.DataBind();

        src_employee.DataSource = itmstat.lstemployee;
        src_employee.DataBind();

        src_designation.DataSource = itmstat.lstdesignation;
        src_designation.DataBind();

        src_asm.DataSource = itmstat.lstasm;
        src_asm.DataBind();

        src_mfso.DataSource = itmstat.lstmsr;
        src_mfso.DataBind();

    }

    protected void btnsearch_Click1(object sender, EventArgs e)
    {
        Response.Redirect("ReportSearchCommon.aspx");
    }


    protected void btnhiddenforjs_Click(object sender, EventArgs e)
    {
        String separator = "";
        String divsearch = "";
        foreach (ListItem itm in src_div.Items)
        {
            if (itm.Selected)
            {
                divsearch = divsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        String monthsearch = "";
        separator = "";
        foreach (ListItem itm in src_month4m.Items)
        {
            if (itm.Selected)
            {
                monthsearch = monthsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        if (divsearch == "")
        {
            divsearch = "'eva'";
            src_div.SelectedValue = "eva".ToUpper();
        }

        StaticData itmstaticdata = (new RptDocVisitDL()).PopulateDropdownOnData("division", divsearch, monthsearch, "");
        src_rsm.DataSource = itmstaticdata.lstrsm;
        src_rsm.DataBind();

        src_district.DataSource = itmstaticdata.lstdistrict;
        src_district.DataBind();

        src_employee.DataSource = itmstaticdata.lstemployee;
        src_employee.DataBind();

        src_designation.DataSource = itmstaticdata.lstdesignation;
        src_designation.DataBind();

        src_asm.DataSource = itmstaticdata.lstasm;
        src_asm.DataBind();

        src_mfso.DataSource = itmstaticdata.lstmsr;
        src_mfso.DataBind();

    }

    public string mode { get; set; }
}