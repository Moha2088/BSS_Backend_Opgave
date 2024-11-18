﻿using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Services.Service
{
    public class EventLogService : IEventLogService
    {
        private readonly IEventLogRepository _eventLogRepository;

        public EventLogService(IEventLogRepository eventLogRepository)
        {
            _eventLogRepository = eventLogRepository;
        }

        public async Task<EventLogGetDto> UpdateState()
        {
            var eventLog = await _eventLogRepository.UpdateState();
            return eventLog;
        }
    }
}