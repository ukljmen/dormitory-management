using AutoMapper;
using DormAPI.Exceptions;
using DormAPI.Models.Entities;
using DormAPI.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace DormAPI.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        protected int GetUserIdFromToken()
        {
            var userId = _httpContextAccessor.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == "Id")?.Value
                ?? throw new ForbiddenException(ErrorMessages.InvalidTokenUserIdMissing);

            return int.Parse(userId);
        }

        /// <summary>
        /// Returns person ID from the token
        /// </summary>
        /// <exception cref="ForbiddenException"></exception>
        protected int GetPersonIdFromToken()
        {
            var personId = _httpContextAccessor.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == "PersonId")?.Value
                ?? throw new ForbiddenException(ErrorMessages.InvalidTokenPersonIdMissing);

            return int.Parse(personId);
        }

        protected UserRole GetUserRoleFromToken()
        {
            var roleClaim = _httpContextAccessor.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type.Contains(ClaimTypes.Role))
                ?? throw new ForbiddenException(ErrorMessages.InvalidTokenRoleMissing);

            if (!Enum.TryParse<UserRole>(roleClaim.Value, true, out var callerRole))
            {
                throw new ForbiddenException(ErrorMessages.RoleNotDefined);
            }

            return callerRole;
        }
    }
}
