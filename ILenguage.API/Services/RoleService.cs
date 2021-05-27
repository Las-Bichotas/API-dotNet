﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Repositories;
using ILenguage.API.Domain.Services.Communication;

namespace ILenguage.API.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await _roleRepository.ListAsync();
        }

        public async Task<RoleResponse> GetByIdAsync(int id)
        {
            var existingRole = await _roleRepository.FindById(id);

            if (existingRole == null)
                return new RoleResponse("Role not found");
            return new RoleResponse(existingRole);
        }


        public async Task<RoleResponse> SaveAsync(Role role)
        {
            try
            {
                await _roleRepository.AddAsync(role);
                await _unitOfWork.CompleteAsync();

                return new RoleResponse(role);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"An error ocurred while saving role: {ex.Message}");
            }
        }

        public async Task<RoleResponse> UpdateAsync(int id, Role role)
        {
            var existingRole = await _roleRepository.FindById(id);
            if (existingRole == null)
                return new RoleResponse("Role not found");

            existingRole.Name = role.Name;

            try
            {
                _roleRepository.Update(existingRole);
                await _unitOfWork.CompleteAsync();

                return new RoleResponse(existingRole);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"An error ocurred while updating role: {ex.Message}");
            }
        }

        public async Task<RoleResponse> DeleteAsync(int id)
        {
            var existingRole = await _roleRepository.FindById(id);

            if (existingRole == null)
                return new RoleResponse("Role not found");
            try
            {
                _roleRepository.Remove(existingRole);
                await _unitOfWork.CompleteAsync();

                return new RoleResponse(existingRole);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"An error ocurred while deleting role: {ex.Message}");
            }
        }
    }
}
