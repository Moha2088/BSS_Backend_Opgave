﻿using AutoMapper;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class SensorRepository : ISensorRepository
    {
        private readonly BSS_Backend_OpgaveAPIContext _context;
        private readonly IMapper _mapper;

        public SensorRepository(BSS_Backend_OpgaveAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <see cref="ISensorRepository.CreateSensor(SensorCreateDto, int, CancellationToken)"/>
        public async Task<SensorGetDto> CreateSensor(SensorCreateDto dto, int organisationId, CancellationToken cancellationToken)
        {
            var sensor = _mapper.Map<Sensor>(dto);
            var organisation = await _context.Organisation
                .SingleOrDefaultAsync(x => x.Id.Equals(organisationId));

            var sensorCategory = await _context.SensorCategory.FirstOrDefaultAsync();
            sensor.OrganisationId = organisation!.Id;
            sensor.SensorCategoryId = sensorCategory!.Id;
            _context.Add(sensor);
            await _context.SaveChangesAsync();
            return _mapper.Map<SensorGetDto>(sensor);
        }

        /// <see cref="ISensorRepository.DeleteSensor(int, CancellationToken)"/>
        public async Task DeleteSensor(int id, CancellationToken cancellationToken)
        {
            var sensor = await _context.Sensor.SingleOrDefaultAsync(sensor => sensor.Id.Equals(id));
            _context.Remove(sensor);
            await _context.SaveChangesAsync();
        }

        /// <see cref="ISensorRepository.GetSensor(int, CancellationToken)"/>
        public async Task<SensorGetDto> GetSensor(int id, CancellationToken cancellationToken)
        {
            var sensor = await _context.Sensor.SingleOrDefaultAsync(sensor => sensor.Id.Equals(id), cancellationToken);
            return _mapper.Map<SensorGetDto>(sensor);
        }

        /// <see cref="ISensorRepository.GetSensors(CancellationToken)"/>
        public async Task<IEnumerable<SensorGetDto>> GetSensors(CancellationToken cancellationToken)
        {
            var sensors = await _context.Sensor
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SensorGetDto>>(sensors);
        }
    }
}
