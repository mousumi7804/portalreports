using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class OnlineReport_AgeingReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("ageingreport"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@divisin", "MAD");
                    cmd.Parameters.AddWithValue("@month", "JULY");


                    //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                    //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {

                            sda.Fill(dt);
                            ds.Tables.Add(dt);
                            rpt_ageing.ReportTitle = "Ageing Report";
                            rpt_ageing.ReportName = "Ageing";
                            rpt_ageing.DataBind(ds);
                            rpt_ageing.Visible = true;
                        }
                    }
                }
            }
        }
    }
}