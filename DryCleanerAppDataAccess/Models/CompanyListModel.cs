﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppDataAccess.Models
{
    public class CompanyListModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyCity { get; set; }
        public string? CompanyState { get; set; }
        public string? CompanyCountry { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyEmail { get; set; }
        public int CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public string? Place { get; set; }
        public string? LandMark { get; set; }

        public string? IsActive { get; set; }
        public string CreatedOn { get; set; } = string.Empty;
    }
}
