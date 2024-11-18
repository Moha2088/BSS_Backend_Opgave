﻿using BSS_Backend_Opgave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos
{
    public class EventLogGetDto
    {
        public int Id { get; set; }

        public DateTimeOffset EventTime { get; set; }

        public State State { get; set; } = null!;
    }
}