using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticAssets;
using Microsoft.AspNetCore.StaticAssets.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.DTO.ResponseDTO;
using PPI_Challenge_API.Filters;
using PPI_Challenge_API.Services.Interfaces;
using PPI_Challenge_API.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PPI_Challenge_API.Endpoints
{
    public static class AccountEndpoints
    {
        public static RouteGroupBuilder MapAccount(this RouteGroupBuilder group) 
        {
            group.MapPost("/register", Register).AddEndpointFilter<ValidationFilter<UserCredentialsDTO>>();
            group.MapGet("/renew", Renew).AddEndpointFilter<ValidationFilter<UserCredentialsDTO>>().RequireAuthorization();
            group.MapPost("/changepassword", ChangePassword).RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<ChangePasswordDTO>>();
            group.MapPost("/login", Login);
            return group;
        }

        private static async Task<Results<Ok<AuthenticationResponseDTO>,BadRequest<IEnumerable<IdentityError>>>> Register([FromServices] UserManager<IdentityUser> userManager, UserCredentialsDTO userCredentialsDTO, IConfiguration configuration, IMapper mapper) 
        {
            var user = mapper.Map<IdentityUser>(userCredentialsDTO);
            var result = await userManager.CreateAsync(user, userCredentialsDTO.Password);

            if (result.Succeeded)
            {
                var authenticationResponse =
                    await BuildToken(userCredentialsDTO, configuration, userManager);
                return TypedResults.Ok(authenticationResponse);
            }
            else
            {
                return TypedResults.BadRequest(result.Errors);
            }
        }

        private static async Task<Results<NoContent, Ok<AuthenticationResponseDTO>>> Renew(
            IUsersService usersService, IConfiguration configuration,
            [FromServices] UserManager<IdentityUser> userManager)
        {
            var user = await usersService.GetUser();

            if (user is null)
            {
                return TypedResults.NoContent();
            }

            var usersCredential = new UserCredentialsDTO { Email = user.Email! };
            var response = await BuildToken(usersCredential, configuration, userManager);
            return TypedResults.Ok(response);
        }

        private static async Task<Results<NotFound, NoContent, BadRequest<IEnumerable<IdentityError>>>> ChangePassword(ChangePasswordDTO changePasswordDTO,
            IUsersService usersService,
            [FromServices] UserManager<IdentityUser> userManager)
        {
            var user = await usersService.GetUser();
            if (user is null)
            {
                return TypedResults.NotFound();
            }
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, changePasswordDTO.Password);

            if (result.Succeeded)
            {
                return TypedResults.NoContent();
            }
            else
            {
                return TypedResults.BadRequest(result.Errors);
            }
        }
        static async Task<Results<Ok<AuthenticationResponseDTO>, BadRequest<string>>> Login(
            UserCredentialsDTO userCredentialsDTO,
            [FromServices] SignInManager<IdentityUser> signInManager,
            [FromServices] UserManager<IdentityUser> userManager,
            IConfiguration configuration
            )
        {
            var user = await userManager.FindByEmailAsync(userCredentialsDTO.Email);

            if (user is null)
            {
                return TypedResults.BadRequest("There was a problem with the email or the password");
            }

            var results = await signInManager.CheckPasswordSignInAsync(user,
                userCredentialsDTO.Password, lockoutOnFailure: false);

            if (results.Succeeded)
            {
                var authenticationResponse =
                   await BuildToken(userCredentialsDTO, configuration, userManager);
                return TypedResults.Ok(authenticationResponse);
            }
            else
            {
                return TypedResults.BadRequest("There was a problem with the email or the password");
            }
        }

        private async static Task<AuthenticationResponseDTO>
        BuildToken(UserCredentialsDTO userCredentialsDTO,
        IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            var claims = new List<Claim>
            {
                new Claim("email", userCredentialsDTO.Email),
            };

            var user = await userManager.FindByNameAsync(userCredentialsDTO.UserName);

            var claimsFromDB = await userManager.GetClaimsAsync(user);
            claims.AddRange(claimsFromDB);
            

            var key = KeysHandler.GetKey(configuration).First();
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null,
                claims: claims, expires: expiration, signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new AuthenticationResponseDTO
            {
                Token = token,
                Expiration = expiration
            };
        }


    }
}
