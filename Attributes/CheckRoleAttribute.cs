using DormAPI.Exceptions;
using DormAPI.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace DormAPI.Attributes
{
    /// <summary>
    /// Attribute used for verifying user's role upon calling certain endpoints that require authorization
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckRoleAttribute : Attribute, IAuthorizationFilter
    {
        private UserRole[] _allowedRoles;

        /// <summary>
        /// CheckRole attribute constructor
        /// </summary>
        /// <param name="allowedRoles"></param>
        public CheckRoleAttribute(params UserRole[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        /// <summary>
        /// Inherited from the IAuthorizationFilter interface
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="UnauthorizedException">Thrown if the caller presented an invalid access token</exception>
        /// <exception cref="ForbiddenException">Thrown if the caller's role is not allowed to call the action</exception>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var roleClaim = context.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type.Contains(ClaimTypes.Role));

            if(roleClaim is null)
            {
                context.Result = new UnauthorizedObjectResult(ErrorMessages.InvalidTokenRoleMissing);
                return;
            }

            if (roleClaim.Value == "Admin")
                return;

            if(!Enum.TryParse<UserRole>(roleClaim.Value, true, out var callerRole))
            {
                context.Result = new UnauthorizedObjectResult(ErrorMessages.RoleNotDefined);
                return;
            }

            if (!_allowedRoles.Any(ar => ar == callerRole))
            {
                context.Result = new UnauthorizedObjectResult(ErrorMessages.RoleNotAllowed);
            }
        }
    }
}
