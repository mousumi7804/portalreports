using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RptReturn
/// </summary>
/// 

namespace model
{
    public class RptReturn
    {
        public RptReturn()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int RptReturnId { get; set; }
        public string Depot { get; set; }
        public string MFSO_HQ { get; set; }
        public string MFSO_Name { get; set; }
        public string DSO_ASM_HQ { get; set; }
        public string DSO_ASM_Name { get; set; }
        public string RSM_HQ { get; set; }
        public string RSM_Name { get; set; }
        public string ZSM_HQ { get; set; }
        public string ZSM_Name { get; set; }
        public string GM_HQ { get; set; }
        public string GM_Name { get; set; }
        public string DoctorUID { get; set; }
        public string DoctorName { get; set; }
        public string Cluster { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }
        public string DocCategory { get; set; }
        public string ChemistCode { get; set; }
        public string ChemistName { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public decimal NRVPrice { get; set; }
        public string SubtotFor1 { get; set; }
        public int SubtotUnit1 { get; set; }
        public decimal SubtotValue1 { get; set; }
        public string SubtotFor2 { get; set; }
        public int SubtotUnit2 { get; set; }
        public decimal SubtotValue2 { get; set; }
        public string SubtotFor3 { get; set; }
        public int SubtotUnit3 { get; set; }
        public decimal SubtotValue3 { get; set; }
        public string SubtotFor4 { get; set; }
        public int SubtotUnit4 { get; set; }
        public decimal SubtotValue4 { get; set; }
        public string SubtotFor5 { get; set; }
        public int SubtotUnit5 { get; set; }
        public decimal SubtotValue5 { get; set; }
        public string SubtotFor6 { get; set; }
        public int SubtotUnit6 { get; set; }
        public decimal SubtotValue6 { get; set; }
        public string Division { get; set; }
    }

    public class RptReturnList : List<RptReturn>
    {

    }
}