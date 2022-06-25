using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/user/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get All users
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
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<UserModel>> GetById(int id)
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
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult<UserModel>> GetByLotId(int id)
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Bad Request
        [ProducesResponseType(StatusCodes.Status200OK)] // Ok
        public async Task<ActionResult> Add([FromBody] UserModel user)
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
