using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_doctorvisit_search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populatedropdowns();
        }
    }


    private void populatedropdowns()
    {
        string curmonth = DateTime.Now.ToString("MMMM");
        bool blncontinue = true;
        String prevmonth = "";
        for (int i = 1; i < Common.monthlist.Length; i++)
        {
            string str = Common.monthlist[i];
            if (curmonth == str)
            {
                blncontinue = false;
            }

            if (blncontinue)
            {
                src_month4m.Items.Add(str);
                prevmonth = str;
            }
        }

        src_month4m.SelectedValue = prevmonth;


        src_div.Items.Add("EVA");
        src_div.Items.Add("MAD");
        src_div.Items.Add("PHOENIX");

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
}