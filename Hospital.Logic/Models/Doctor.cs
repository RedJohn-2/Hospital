using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logic.Models
{
    public class Doctor
    {
        public long Id { get; set; }

        public string FullName { get; set; } = null!;

        public Specialization Specialization { get; set; } = null!;

        public Office Office { get; set; } = null!;

        public HospitalSite? Site { get; set; }
    }
}
