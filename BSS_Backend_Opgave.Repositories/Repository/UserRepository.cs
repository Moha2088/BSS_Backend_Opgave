﻿using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BSS_Backend_Opgave.Repositories.Data;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BSS_Backend_OpgaveAPIContext _context;
        private readonly IMapper _mapper;

        public UserRepository(BSS_Backend_OpgaveAPIContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        /// <see cref="IUserRepository.CreateUser(UserCreateDTO, int, CancellationToken)"/>
        public async Task<UserGetDto> CreateUser(UserCreateDTO dto, int organisationId, CancellationToken cancellationToken)
        {
            var isEmailTaken = _context.User
                .AsNoTracking()
                .Any(user => user.Email.Equals(dto.Email));


            if (isEmailTaken)
            {
                throw new InvalidOperationException("Email is taken! Try again");
            }

            var user = _mapper.Map<User>(dto);
            var organisation = await _context.Organisation
                .SingleOrDefaultAsync(organisation => organisation.Id.Equals(organisationId), cancellationToken);

            user.OrganisationId = organisation!.Id;
            _context.User.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserGetDto>(user);
        }

        /// <see cref="IUserRepository.GetUser(int, CancellationToken)"/>
        public async Task<UserGetDto> GetUser(int id, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .AsNoTracking()
                .SingleOrDefaultAsync(user => user.Id.Equals(id), cancellationToken);
            return _mapper.Map<UserGetDto>(user);
        }

        /// <see cref="IUserRepository.GetUsers(CancellationToken)"/>
        public async Task<IEnumerable<UserGetDto>> GetUsers(CancellationToken cancellationToken)
        {
            var users = await _context.User
                .AsNoTracking()
                .ToListAsync(cancellationToken);


            var mappedUsers = _mapper.Map<IEnumerable<UserGetDto>>(users);
            return mappedUsers;
        }

        /// <see cref="IUserRepository.DeleteUser(int, CancellationToken)"/>
        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            var userToDelete = await _context.User.SingleOrDefaultAsync(user => user.Id.Equals(id), cancellationToken);
            _context.User.Remove(userToDelete!);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
