﻿using Hospital.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logic.Store
{
    public record DoctorCreate
    {
        public string FullName { get; init; } = null!;

        public long? SiteId { get; init; }

        public long OfficeId { get; init; }

        public long SpecializationId { get; init; }
    }
}
