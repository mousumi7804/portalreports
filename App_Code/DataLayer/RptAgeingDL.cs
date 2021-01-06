
using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RptAgeingDL
/// </summary>
/// 

namespace DataLayer
{
    public class RptAgeingDL
    {
        public RptAgeingDL()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public MendineMasterdummyDataSet GetAgeingReportData(SearchAgeing itmsearch)
        {
            RptAgeingList lstAgeing = new RptAgeingList();
            Common.OpenConnection();
            String sql = "select * from rpt_ageing";
            string whsql = "";
            string strconcat = "";
            if (itmsearch.rsm != null && itmsearch.rsm != "" && itmsearch.rsm != "select")
            {
                whsql = whsql + strconcat + " RSMHQ like '%" + itmsearch.rsm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.asm != null && itmsearch.asm != "" && itmsearch.asm != "select")
            {
                whsql = whsql + strconcat + " ASMHQ like '%" + itmsearch.asm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.msr != null && itmsearch.msr != "" && itmsearch.msr != "select")
            {
                whsql = whsql + strconcat + " MSRHQ like '%" + itmsearch.msr + "%'";
                strconcat = " and ";
            }
            if (itmsearch.area != null && itmsearch.area != "" && itmsearch.area != "select")
            {
                whsql = whsql + strconcat + " Area like '%" + itmsearch.area + "%'";
                strconcat = " and ";
            }
            if (itmsearch.doctor != null && itmsearch.doctor != "" && itmsearch.doctor != "select")
            {
                whsql = whsql + strconcat + " DoctorName like '%" + itmsearch.doctor + "%'";
                strconcat = " and ";
            }

            if (itmsearch.intFrom > 0 && itmsearch.intTo > 0)
            {
                string months = "";
                string separator = "";
                int count = itmsearch.intFrom;
                while (count <= itmsearch.intTo)
                {
                    months = months + separator + "'" + Common.monthlist.ElementAt(count) + "'";
                    separator = ",";
                    count++;
                }

                whsql = whsql + strconcat + " month in (" + months + ")";
            }

            if (whsql != null && whsql != "")
                sql = sql + " where " + whsql;

            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //return dt;

            MendineMasterdummyDataSet dsCustomers = new MendineMasterdummyDataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                sda.Fill(dsCustomers, "rpt_ageing");
            }

            return dsCustomers;



            //using (SqlDataReader rdr = cmd.ExecuteReader())
            //{
            //    while (rdr.Read())
            //    {
            //        RptAgeing itmaging = new RptAgeing();
            //        itmaging.ZsmHQ = Common.GetString(rdr["ZsmHQ"]);
            //        itmaging.Area = Common.GetString(rdr["Area"]);
            //        itmaging.AreaType = Common.GetString(rdr["AreaType"]);
            //        itmaging.DoctorName = Common.GetString(rdr["DoctorName"]);
            //        lstAgeing.Add(itmaging);
            //    }
            //}



        }

        public StaticData GetDropdownData(string pmonth)
        {
            //StaticData itmstaticdata = new StaticData();
            //itmstaticdata.lstrsm = new List<string>();
            //itmstaticdata.lstrsm.Add("select");
            //itmstaticdata.lstasm = new List<string>();
            //itmstaticdata.lstasm.Add("select");
            //itmstaticdata.lstarea = new List<string>();
            //itmstaticdata.lstarea.Add("select");
            //itmstaticdata.lstdoctor = new List<string>();
            //itmstaticdata.lstdoctor.Add("select");
            //itmstaticdata.lstmsr = new List<string>();
            //itmstaticdata.lstmsr.Add("select");
            

            StaticData itmstaticdata = PopulateDropdownOnData("division", "eva", pmonth, "");

            itmstaticdata.lstdivision = new List<string>();
            itmstaticdata.lstdivision.Add("select");
            itmstaticdata.lstdivision.Add("EVA");
            itmstaticdata.lstdivision.Add("MAD");
            itmstaticdata.lstdivision.Add("PHOENIX");
            itmstaticdata.lstdivision.Add("CONCORD");


            //Common.OpenConnection();
            //try
            //{
            //    String sql = "select distinct RsmHQ from rpt_ageing";
            //    SqlCommand cmd = new SqlCommand(sql, Common.conn);
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        itmstaticdata.lstrsm.Add(Common.GetString(rdr["RsmHQ"]));
            //    }
            //    rdr.Close();

            //    sql = "select distinct AsmHQ from rpt_ageing";
            //    cmd = new SqlCommand(sql, Common.conn);
            //    rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        itmstaticdata.lstasm.Add(Common.GetString(rdr["AsmHQ"]));
            //    }
            //    rdr.Close();

            //    sql = "select distinct MsrHQ from rpt_ageing";
            //    cmd = new SqlCommand(sql, Common.conn);
            //    rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        itmstaticdata.lstmsr.Add(Common.GetString(rdr["MsrHQ"]));
            //    }
            //    rdr.Close();

            //    sql = "select distinct Area from rpt_ageing";
            //    cmd = new SqlCommand(sql, Common.conn);
            //    rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        itmstaticdata.lstarea.Add(Common.GetString(rdr["Area"]));
            //    }
            //    rdr.Close();

            //    sql = "select distinct DoctorName from rpt_ageing";
            //    cmd = new SqlCommand(sql, Common.conn);
            //    rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        itmstaticdata.lstdoctor.Add(Common.GetString(rdr["DoctorName"]));
            //    }
            //    rdr.Close();
            //}
            //catch (Exception ex)
            //{

            //}

            //Common.CloseConnection();

            return itmstaticdata;
        }

        public StaticData PopulateDropdownOnData(string filteron, string values)
        {
            return PopulateDropdownOnData(filteron, values, "", "");
        }

        public StaticData PopulateDropdownOnData(string filteron, string values,string mvalue,string dvalue)
        {
            Common.OpenConnection();
            StaticData itmstaticdata = new StaticData();

            itmstaticdata.lstarea = new List<string>();
            itmstaticdata.lstarea.Add("select");
            itmstaticdata.lstdoctor = new List<string>();
            itmstaticdata.lstdoctor.Add("select");
            itmstaticdata.lstmsr = new List<string>();
            itmstaticdata.lstmsr.Add("select");
            itmstaticdata.lstrsm = new List<string>();
            itmstaticdata.lstrsm.Add("select");
            itmstaticdata.lstdivision = new List<string>();
            itmstaticdata.lstdivision.Add("select");


            if (filteron != null && filteron != "" && filteron.ToLower() == "month")
            {
                string sql = "select distinct Division from rpt_ageing where lower(month) ='" + values.ToLower() + "'";
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdivision.Add(Common.GetString(rdr["Division"]));
                }
                rdr.Close();

                sql = "select distinct RsmHQ from rpt_ageing where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstrsm.Add(Common.GetString(rdr["RsmHQ"]));
                }
                rdr.Close();

                sql = "select distinct MsrHQ from rpt_ageing where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstmsr.Add(Common.GetString(rdr["MsrHQ"]));
                }
                rdr.Close();

                sql = "select distinct Area from rpt_ageing where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstarea.Add(Common.GetString(rdr["Area"]));
                }
                rdr.Close();

                sql = "select distinct DoctorName from rpt_ageing where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdoctor.Add(Common.GetString(rdr["DoctorName"]));
                }
                rdr.Close();
            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "division")
            {
                string extra = "";
                if (mvalue != null && mvalue != "")
                    extra = " and lower(month)='" + mvalue.ToLower() + "'";

                string sql = "select distinct RsmHQ from rpt_ageing where lower(division) ='" + values.ToLower() + "'"+extra;
                
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstrsm.Add(Common.GetString(rdr["RsmHQ"]));
                }
                rdr.Close();

                sql = "select distinct MsrHQ from rpt_ageing where lower(division) ='" + values.ToLower() + "'" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstmsr.Add(Common.GetString(rdr["MsrHQ"]));
                }
                rdr.Close();

                sql = "select distinct Area from rpt_ageing where lower(division) ='" + values.ToLower() + "'" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstarea.Add(Common.GetString(rdr["Area"]));
                }
                rdr.Close();

                sql = "select distinct DoctorName from rpt_ageing where lower(division) ='" + values.ToLower() + "'" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdoctor.Add(Common.GetString(rdr["DoctorName"]));
                }
                rdr.Close();
            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "rsm")
            {
                string extra1 = "",extra2="";
                if(mvalue!=null && mvalue!="")
                    extra1=" and lower(month)='" + mvalue.ToLower() + "'";

                if(dvalue!=null && dvalue!="")
                    extra2 =" and lower(division)='" + dvalue.ToLower() + "'";


                string sql = "select distinct MsrHQ from rpt_ageing where RsmHQ ='" + values + "'" + extra1 + extra2;
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstmsr.Add(Common.GetString(rdr["MsrHQ"]));
                }
                rdr.Close();

                sql = "select distinct Area from rpt_ageing where RsmHQ ='" + values + "'" + extra1 + extra2;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstarea.Add(Common.GetString(rdr["Area"]));
                }
                rdr.Close();

                sql = "select distinct DoctorName from rpt_ageing where RsmHQ ='" + values + "'" + extra1 + extra2;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdoctor.Add(Common.GetString(rdr["DoctorName"]));
                }
                rdr.Close();
            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "msr")
            {
                string extra1 = "", extra2 = "";
                if (mvalue != null && mvalue != "")
                    extra1 = " and lower(month)='" + mvalue.ToLower() + "'";

                if (dvalue != null && dvalue != "")
                    extra2 = " and lower(division)='" + dvalue.ToLower() + "'";

                string sql = "select distinct Area from rpt_ageing where MsrHQ ='" + values + "'" + extra1 + extra2;
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstarea.Add(Common.GetString(rdr["Area"]));
                }
                rdr.Close();

                sql = "select distinct DoctorName from rpt_ageing where MsrHQ ='" + values + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdoctor.Add(Common.GetString(rdr["DoctorName"]));
                }
                rdr.Close();
            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "area")
            {
                
                string extra1 = "", extra2 = "";
                if (mvalue != null && mvalue != "")
                    extra1 = " and lower(month)='" + mvalue.ToLower() + "'";

                if (dvalue != null && dvalue != "")
                    extra2 = " and lower(division)='" + dvalue.ToLower() + "'";

                string sql = "select distinct DoctorName from rpt_ageing where Area ='" + values + "'" + extra1 + extra2;
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdoctor.Add(Common.GetString(rdr["DoctorName"]));
                }
                rdr.Close();
            }

            Common.CloseConnection();

            return itmstaticdata;
        }

        public DataSet GetAgeingReportDataDynamic(SearchAgeing itmsearch,int rows)
        {
            RptAgeingList lstAgeing = new RptAgeingList();
            Common.OpenConnection();
            String sql = "select * from rpt_ageing";
            if (rows > 0)
                sql = "select top " + rows + " * from rpt_ageing";

            string whsql = "";
            string strconcat = "";
            if (itmsearch.div != null && itmsearch.div != "" && itmsearch.div != "select")
            {
                whsql = whsql + strconcat + " division like '%" + itmsearch.div + "%'";
                strconcat = " and ";
            }

            if (itmsearch.rsm != null && itmsearch.rsm != "" && itmsearch.rsm != "select")
            {
                whsql = whsql + strconcat + " RSMHQ like '%" + itmsearch.rsm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.asm != null && itmsearch.asm != "" && itmsearch.asm != "select")
            {
                whsql = whsql + strconcat + " ASMHQ like '%" + itmsearch.asm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.msr != null && itmsearch.msr != "" && itmsearch.msr != "select")
            {
                whsql = whsql + strconcat + " MSRHQ like '%" + itmsearch.msr + "%'";
                strconcat = " and ";
            }
            if (itmsearch.area != null && itmsearch.area != "" && itmsearch.area != "select")
            {
                whsql = whsql + strconcat + " Area like '%" + itmsearch.area + "%'";
                strconcat = " and ";
            }
            if (itmsearch.doctor != null && itmsearch.doctor != "" && itmsearch.doctor != "select")
            {
                whsql = whsql + strconcat + " DoctorName like '%" + itmsearch.doctor + "%'";
                strconcat = " and ";
            }

            //date range not required
            //if (itmsearch.intFrom > 0 && itmsearch.intTo > 0)
            //{
            //    string months = "";
            //    string separator = "";
            //    int count = itmsearch.intFrom;
            //    while (count <= itmsearch.intTo)
            //    {
            //        months = months + separator + "'" + Common.monthlist.ElementAt(count) + "'";
            //        separator = ",";
            //        count++;
            //    }

            //    whsql = whsql + strconcat + " month in (" + months + ")";
            //}

            if (itmsearch.intFrom > 0)
            {
                string months = "";
                string separator = "";
                int count = itmsearch.intFrom;
                months = "'" + Common.monthlist.ElementAt(count) + "'";

                whsql = whsql + strconcat + " month = " + months;
            }

            if (whsql != null && whsql != "")
                sql = sql + " where " + whsql;

            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //return dt;

            //MendineMasterdummyDataSet dsCustomers = new MendineMasterdummyDataSet();
            DataSet dsCustomers = new DataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                //sda.Fill(dsCustomers, "rpt_ageing");
                sda.Fill(dsCustomers);
            }

            return dsCustomers;



            //using (SqlDataReader rdr = cmd.ExecuteReader())
            //{
            //    while (rdr.Read())
            //    {
            //        RptAgeing itmaging = new RptAgeing();
            //        itmaging.ZsmHQ = Common.GetString(rdr["ZsmHQ"]);
            //        itmaging.Area = Common.GetString(rdr["Area"]);
            //        itmaging.AreaType = Common.GetString(rdr["AreaType"]);
            //        itmaging.DoctorName = Common.GetString(rdr["DoctorName"]);
            //        lstAgeing.Add(itmaging);
            //    }
            //}



        }



        public String populateReportFromSP(string div, string mont)
        {
            String ret = "";
            
            bool executesp = true;
            Common.OpenConnection();

            string sql = "select count(*) as cnt from rpt_ageing where division='" + div + "' and month='" + mont + "'";
            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int tot = Common.GetInt(rdr["cnt"]);
                if (tot > 0)
                    executesp = false;
            }
            rdr.Close();

            if (executesp)
            {
                cmd = new SqlCommand("ageingreport", Common.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@divisin", div);
                cmd.Parameters.AddWithValue("@month", mont);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    using (SqlCommand cmd1 = new SqlCommand("SaveReportFromDT"))
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Connection = Common.conn;
                        //  cmd1.Parameters.AddWithValue("@tblotx", dt);
                        cmd1.Parameters.AddWithValue("@tblmad", dt);
                        // cmd1.Parameters.AddWithValue("@tblmfso", dt);
                        cmd1.Parameters.AddWithValue("@div", div);
                        cmd1.Parameters.AddWithValue("@mn", mont);
                        cmd1.ExecuteNonQuery();

                    }

                }
            }

            Common.CloseConnection();

            ret = "Execution completed for Ageing report";
            return ret;
        }
    }
}