﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchAgeing
/// </summary>
/// 

namespace model
{
    public class SearchAgeing
    {
        public SearchAgeing()
        {
        }


        public string div { get; set; }
        public string rsm { get; set; }
        public string asm { get; set; }
        public string msr { get; set; }
        public string area { get; set; }
        public string doctor { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public int intFrom { get; set; }
        public int intTo { get; set; }
    }
}