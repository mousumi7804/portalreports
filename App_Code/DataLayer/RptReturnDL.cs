using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RptReturnDL
/// </summary>
/// 

namespace DataLayer
{
    public class RptReturnDL
    {
        public RptReturnDL()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public ReturnDs GetReturnReportData(int monthno,string division,int rows)
        {
            RptReturnList lstReturn = new RptReturnList();
            Common.OpenConnection();
            String sql = "";
            String whsql = "";
            String strconcat = "";
            //populate the where condition


            sql = "select * from rpt_return";
            if (rows > 0)
                sql = "select top 500 * from rpt_return";

            if (monthno > 0)
                sql = sql + " where month=" + monthno;

            if(division!=null && division!="")
            {
                if (sql.Contains("where"))
                    sql = sql + " and upper(Division) = '" + division.ToUpper() + "'";
                else
                    sql = sql + " where upper(Division) = '" + division.ToUpper() + "'";
            }

            int currmonth = DateTime.Now.Month;
            int curryear = DateTime.Now.Year;


            SqlCommand cmd = new SqlCommand(sql, Common.conn);

            ReturnDs dsReturns = new ReturnDs();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                sda.Fill(dsReturns);
            }

            return dsReturns;
        }



        public String populateReportFromSP(string div, string mont)
        {
            String ret = "";

            bool executesp = true;
            Common.OpenConnection();

            DateTime curdate = DateTime.Now;
            int curyr = DateTime.Now.Year;
            int curmn = DateTime.Now.Month;
            int selmn = Common.GetMonthNo(mont);
            if (selmn > curmn)
                curyr = curyr - 1;

            DateTime seldate = Convert.ToDateTime( selmn +"/01"+ "/" + curyr);
            int lastday = Common.GetLastdayOfMonth(seldate);

            String fromdt = curyr+ "-" + mont + "-" + "01";
            String todt = curyr+ "-" + mont + "-" + lastday;

            /* string sql = "select count(*) as cnt from rpt_ageing where division='" + div + "' and month='" + mont + "'";
             SqlCommand cmd = new SqlCommand(sql, Common.conn);
             SqlDataReader rdr = cmd.ExecuteReader();
             if (rdr.Read())
             {
                 int tot = Common.GetInt(rdr["cnt"]);
                 if (tot > 0)
                     executesp = false;
             }
             rdr.Close(); */

            if (executesp)
            {

                if (div.ToLower() == "eva")
                {
                    SqlCommand cmd = new SqlCommand("doctorChemistProduct_promotest_eva", Common.conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stdate", Convert.ToDateTime(fromdt));
                    cmd.Parameters.AddWithValue("@enddate", Convert.ToDateTime(todt));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        using (SqlCommand cmd1 = new SqlCommand("SaveReturnReportFromDT"))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Connection = Common.conn;
                            //  cmd1.Parameters.AddWithValue("@tblotx", dt);
                            cmd1.Parameters.AddWithValue("@tblret", dt);
                            // cmd1.Parameters.AddWithValue("@tblmfso", dt);
                            cmd1.Parameters.AddWithValue("@div", div);
                            cmd1.Parameters.AddWithValue("@month", Common.GetMonthNo(mont));
                            cmd1.ExecuteNonQuery();

                        }

                    }
                }

                if (div.ToLower() == "mad")
                {
                    SqlCommand cmd = new SqlCommand("doctorChemistProduct_promotest_mad", Common.conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stdate", Convert.ToDateTime(fromdt));
                    cmd.Parameters.AddWithValue("@enddate", Convert.ToDateTime(todt));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dt.Columns.Remove("MSRHQ");

                        dt = dt.AsEnumerable().Where(x => x.Field<String>("empno").ToLower().StartsWith("e") == false).CopyToDataTable();

                        using (SqlCommand cmd1 = new SqlCommand("SaveReturnReportFromDT"))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Connection = Common.conn;
                            //  cmd1.Parameters.AddWithValue("@tblotx", dt);
                            cmd1.Parameters.AddWithValue("@tblret", dt);
                            // cmd1.Parameters.AddWithValue("@tblmfso", dt);
                            cmd1.Parameters.AddWithValue("@div", div);
                            cmd1.Parameters.AddWithValue("@month", Common.GetMonthNo(mont));
                            cmd1.ExecuteNonQuery();

                        }

                    }
                }

                if (div.ToLower() == "phoenix")
                {
                    SqlCommand cmd = new SqlCommand("doctorChemistProduct_promotest_PHOEINX", Common.conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stdate", Convert.ToDateTime(fromdt));
                    cmd.Parameters.AddWithValue("@enddate", Convert.ToDateTime(todt));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        using (SqlCommand cmd1 = new SqlCommand("SaveReturnReportFromDT"))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Connection = Common.conn;
                            //  cmd1.Parameters.AddWithValue("@tblotx", dt);
                            cmd1.Parameters.AddWithValue("@tblret", dt);
                            // cmd1.Parameters.AddWithValue("@tblmfso", dt);
                            cmd1.Parameters.AddWithValue("@div", div);
                            cmd1.Parameters.AddWithValue("@month", Common.GetMonthNo(mont));
                            cmd1.ExecuteNonQuery();

                        }

                    }
                }

            }

            Common.CloseConnection();

            ret = "Execution completed for Return report";
            return ret;
        }

    }
}