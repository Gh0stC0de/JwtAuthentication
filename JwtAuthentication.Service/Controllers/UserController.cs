using System;
using System.Security.Authentication;
using JwtAuthentication.Core.Models;
using JwtAuthentication.Service.Models;
using JwtAuthentication.Service.Services.Abstractions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Service.Controllers
{
    /// <summary>
    ///     Controls interaction with user.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserController" /> class with a user service.
        /// </summary>
        /// <param name="authenticationService">Authentication service</param>
        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        ///     Authenticates a user.
        /// </summary>
        /// <param name="model">Authentication model</param>
        /// <returns>Action result</returns>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            AuthenticationResponse authenticationResponse;
            try
            {
                authenticationResponse = _authenticationService.Authenticate(model.Username, model.Password);
            }
            catch (InvalidCredentialException e)
            {
                return BadRequest(new BadRequestResponse(nameof(e), e.Message));
            }

            return Ok(authenticationResponse);
        }

        /// <summary>
        ///     Registers a user.
        /// </summary>
        /// <param name="model">Register model</param>
        /// <returns>Action result</returns>
        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            var user = model.Adapt<User>();

            User createdUser;
            try
            {
                createdUser = _authenticationService.Register(user, model.Password);
            }
            catch (Exception e) when (e is ArgumentNullException || e is ArgumentException ||
                                      e is InvalidOperationException)
            {
                return BadRequest(new BadRequestResponse(nameof(e), e.Message));
            }

            return Ok(new RegisterResponse(createdUser.Id, createdUser.Username));
        }
    }
}