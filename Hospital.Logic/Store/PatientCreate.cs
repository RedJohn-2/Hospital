using Hospital.Logic.Models.Enums;
using Hospital.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logic.Store
{
    public record PatientCreate
    {
        public string Surname { get; init; } = null!;

        public string Name { get; init; } = null!;

        public string? Patronymic { get; init; }

        public string Address { get; init; } = null!;

        public DateOnly BirthDate { get; init; }

        public Sex Sex { get; init; }

        public long SiteId { get; init; }
    }
}
