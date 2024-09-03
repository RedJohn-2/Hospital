using Hospital.Logic.Models.Enums;
using Hospital.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logic.Store
{
    public record PatientUpdate
    {
        public string? Surname { get; init; } 

        public string? Name { get; init; }

        public string? Patronymic { get; init; }

        public string? Address { get; init; }

        public DateTime? BirthDate { get; init; }

        public Sex? Sex { get; init; }

        public long? SiteId { get; init; }
    }
}
