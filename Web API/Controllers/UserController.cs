﻿using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Web_API.Models;
using System.Security.Claims;
using DAL.Entities;

namespace Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration,IUserService userService)
        {
            _userService = userService;
            _configuration = configuration;
        }

        /// TEST AUTHORIZATION
        


        private UserDTO CurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserDTO
                {
                    //Id = userClaims.FirstOrDefault(n=> n.Type == ClaimTypes.)
                    Name = userClaims.FirstOrDefault(n => n.Type == ClaimTypes.NameIdentifier)?.Value,
                    Surname = userClaims.FirstOrDefault(n => n.Type == ClaimTypes.Surname)?.Value,
                    Location = userClaims.FirstOrDefault(n => n.Type == ClaimTypes.Locality)?.Value,
                    Email = userClaims.FirstOrDefault(n => n.Type == ClaimTypes.Email)?.Value,
                    PhoneNumber = userClaims.FirstOrDefault(n => n.Type == ClaimTypes.HomePhone)?.Value,
                    AccessLevel = userClaims.FirstOrDefault(n => n.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
        ///

        /// <summary>
        /// Get the current user
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/user/GetCurrentUser
        /// 
        /// </remarks>
        /// <returns> The current user who is authorized</returns>
        /// <response code="200" >Success</response>
        /// <response code="400" >Bad Request</response>
        /// <response code="404" >Not Found</response>
        /// <response code="401" >Not Authorizate</response>
        /// <response code="403" >Don`t have access</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<UserModel>> GetCurrentUser()
        {
            var Current_user = CurrentUser();
            UserModel WantedUser = null;
            try
            {
                var allUsers = await _userService.GetAllAsync();

                WantedUser = allUsers.FirstOrDefault(x => x.Email == Current_user.Email);

                if (WantedUser == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(WantedUser);
        }

        /// <summary>
        /// Get All users in system
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/user/get
        /// 
        /// </remarks>
        /// <returns> A list of existed users</returns>
        /// <response code="200" >Success</response>
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            IEnumerable<UserModel> users = null;
            try
            {
                users = await _userService.GetAllAsync();
                if (users == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok(users);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/user/GetById/id
        /// 
        /// </remarks>
        /// <returns> User with the desired id </returns>
        [HttpGet("{id}")]
        //[Authorize/*(Roles = "Admin")*/]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<BLL.Models.UserModel>> GetById(int id)
        {
            var model = await _userService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return model;
        }

        /// <summary>
        /// Get user by lot id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     GET api/user/GetByLotId/id
        /// 
        /// </remarks>
        /// <returns> User with the desired lot id </returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<BLL.Models.UserModel>> GetByLotId(int id)
        {
            var users = await _userService.GetUsersByLotIdAsync(id);

            if (!users.Any())
            {
                return NotFound("Users for this users not found.");
            }

            return Ok(users);
        }

        /// <summary>
        /// Add user in db
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     POST api/user/add
        /// 
        /// </remarks>
        /// <returns> Added user to database </returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> Add([FromBody] BLL.Models.UserModel user)
        {
            try
            {
                await _userService.AddAsync(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Add), new { id = user.Id }, user);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     PUT api/user/update/id
        /// 
        /// </remarks>
        /// <returns> Updated user in database </returns>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] UserModel value)
        {
            try
            {
                await _userService.UpdateAsync(value);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Update), new { id = value.Id }, value);
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     DELETE api/user/delete/id
        /// 
        /// </remarks>
        /// <returns> Remoted user </returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Delete), new { id = id });
        }
    }
}
