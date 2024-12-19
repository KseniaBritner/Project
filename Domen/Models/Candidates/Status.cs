﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Candidates
{
    public enum Status
    {
        InProcessing = 0,
        Approved = 1,
        Rejected = 2,
        Restarted = 3
    }
}
