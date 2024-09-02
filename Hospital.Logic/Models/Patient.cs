using Hospital.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logic.Models
{
    public class Patient
    {
        public long Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string Address { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public Sex Sex { get; set; }

        public Office Office { get; set; } = null!;
    }
}
