using AutoMapper;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Extensions;
using ClinicAPIv1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Controllers
{
    
    public class AdminController : BaseApiController
    {
        private readonly UserManager<ClinicUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdminController(UserManager<ClinicUser> userManager,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]

        public async Task<ActionResult> GetUsersWithRolesAsync()
        {
            var users = await _userManager.Users
                .Include(r => r.ClinicRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Name = u.Name,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    Roles = u.ClinicRoles.Select(r => r.Role.Name)
                    .ToList()
                })
                .ToListAsync();

            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-temporaryRole")]
        public async Task<ActionResult> GetUsersWithTemporaryRoleAsync()
        {
            var users = await _userManager.Users
                .Select(x => new
                {
                    x.Id,
                    UserName = x.UserName,
                    TemporaryRole = x.TemporaryRole
                }).ToListAsync();

            return Ok(users);
        }

        [HttpPut("edit-temporaryRole")]
        public async Task<ActionResult> EditTemporaryRole(TemporaryRoleUpdateDTO temporaryRoleUpdateDTO)
        {
            var user = await _unitOfWork.UserRepository.GetDoctorByEmail(temporaryRoleUpdateDTO.UserName);

            if (user == null) return NotFound("Could not find user");

            _mapper.Map(temporaryRoleUpdateDTO, user);

            _unitOfWork.UserRepository.Update(user);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed");
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("edit-roles/{username}")]
        public async Task<ActionResult> EditRoles(string userName,
            [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null) return NotFound("Could not find user");

            var userRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded) return BadRequest("Failed to add to roles");

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded) return BadRequest("Failed to remove from roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }
    }
}
