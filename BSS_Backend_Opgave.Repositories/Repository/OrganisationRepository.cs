﻿using AutoMapper;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly BSS_Backend_OpgaveAPIContext _context;
        private readonly IMapper _mapper;

        public OrganisationRepository(BSS_Backend_OpgaveAPIContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);


        public async Task<OrganisationGetDto> CreateOrganisation(OrganisationCreateDto dto, CancellationToken cancellationToken)
        {
            var organisation = _mapper.Map<Organisation>(dto);
            _context.Organisation.Add(organisation);
            
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<OrganisationGetDto>(organisation);
        }

        public async Task DeleteOrganisation(int id, CancellationToken cancellationToken)
        {
            var organisation = await _context.Organisation.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
            _context.Organisation.Remove(organisation!);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<OrganisationGetDto> GetOrganisation(int id, CancellationToken cancellationToken)
        {
            var organisation = await _context.Organisation
                .AsNoTracking()
                .Include(x => x.Users)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            return _mapper.Map<OrganisationGetDto>(organisation);
        }

        public async Task<IEnumerable<OrganisationGetDto>> GetOrganisations(CancellationToken cancellationToken)
        {
            var organisations = await _context.Organisation
                .Include(x => x.Users)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<OrganisationGetDto>>(organisations);
        }
    }
}