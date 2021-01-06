﻿using DataLayer;
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

public partial class OnlineReport_CallAverageReportFinal : System.Web.UI.Page
{
    string gmonth = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populatedropdowns();

            SearchReportCommon itmsearch = new SearchReportCommon();
            itmsearch.months = "'" + gmonth + "'";
            itmsearch.divs = "'eva'";
            FetchReportdata(itmsearch, 1000);

           
        }
    }

    private void FetchReportdata(SearchReportCommon searchdoctorvisit, int rows)
    {
        DataSet ds = (new RptCallAverageDL()).GetSampleReportDataDynamic(searchdoctorvisit, rows);

        //manage headers as per division
        //String disthead = "";
        //if (searchdoctorvisit.divs.ToLower().Contains("eva") || searchdoctorvisit.divs.ToLower().Contains("concord"))
        //    disthead = "MFSO";

        //if (searchdoctorvisit.divs.ToLower().Contains("phoenix"))
        //{
        //    if (disthead != "")
        //        disthead = disthead + "_SO";
        //    else
        //        disthead = "SO";
        //}
        //if (searchdoctorvisit.divs.ToLower().Contains("mad"))
        //{
        //    if (disthead != "")
        //        disthead = disthead + "_MSR";
        //    else
        //        disthead = "MSR";
        //}
        //if (disthead != "")
        //    disthead = disthead + "_HQ";
        //else
        //    disthead = "MFSO_HQ";

        //ds.Tables[0].Columns["District"].ColumnName = disthead;

        //ds.Tables[0].Columns["AsmHQ"].ColumnName = "ASM_DSO_HQ";

        ds.Tables[0].Columns.Remove("rptcallaverageID");
        ds.Tables[0].Columns.Remove("ASMHQ");
        ds.Tables[0].Columns.Remove("MFSOHQ");
        ds.Tables[0].Columns.Remove("SMHQ");
        //foreach(DataColumn col in ds.Tables[0].Columns)
        //{
        //    col.ColumnName = col.ColumnName.ToUpper();
        //}


        rpt_sample.ReportTitle = "Call Average Report";
        rpt_sample.ReportName = "CallAverageReport";
        rpt_sample.DataBind(ds.Tables[0].Copy());
        rpt_sample.Visible = true;

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        String separator = "";
        String monthsearch = "";
        String divsearch = "";
        string hqsearch = "";
        string empsearch = "";
        string zsmsearch = "";
        string rsmsearch = "";

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
        foreach (ListItem itm in src_hq.Items)
        {
            if (itm.Selected)
            {
                hqsearch = hqsearch + separator + "'" + itm.Value + "'";
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

        //zsm
        separator = "";
        foreach (ListItem itm in src_zsm.Items)
        {
            if (itm.Selected)
            {
                zsmsearch = zsmsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        //rsm
        separator = "";
        foreach (ListItem itm in src_rsm.Items)
        {
            if (itm.Selected)
            {
                rsmsearch = rsmsearch + separator + "'" + itm.Value + "'";
                separator = ",";
            }
        }

        SearchReportCommon itmsearch = new SearchReportCommon();
        itmsearch.months = monthsearch;
        itmsearch.divs = divsearch;
        itmsearch.hqs = hqsearch;
        itmsearch.emps = empsearch;
        itmsearch.zsms = zsmsearch;
        itmsearch.rsms = rsmsearch;
        itmsearch.yr = src_year.SelectedValue;

        FetchReportdata(itmsearch,0);

        String curyear = DateTime.Now.Year.ToString();
        StaticData itmstat = (new RptCallAverageDL()).GetDropdownData(monthsearch, curyear);      //curyear);

        src_zsm.DataSource = itmstat.lstzsm;
        src_zsm.DataBind();

        src_rsm.DataSource = itmstat.lstrsm;
        src_rsm.DataBind();

        src_hq.DataSource = itmstat.lsthq;
        src_hq.DataBind();

        src_employee.DataSource = itmstat.lstemployee;
        src_employee.DataBind();

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        SearchReportCommon itmsearch = new SearchReportCommon();
        itmsearch.months = "'" + gmonth + "'";
        itmsearch.divs = "'eva'";
        itmsearch.yr = src_year.SelectedValue;
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

      //  prevmonth = "november";
        src_month4m.SelectedValue = prevmonth.ToUpper();        //prevmonth;
        gmonth = prevmonth.ToUpper();

        src_year.Items.Add("2020");
        src_year.Items.Add("2021");
        src_year.SelectedValue = lastdayofprevmonth.Year.ToString();       //"2020";

        src_div.Items.Clear();
        src_div.Items.Add("EVA");
        src_div.Items.Add("MAD");
        src_div.Items.Add("PHOENIX");
        src_div.Items.Add("CONCORD");
        src_div.SelectedValue = "eva".ToUpper();

        String curyear = DateTime.Now.Year.ToString();
        StaticData itmstat = (new RptCallAverageDL()).GetDropdownData("'" + prevmonth + "'", lastdayofprevmonth.Year.ToString());      //curyear);

        src_zsm.DataSource = itmstat.lstzsm;
        src_zsm.DataBind();

        src_rsm.DataSource = itmstat.lstrsm;
        src_rsm.DataBind();

        src_hq.DataSource = itmstat.lsthq;
        src_hq.DataBind();

        src_employee.DataSource = itmstat.lstemployee;
        src_employee.DataBind();

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

        string yr = src_year.SelectedValue;

        StaticData itmstaticdata = (new RptCallAverageDL()).PopulateDropdownOnData("division", divsearch, yr, monthsearch, "");

        src_zsm.DataSource = itmstaticdata.lstzsm;
        src_zsm.DataBind();

        src_rsm.DataSource = itmstaticdata.lstrsm;
        src_rsm.DataBind();

        src_hq.DataSource = itmstaticdata.lsthq;
        src_hq.DataBind();

        src_employee.DataSource = itmstaticdata.lstemployee;
        src_employee.DataBind();

    }

    public string mode { get; set; }
}